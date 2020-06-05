namespace Roll_the_Dice.Models
{
    public class Habilidad
    {
        public Habilidad()
        {
        }

        public int habilidadId { get; set; }
        public string nombre { get; set; }
        public int coste { get; set; }
        public int nivel { get; set; }
        public int estadistica { get; set; }
        public decimal bonus { get; set; }
        public int elemento { get; set; }
    }
}
