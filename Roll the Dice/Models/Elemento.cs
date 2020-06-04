namespace Roll_the_Dice.Models
{
    public class Elemento
    {
        public Elemento()
        {
        }

        public int elementoId { get; set; }
        public string nombre { get; set; }
        public int rango { get; set; }
        public int daño { get; set; }
        public int debufo { get; set; }
        public int debilidad { get; set; }
        public string descripcion { get; set; }
    }
}
