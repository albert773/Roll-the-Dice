using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Inventario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventario()
        {
            this.Arma = new HashSet<Arma>();
            this.Armadura = new HashSet<Armadura>();
            this.Item = new HashSet<Item>();
        }

        public int inventarioId { get; set; }
        public Nullable<int> propietario { get; set; }
        public int capacidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arma> Arma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Armadura> Armadura { get; set; }
        public virtual Personaje Personaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item { get; set; }
    }
}
