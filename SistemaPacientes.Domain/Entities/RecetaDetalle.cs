namespace SistemaPacientes.Domain.Entities
{
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