//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roll_the_Dice_Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Armadura
    {
        public int armaduraId { get; set; }
        public int corte { get; set; }
        public int defMagica { get; set; }
        public int defFisica { get; set; }
        public int penetracion { get; set; }
        public int contundente { get; set; }
        public decimal bonus { get; set; }
        public string descripcion { get; set; }
        public bool equipado { get; set; }
        public Nullable<int> peso { get; set; }
        public Nullable<int> durabilidad { get; set; }
    
        public virtual Elemento Elemento { get; set; }
        public virtual Estadistica Estadistica { get; set; }
        public virtual Inventario Inventario { get; set; }
        public virtual NombreArmadura NombreArmadura { get; set; }
        public virtual Rareza Rareza { get; set; }
    }
}
