using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Raza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Raza()
        {
            this.NPC = new HashSet<NPC>();
            this.Personaje = new HashSet<Personaje>();
        }

        public int razaId { get; set; }
        public string nombre { get; set; }
        public decimal altura { get; set; }
        public int peso { get; set; }
        public Nullable<int> idioma { get; set; }
        public int estadistica { get; set; }
        public int bonus { get; set; }

        public virtual Estadistica Estadistica1 { get; set; }
        public virtual Idioma Idioma1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC> NPC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personaje { get; set; }
    }
}
