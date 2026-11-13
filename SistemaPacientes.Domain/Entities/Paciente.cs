
namespace SistemaPacientes.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; } = string.Empty;

        public string Sexo { get; set; } = string.Empty;
    }
}
