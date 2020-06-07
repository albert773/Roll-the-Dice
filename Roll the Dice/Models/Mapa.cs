using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Mapa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mapa()
        {
            this.Posicion = new HashSet<Posicion>();
        }

        public int mapaId { get; set; }
        public int tamaño { get; set; }
        public int sala { get; set; }
        public byte[] imagen { get; set; }

        public virtual Sala Sala1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posicion> Posicion { get; set; }
    }
}
