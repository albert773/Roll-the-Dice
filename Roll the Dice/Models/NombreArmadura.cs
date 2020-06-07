using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class NombreArmadura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NombreArmadura()
        {
            this.Armadura = new HashSet<Armadura>();
        }

        public int nombreArmaduraId { get; set; }
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Armadura> Armadura { get; set; }
    }
}
