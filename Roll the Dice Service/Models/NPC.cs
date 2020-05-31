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
    
    public partial class NPC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NPC()
        {
            this.Estadistica = new HashSet<Estadistica>();
            this.Habilidad = new HashSet<Habilidad>();
        }
    
        public int NPCId { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public int vida { get; set; }
        public int turnos { get; set; }
        public int cansancio { get; set; }
        public string misionOculta { get; set; }
        public int nivel { get; set; }
        public int experiencia { get; set; }
        public int oro { get; set; }
        public int plata { get; set; }
        public int cobre { get; set; }
    
        public virtual Clase Clase { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Posicion Posicion { get; set; }
        public virtual Raza Raza { get; set; }
        public virtual Sala Sala { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estadistica> Estadistica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }
    }
}
