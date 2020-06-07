using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Inventario = new HashSet<Inventario>();
        }

        public int itemId { get; set; }
        public string nombre { get; set; }
        public int rareza { get; set; }
        public string descripcion { get; set; }
        public bool equipar { get; set; }
        public Nullable<int> peso { get; set; }
        public Nullable<int> durabilidad { get; set; }

        public virtual Rareza Rareza1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
