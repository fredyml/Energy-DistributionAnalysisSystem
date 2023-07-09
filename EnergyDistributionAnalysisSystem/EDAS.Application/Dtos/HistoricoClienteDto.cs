namespace EDAS.Application.Dtos
{
    public class HistoricoClienteDto
    {
        public DateTime Fecha { get; set; }
        public string Tramo { get; set; } = string.Empty;
        public double Consumo { get; set; }
        public double Perdidas { get; set; }
        public double Costo { get; set; }
    }
}
