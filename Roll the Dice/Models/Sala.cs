using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public partial class Sala
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sala()
        {
            this.Mapa = new HashSet<Mapa>();
            this.Monstruo = new HashSet<Monstruo>();
            this.NPC = new HashSet<NPC>();
            this.Personaje = new HashSet<Personaje>();
        }

        public int salaId { get; set; }
        public string nombre { get; set; }
        public Nullable<int> propietario { get; set; }
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mapa> Mapa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Monstruo> Monstruo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPC> NPC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personaje { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
