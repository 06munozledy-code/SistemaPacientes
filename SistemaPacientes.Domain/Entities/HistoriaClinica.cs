
namespace SistemaPacientes.Domain.Entities
{
    public class HistoriaClinica
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Antecedentes { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;

        public string Alergias { get; set; } = string.Empty;

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
