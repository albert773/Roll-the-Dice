namespace Roll_the_Dice.Models
{
    public class Posicion
    {
        public Posicion() { }

        public int posicionId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool bloqueado { get; set; }
        public int mapa { get; set; }
    }
}
