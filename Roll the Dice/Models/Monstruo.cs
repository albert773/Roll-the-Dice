using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Monstruo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monstruo()
        {
            this.UnionEstatMonst = new HashSet<UnionEstatMonst>();
            this.Habilidad = new HashSet<Habilidad>();
        }

        public int monstruoId { get; set; }
        public string nombre { get; set; }
        public int vida { get; set; }
        public int turnos { get; set; }
        public Nullable<int> estadosAlterados { get; set; }
        public int nivel { get; set; }
        public int oro { get; set; }
        public int plata { get; set; }
        public int cobre { get; set; }
        public int sala { get; set; }
        public Nullable<int> posicion { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Posicion Posicion1 { get; set; }
        public virtual Sala Sala1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnionEstatMonst> UnionEstatMonst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }
    }
}
