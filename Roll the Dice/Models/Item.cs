namespace Roll_the_Dice.Models
{
    public class Item
    {
        public Item()
        {
        }

        public int itemId { get; set; }
        public string nombre { get; set; }
        public int rareza { get; set; }
        public string descripcion { get; set; }
        public bool equipar { get; set; }
        public int peso { get; set; }
        public int durabilidad { get; set; }
    }
}
