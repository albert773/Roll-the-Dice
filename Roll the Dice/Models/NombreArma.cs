using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class NombreArma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NombreArma()
        {
            this.Arma = new HashSet<Arma>();
        }

        public int nombreArmaId { get; set; }
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arma> Arma { get; set; }
    }
}
