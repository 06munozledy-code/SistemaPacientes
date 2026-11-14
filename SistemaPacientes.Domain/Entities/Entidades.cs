namespace SistemaPacientes.Domain.Entities
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }

    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Exequatur { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad? Especialidad { get; set; }
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }

    public class Consultorio
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<HistoriaClinica> HistoriasClinicas { get; set; } = new List<HistoriaClinica>();
    }

    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }
        public int ConsultorioId { get; set; }
        public Consultorio? Consultorio { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Programada";
    }

    public class HistoriaClinica
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Antecedentes { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();
    }

    public class Diagnostico
    {
        public int Id { get; set; }
        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica? HistoriaClinica { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
    }

    public class Tratamiento
    {
        public int Id { get; set; }
        public int DiagnosticoId { get; set; }
        public Diagnostico? Diagnostico { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public int DuracionDias { get; set; }
    }

    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Presentacion { get; set; } = string.Empty;
        public string Concentracion { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }

    public class Receta
    {
        public int Id { get; set; }
        public int TratamientoId { get; set; }
        public Tratamiento? Tratamiento { get; set; }
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }
        public DateTime Fecha { get; set; }
        public string? Notas { get; set; }
        public ICollection<RecetaDetalle> Detalles { get; set; } = new List<RecetaDetalle>();
    }

    public class RecetaDetalle
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public Receta? Receta { get; set; }
        public int MedicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }
        public string Dosis { get; set; } = string.Empty;
        public string Frecuencia { get; set; } = string.Empty;
        public int DuracionDias { get; set; }
        public int Cantidad { get; set; }
        public string? Indicaciones { get; set; }
    }
}