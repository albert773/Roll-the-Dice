namespace Roll_the_Dice.Models
{
    public partial class Sala
    {
        public Sala() { }

        public int salaId { get; set; }
        public string nombre { get; set; }
        public int propietario { get; set; }
        public string password { get; set; }
    }
}
