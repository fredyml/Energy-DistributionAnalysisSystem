namespace EDAS.Domain.Models
{
    public partial class Costo
    {
        public int? TramoId { get; set; }
        public int? FechaId { get; set; }
        public decimal? Residencial { get; set; }
        public decimal? Comercial { get; set; }
        public decimal? Industrial { get; set; }

        public virtual Fecha? Fecha { get; set; }
        public virtual Tramo? Tramo { get; set; }
    }
}
