namespace SistemaPacientes.Application.DTOs
{
    public class EspecialidadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }

    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Exequatur { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public int EspecialidadId { get; set; }
    }

    public class ConsultorioDto
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }

    public class PacienteDto
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
    }

    public class CitaDto
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int ConsultorioId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Programada";
    }

    public class HistoriaClinicaDto
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Antecedentes { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
    }

    public class DiagnosticoDto
    {
        public int Id { get; set; }
        public int HistoriaClinicaId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }

    public class TratamientoDto
    {
        public int Id { get; set; }
        public int DiagnosticoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public int DuracionDias { get; set; }
    }

    public class MedicamentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Presentacion { get; set; } = string.Empty;
        public string Concentracion { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }

    public class RecetaDto
    {
        public int Id { get; set; }
        public int TratamientoId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Notas { get; set; }
    }

    public class RecetaDetalleDto
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public int MedicamentoId { get; set; }
        public string Dosis { get; set; } = string.Empty;
        public string Frecuencia { get; set; } = string.Empty;
        public int DuracionDias { get; set; }
        public int Cantidad { get; set; }
        public string? Indicaciones { get; set; }
    }
}