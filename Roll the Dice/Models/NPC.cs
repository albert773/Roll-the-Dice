using System;
using System.Collections.Generic;

namespace Roll_the_Dice.Models
{
    public class NPC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NPC()
        {
            this.UnionEstatNPC = new HashSet<UnionEstatNPC>();
            this.Habilidad = new HashSet<Habilidad>();
        }

        public int NPCId { get; set; }
        public string nombre { get; set; }
        public int clase { get; set; }
        public int raza { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public int vida { get; set; }
        public int turnos { get; set; }
        public int cansancio { get; set; }
        public Nullable<int> estadosAlterados { get; set; }
        public string misionOculta { get; set; }
        public int nivel { get; set; }
        public int experiencia { get; set; }
        public int oro { get; set; }
        public int plata { get; set; }
        public int cobre { get; set; }
        public int sala { get; set; }
        public Nullable<int> posicion { get; set; }

        public virtual Clase Clase1 { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Posicion Posicion1 { get; set; }
        public virtual Raza Raza1 { get; set; }
        public virtual Sala Sala1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnionEstatNPC> UnionEstatNPC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }
    }
}
