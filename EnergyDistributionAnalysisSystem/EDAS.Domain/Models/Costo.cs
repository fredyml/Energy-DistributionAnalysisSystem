namespace EDAS.Domain.Models
{
    public partial class Costo
    {
        public int LineaId { get; set; }
        public int FechaId { get; set; }
        public int SectorId { get; set; }
        public double Valor { get; set; }

        public virtual Fecha Fecha { get; set; } = null!;
        public virtual Linea Linea { get; set; } = null!;
        public virtual Sector Sector { get; set; } = null!;
    }
}
