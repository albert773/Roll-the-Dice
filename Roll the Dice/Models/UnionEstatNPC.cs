namespace Roll_the_Dice.Models
{
    public class UnionEstatNPC
    {
        public int estadisticaId { get; set; }
        public int NPCId { get; set; }
        public int valorBase { get; set; }
        public decimal bonus { get; set; }

        public virtual Estadistica Estadistica { get; set; }
        public virtual NPC NPC { get; set; }
    }
}
