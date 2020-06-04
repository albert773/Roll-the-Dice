namespace Roll_the_Dice.Models
{
    public class Arma
    {
        public int armaId { get; set; }
        public int nombre { get; set; }
        public int rareza { get; set; }
        public int daño { get; set; }
        public int esquiva { get; set; }
        public int defensa { get; set; }
        public int alcance { get; set; }
        public int estadistica { get; set; }
        public decimal bonus { get; set; }
        public int elemento { get; set; }
        public string descripcion { get; set; }
        public bool equipado { get; set; }
        public int peso { get; set; }
        public int durabilidad { get; set; }
        public int inventario { get; set; }
    }
}
