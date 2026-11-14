import { useEffect, useState } from "react";

const API = "https://localhost:7130";

const ENTIDADES = [
  { ruta: "Pacientes", schema: "Paciente" },
  { ruta: "Medicos", schema: "Medico" },
  { ruta: "Especialidades", schema: "Especialidad" },
  { ruta: "Consultorios", schema: "Consultorio" },
  { ruta: "Citas", schema: "Cita" },
  { ruta: "HistoriasClinicas", schema: "HistoriaClinica" },
  { ruta: "Diagnosticos", schema: "Diagnostico" },
  { ruta: "Tratamientos", schema: "Tratamiento" },
  { ruta: "Medicamentos", schema: "Medicamento" },
  { ruta: "Recetas", schema: "Receta" },
  { ruta: "RecetaDetalles", schema: "RecetaDetalle" },
];

const nombreRef = (ref) => ref.split("/").pop();

function camposDe(schema, schemas) {
  const campos = [];
  for (const [nombre, prop] of Object.entries(schema.properties || {})) {
    if (nombre.toLowerCase() === "id") continue;
    if (prop.type === "array") continue;
    let p = prop.allOf ? prop.allOf[0] : prop;
    if (p.$ref) {
      const r = schemas[nombreRef(p.$ref)];
      if (r && r.enum) p = { type: "integer" };
      else continue;
    }
    campos.push({ nombre, tipo: p.type, formato: p.format });
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
  const [form, setForm] = useState({});
  const [editId, setEditId] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    fetch(`${API}/swagger/v1/swagger.json`)
      .then((r) => r.json())
      .then((d) => setSchemas(d.components.schemas))
      .catch(() => setError("No se pudo conectar con la API. Revisa el puerto y que la API esté corriendo."));
  }, []);

  const campos = schemas && schemas[ent.schema] ? camposDe(schemas[ent.schema], schemas) : [];

  const cargar = async () => {
    try {
      const r = await fetch(`${API}/api/${ent.ruta}`);
      setItems(await r.json());
      setError("");
    } catch {
      setError("No se pudo cargar la lista.");
    }
  };

  useEffect(() => {
    setForm({});
    setEditId(null);
    cargar();
  }, [ent]);

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
      else body[c.nombre] = v;
    });

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
    <div style={{ fontFamily: "system-ui, sans-serif", padding: 20, maxWidth: 1100, margin: "0 auto" }}>
      <h1>Sistema de Pacientes</h1>

      <div style={{ display: "flex", flexWrap: "wrap", gap: 6, marginBottom: 16 }}>
        {ENTIDADES.map((x) => (
          <button
            key={x.ruta}
            onClick={() => setEnt(x)}
            style={{
              padding: "6px 12px",
              cursor: "pointer",
              border: "1px solid #7c3aed",
              borderRadius: 6,
              background: x.ruta === ent.ruta ? "#7c3aed" : "#fff",
              color: x.ruta === ent.ruta ? "#fff" : "#5b21b6",
            }}
          >
            {x.ruta}
          </button>
        ))}
      </div>

      {error && <p style={{ color: "crimson" }}>{error}</p>}

      <h2>{editId ? `Editar ${ent.ruta} #${editId}` : `Nuevo registro en ${ent.ruta}`}</h2>
      <form onSubmit={guardar} style={{ display: "grid", gridTemplateColumns: "repeat(auto-fill, minmax(220px, 1fr))", gap: 10 }}>
        {campos.map((c) => (
          <label key={c.nombre} style={{ display: "flex", flexDirection: "column", fontSize: 13 }}>
            {c.nombre}
            {tipoInput(c) === "checkbox" ? (
              <input type="checkbox" checked={!!form[c.nombre]} onChange={(e) => cambiar(c, e.target.checked)} />
            ) : (
              <input
                type={tipoInput(c)}
                step={c.tipo === "number" ? "any" : undefined}
                value={form[c.nombre] ?? ""}
                onChange={(e) => cambiar(c, e.target.value)}
                style={{ padding: 6 }}
              />
            )}
          </label>
        ))}
        <div style={{ gridColumn: "1 / -1", display: "flex", gap: 8 }}>
          <button type="submit" style={{ padding: "8px 16px", cursor: "pointer" }}>
            {editId ? "Actualizar" : "Guardar"}
          </button>
          {editId && (
            <button type="button" onClick={() => { setForm({}); setEditId(null); }} style={{ padding: "8px 16px", cursor: "pointer" }}>
              Cancelar
            </button>
          )}
        </div>
      </form>

      <h2>Listado ({items.length})</h2>
      <div style={{ overflowX: "auto" }}>
        <table style={{ borderCollapse: "collapse", width: "100%", fontSize: 14 }}>
          <thead>
            <tr>
              <th style={th}>id</th>
              {campos.map((c) => <th key={c.nombre} style={th}>{c.nombre}</th>)}
              <th style={th}>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {items.map((it) => (
              <tr key={it.id}>
                <td style={td}>{it.id}</td>
                {campos.map((c) => (
                  <td key={c.nombre} style={td}>
                    {c.tipo === "boolean" ? (it[c.nombre] ? "Sí" : "No") : String(it[c.nombre] ?? "")}
                  </td>
                ))}
                <td style={td}>
                  <button onClick={() => editar(it)} style={{ cursor: "pointer" }}>Editar</button>{" "}
                  <button onClick={() => eliminar(it.id)} style={{ cursor: "pointer" }}>Eliminar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

const th = { border: "1px solid #ddd6fe", padding: 8, background: "#ede9fe", textAlign: "left", color: "#4c1d95" };
const td = { border: "1px solid #ddd6fe", padding: 8 };