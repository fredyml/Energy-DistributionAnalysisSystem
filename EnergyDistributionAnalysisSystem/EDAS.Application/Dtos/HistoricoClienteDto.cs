namespace EDAS.Application.Dtos
{
    public class HistoricoClienteDto
    {
        public string TipoCliente { get; set; }
        public string Tramo { get; set; }
        public decimal Consumo { get; set; }
        public decimal Perdidas { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
