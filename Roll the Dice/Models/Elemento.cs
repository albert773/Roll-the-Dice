using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Elemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento()
        {
            this.Arma = new HashSet<Arma>();
            this.Armadura = new HashSet<Armadura>();
            this.Elemento1 = new HashSet<Elemento>();
            this.Habilidad = new HashSet<Habilidad>();
        }

        public int elementoId { get; set; }
        public string nombre { get; set; }
        public int rango { get; set; }
        public int daño { get; set; }
        public int debufo { get; set; }
        public int debilidad { get; set; }
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arma> Arma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Armadura> Armadura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento> Elemento1 { get; set; }
        public virtual Elemento Elemento2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }
    }
}
