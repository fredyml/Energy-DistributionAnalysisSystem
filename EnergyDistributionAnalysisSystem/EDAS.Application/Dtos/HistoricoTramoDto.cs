namespace EDAS.Application.Dtos
{
    public class HistoricoTramoDto
    {
        public string Tramo { get; set; } = string.Empty;
        public double Consumo { get; set; }
        public double Perdidas { get; set; }
        public double Costo { get; set; }
    }
}
