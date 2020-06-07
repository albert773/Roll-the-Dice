using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class Estadistica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estadistica()
        {
            this.Arma = new HashSet<Arma>();
            this.Armadura = new HashSet<Armadura>();
            this.Habilidad = new HashSet<Habilidad>();
            this.Raza = new HashSet<Raza>();
            this.UnionEstatPerso = new HashSet<UnionEstatPerso>();
            this.UnionEstatMonst = new HashSet<UnionEstatMonst>();
            this.UnionEstatNPC = new HashSet<UnionEstatNPC>();
        }

        public int estadisticaId { get; set; }
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arma> Arma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Armadura> Armadura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raza> Raza { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnionEstatPerso> UnionEstatPerso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnionEstatMonst> UnionEstatMonst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnionEstatNPC> UnionEstatNPC { get; set; }
    }
}
