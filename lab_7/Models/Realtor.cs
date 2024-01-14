namespace lab_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Realtor")]
    public partial class Realtor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Realtor()
        {
            Sale = new HashSet<Sale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Realtor_id { get; set; }

        [Column(TypeName = "text")]
        public string Last_name { get; set; }

        [Column(TypeName = "text")]
        public string First_name { get; set; }

        [Column(TypeName = "text")]
        public string Middle_name { get; set; }

        [Column(TypeName = "text")]
        public string Contact_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
