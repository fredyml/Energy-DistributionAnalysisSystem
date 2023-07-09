namespace EDAS.Domain.Models
{
    public partial class Linea
    {
        public Linea()
        {
            Consumos = new HashSet<Consumo>();
            Costos = new HashSet<Costo>();
            Perdida = new HashSet<Perdidum>();
        }

        public int LineaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Consumo> Consumos { get; set; }
        public virtual ICollection<Costo> Costos { get; set; }
        public virtual ICollection<Perdidum> Perdida { get; set; }
    }
}
