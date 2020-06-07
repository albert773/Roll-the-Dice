namespace Roll_the_Dice.Models
{
    public class UnionEstatPerso
    {
        public int estadisticaId { get; set; }
        public int personajeId { get; set; }
        public int valorBase { get; set; }
        public decimal bonus { get; set; }

        public virtual Estadistica Estadistica { get; set; }
        public virtual Personaje Personaje { get; set; }
    }
}
