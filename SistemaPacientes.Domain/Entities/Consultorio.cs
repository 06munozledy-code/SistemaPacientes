
namespace SistemaPacientes.Domain.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }

        public string Numero { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Ubicacion { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public bool Disponible { get; set; }
    }
}
