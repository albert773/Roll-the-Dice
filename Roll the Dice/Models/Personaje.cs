namespace Roll_the_Dice.Models
{
    public class Personaje
    {
        public Personaje() { }

        public int personajeId { get; set; }
        public string nombre { get; set; }
        public int clase { get; set; }
        public int raza { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public int vida { get; set; }
        public int turnos { get; set; }
        public int cansancio { get; set; }
        public int estadosAlterados { get; set; }
        public string misionOculta { get; set; }
        public int nivel { get; set; }
        public int experiencia { get; set; }
        public int oro { get; set; }
        public int plata { get; set; }
        public int cobre { get; set; }
        public int sala { get; set; }
        public int usuario { get; set; }
        public int posicion { get; set; }
    }
}
