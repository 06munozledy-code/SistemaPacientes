
namespace SistemaPacientes.Domain.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaDiagnostico { get; set; }

        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica? HistoriaClinica { get; set; }
    }
}
