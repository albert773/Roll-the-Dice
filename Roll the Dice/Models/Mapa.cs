namespace Roll_the_Dice.Models
{
    public class Mapa
    {
        public Mapa()
        {
        }

        public int mapaId { get; set; }
        public int tamaño { get; set; }
        public int sala { get; set; }
        public byte[] imagen { get; set; }
    }
}
