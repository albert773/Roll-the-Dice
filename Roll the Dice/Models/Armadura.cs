using System;

namespace Roll_the_Dice.Models
{
    public class Armadura
    {
        public int armaduraId { get; set; }
        public int nombre { get; set; }
        public int rareza { get; set; }
        public int corte { get; set; }
        public int defMagica { get; set; }
        public int defFisica { get; set; }
        public int penetracion { get; set; }
        public int contundente { get; set; }
        public int estadistica { get; set; }
        public decimal bonus { get; set; }
        public Nullable<int> elemento { get; set; }
        public string descripcion { get; set; }
        public bool equipado { get; set; }
        public Nullable<int> peso { get; set; }
        public Nullable<int> durabilidad { get; set; }
        public Nullable<int> inventario { get; set; }

        public virtual Elemento Elemento1 { get; set; }
        public virtual Estadistica Estadistica1 { get; set; }
        public virtual Inventario Inventario1 { get; set; }
        public virtual NombreArmadura NombreArmadura { get; set; }
        public virtual Rareza Rareza1 { get; set; }
    }
}
