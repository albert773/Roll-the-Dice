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
    
    public partial class Habilidad
    {
        public int habilidadId { get; set; }
        public string nombre { get; set; }
        public int coste { get; set; }
        public int nivel { get; set; }
        public int estadistica { get; set; }
        public decimal bonus { get; set; }
        public Nullable<int> elemento { get; set; }
    
        public virtual Elemento Elemento1 { get; set; }
        public virtual Estadistica Estadistica1 { get; set; }
    }
}
