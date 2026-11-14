import { useEffect, useState } from "react";
import "./App.css";

const API = "https://localhost:7130";

const ENTIDADES = [
  { ruta: "Pacientes", schema: "PacienteDto" },
  { ruta: "Medicos", schema: "MedicoDto" },
  { ruta: "Especialidades", schema: "EspecialidadDto" },
  { ruta: "Consultorios", schema: "ConsultorioDto" },
  { ruta: "Citas", schema: "CitaDto" },
  { ruta: "HistoriasClinicas", schema: "HistoriaClinicaDto" },
  { ruta: "Diagnosticos", schema: "DiagnosticoDto" },
  { ruta: "Tratamientos", schema: "TratamientoDto" },
  { ruta: "Medicamentos", schema: "MedicamentoDto" },
  { ruta: "Recetas", schema: "RecetaDto" },
  { ruta: "RecetaDetalles", schema: "RecetaDetalleDto" },
];

// Campo de relación -> endpoint de donde salen las opciones
const FK = {
  EspecialidadId: "Especialidades",
  PacienteId: "Pacientes",
  MedicoId: "Medicos",
  ConsultorioId: "Consultorios",
  HistoriaClinicaId: "HistoriasClinicas",
  DiagnosticoId: "Diagnosticos",
  TratamientoId: "Tratamientos",
  RecetaId: "Recetas",
  MedicamentoId: "Medicamentos",
};

function etiqueta(it) {
  if (it.nombre) return `${it.id} - ${it.nombre}${it.apellido ? " " + it.apellido : ""}`;
  if (it.numero) return `${it.id} - Consultorio ${it.numero}`;
  if (it.descripcion) return `${it.id} - ${String(it.descripcion).slice(0, 40)}`;
  if (it.antecedentes) return `${it.id} - ${String(it.antecedentes).slice(0, 40)}`;
  if (it.fecha) return `${it.id} - ${String(it.fecha).slice(0, 10)}`;
  return `#${it.id}`;
}

function camposDe(schema) {
  const campos = [];
  for (const [nombre, prop] of Object.entries(schema.properties || {})) {
    if (nombre.toLowerCase() === "id") continue;
    campos.push({ nombre, tipo: prop.type, formato: prop.format });
  }
  return campos;
}

function tipoInput(c) {
  if (c.tipo === "integer" || c.tipo === "number") return "number";
  if (c.tipo === "boolean") return "checkbox";
  if (c.formato === "date-time") return "datetime-local";
  if (c.formato === "date") return "date";
  return "text";
}

export default function App() {
  const [schemas, setSchemas] = useState(null);
  const [ent, setEnt] = useState(ENTIDADES[0]);
  const [items, setItems] = useState([]);
  const [opciones, setOpciones] = useState({});
  const [form, setForm] = useState({});
  const [editId, setEditId] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    fetch(`${API}/swagger/v1/swagger.json`)
      .then((r) => r.json())
      .then((d) => setSchemas(d.components.schemas))
      .catch(() => setError("No se pudo conectar con la API. Revisa el puerto y que la API esté corriendo."));
  }, []);

  const campos = schemas && schemas[ent.schema] ? camposDe(schemas[ent.schema]) : [];

  const cargar = async () => {
    try {
      const r = await fetch(`${API}/api/${ent.ruta}`);
      setItems(await r.json());
      setError("");
    } catch {
      setError("No se pudo cargar la lista.");
    }
  };

  // Carga las opciones de las listas desplegables (relaciones)
  const cargarOpciones = async () => {
    const nuevas = {};
    for (const c of campos) {
      const ruta = FK[c.nombre];
      if (!ruta) continue;
      try {
        const r = await fetch(`${API}/api/${ruta}`);
        nuevas[c.nombre] = await r.json();
      } catch {
        nuevas[c.nombre] = [];
      }
    }
    setOpciones(nuevas);
  };

  useEffect(() => {
    setForm({});
    setEditId(null);
    cargar();
  }, [ent]);

  useEffect(() => {
    cargarOpciones();
  }, [ent, schemas]);

  const cambiar = (c, valor) => setForm({ ...form, [c.nombre]: valor });

  const guardar = async (e) => {
    e.preventDefault();
    const body = {};
    campos.forEach((c) => {
      const v = form[c.nombre];
      if (c.tipo === "boolean") body[c.nombre] = !!v;
      else if (v === undefined || v === "" || v === null) {
        if (c.tipo === "string" && !c.formato) body[c.nombre] = "";
      } else if (c.tipo === "integer" || c.tipo === "number") body[c.nombre] = Number(v);
      else if (c.formato === "date-time" && String(v).length === 16) body[c.nombre] = v + ":00";
      else body[c.nombre] = v;
    });
    if (editId) body.id = editId;

    const url = editId ? `${API}/api/${ent.ruta}/${editId}` : `${API}/api/${ent.ruta}`;
    const r = await fetch(url, {
      method: editId ? "PUT" : "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(body),
    });
    if (!r.ok) {
      setError("Error al guardar: " + (await r.text()).slice(0, 300));
      return;
    }
    setForm({});
    setEditId(null);
    setError("");
    cargar();
  };

  const editar = (item) => {
    const f = {};
    campos.forEach((c) => {
      let v = item[c.nombre];
      if (v && c.formato === "date-time") v = String(v).slice(0, 16);
      if (v && c.formato === "date") v = String(v).slice(0, 10);
      f[c.nombre] = v ?? "";
    });
    setForm(f);
    setEditId(item.id);
    window.scrollTo(0, 0);
  };

  const eliminar = async (id) => {
    if (!confirm("¿Eliminar este registro?")) return;
    const r = await fetch(`${API}/api/${ent.ruta}/${id}`, { method: "DELETE" });
    if (!r.ok) setError("No se pudo eliminar (puede tener registros relacionados).");
    else setError("");
    cargar();
  };

  return (
    <div>
      <div className="header">
        <h1>🩺 Sistema de Pacientes</h1>
        <p>Gestión de pacientes, médicos, citas, tratamientos y recetas</p>
      </div>

      <div className="tabs">
        {ENTIDADES.map((x) => (
          <button
            key={x.ruta}
            className={"tab" + (x.ruta === ent.ruta ? " activo" : "")}
            onClick={() => setEnt(x)}
          >
            {x.ruta}
          </button>
        ))}
      </div>

      {error && <div className="error">{error}</div>}

      <div className="card">
        <h2>{editId ? `Editar ${ent.ruta} #${editId}` : `Nuevo registro en ${ent.ruta}`}</h2>
        <form onSubmit={guardar}>
          <div className="form-grid">
            {campos.map((c) => (
              <label key={c.nombre}>
                {c.nombre}
                {FK[c.nombre] ? (
                  <select
                    required
                    value={form[c.nombre] ?? ""}
                    onChange={(e) => cambiar(c, e.target.value)}
                  >
                    <option value="">
                      {(opciones[c.nombre] || []).length === 0
                        ? `Primero crea un registro en ${FK[c.nombre]}`
                        : "Seleccione..."}
                    </option>
                    {(opciones[c.nombre] || []).map((o) => (
                      <option key={o.id} value={o.id}>
                        {etiqueta(o)}
                      </option>
                    ))}
                  </select>
                ) : tipoInput(c) === "checkbox" ? (
                  <input
                    type="checkbox"
                    checked={!!form[c.nombre]}
                    onChange={(e) => cambiar(c, e.target.checked)}
                  />
                ) : (
                  <input
                    type={tipoInput(c)}
                    step={c.tipo === "number" ? "any" : undefined}
                    min={tipoInput(c) === "datetime-local" ? "1900-01-01T00:00" : undefined}
                    max={tipoInput(c) === "datetime-local" ? "2100-12-31T23:59" : undefined}
                    value={form[c.nombre] ?? ""}
                    onChange={(e) => cambiar(c, e.target.value)}
                  />
                )}
              </label>
            ))}
          </div>
          <div style={{ display: "flex", gap: 10, marginTop: 18 }}>
            <button type="submit" className="btn">
              {editId ? "Actualizar" : "Guardar"}
            </button>
            {editId && (
              <button
                type="button"
                className="btn btn-secondary"
                onClick={() => {
                  setForm({});
                  setEditId(null);
                }}
              >
                Cancelar
              </button>
            )}
          </div>
        </form>
      </div>

      <div className="card">
        <h2>Listado ({items.length})</h2>
        <div className="tabla-wrap">
          <table>
            <thead>
              <tr>
                <th>id</th>
                {campos.map((c) => (
                  <th key={c.nombre}>{c.nombre}</th>
                ))}
                <th>Acciones</th>
              </tr>
            </thead>
            <tbody>
              {items.map((it) => (
                <tr key={it.id}>
                  <td>{it.id}</td>
                  {campos.map((c) => (
                    <td key={c.nombre}>
                      {c.tipo === "boolean" ? (it[c.nombre] ? "Sí" : "No") : String(it[c.nombre] ?? "")}
                    </td>
                  ))}
                  <td style={{ whiteSpace: "nowrap" }}>
                    <button className="btn btn-secondary btn-sm" onClick={() => editar(it)}>
                      Editar
                    </button>{" "}
                    <button className="btn btn-danger btn-sm" onClick={() => eliminar(it.id)}>
                      Eliminar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {items.length === 0 && <div className="vacio">Todavía no hay registros.</div>}
        </div>
      </div>
    </div>
  );
}