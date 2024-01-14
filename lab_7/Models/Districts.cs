namespace lab_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Districts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Districts()
        {
            Real_estate_objects = new HashSet<Real_estate_objects>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int District_id { get; set; }

        [Column(TypeName = "text")]
        public string District_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_estate_objects> Real_estate_objects { get; set; }
    }
}
