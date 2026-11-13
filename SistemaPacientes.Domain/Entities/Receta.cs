
namespace SistemaPacientes.Domain.Entities
{
    public class Receta
    {
        public int Id { get; set; }

        public DateTime FechaEmision { get; set; }

        public string Indicaciones { get; set; } = string.Empty;

        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public ICollection<RecetaDetalle> Detalles { get; set; }
            = new List<RecetaDetalle>();
    }
}
