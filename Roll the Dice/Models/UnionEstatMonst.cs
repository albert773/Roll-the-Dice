namespace Roll_the_Dice.Models
{
    public class UnionEstatMonst
    {
        public int estadisticaId { get; set; }
        public int monstruoId { get; set; }
        public int valorBase { get; set; }
        public decimal bonus { get; set; }

        public virtual Estadistica Estadistica { get; set; }
        public virtual Monstruo Monstruo { get; set; }
    }
}
