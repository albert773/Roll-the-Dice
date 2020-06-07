using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Posicion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posicion()
        {
            this.Monstruo = new HashSet<Monstruo>();
            this.NPC = new HashSet<NPC>();
            this.Personaje = new HashSet<Personaje>();
        }

        public int posicionId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool bloqueado { get; set; }
        public Nullable<int> mapa { get; set; }

        public virtual Mapa Mapa1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monstruo> Monstruo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC> NPC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personaje { get; set; }
    }
}
