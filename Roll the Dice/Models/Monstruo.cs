namespace Roll_the_Dice.Models
{
    public class Monstruo
    {
        public Monstruo()
        {
        }

        public int monstruoId { get; set; }
        public string nombre { get; set; }
        public int vida { get; set; }
        public int turnos { get; set; }
        public int estadosAlterados { get; set; }
        public int nivel { get; set; }
        public int oro { get; set; }
        public int plata { get; set; }
        public int cobre { get; set; }
        public int sala { get; set; }
        public int posicion { get; set; }
    }
}
