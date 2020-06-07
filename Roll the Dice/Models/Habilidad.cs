using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Habilidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habilidad()
        {
            this.Monstruo = new HashSet<Monstruo>();
            this.NPC = new HashSet<NPC>();
            this.Personaje = new HashSet<Personaje>();
        }

        public int habilidadId { get; set; }
        public string nombre { get; set; }
        public int coste { get; set; }
        public int nivel { get; set; }
        public int estadistica { get; set; }
        public decimal bonus { get; set; }
        public Nullable<int> elemento { get; set; }

        public virtual Elemento Elemento1 { get; set; }
        public virtual Estadistica Estadistica1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monstruo> Monstruo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC> NPC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personaje { get; set; }
    }
}
