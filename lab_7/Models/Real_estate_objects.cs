namespace lab_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Real_estate_objects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Real_estate_objects()
        {
            Evaluations = new HashSet<Evaluations>();
            Sale = new HashSet<Sale>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Object_id { get; set; }

        public int? District { get; set; }

        [Column(TypeName = "text")]
        public string Address { get; set; }

        public int? Floor { get; set; }

        public int? Number_of_rooms { get; set; }

        public int? Type { get; set; }

        public int? Status { get; set; }

        public decimal? Cost { get; set; }

        [Column(TypeName = "text")]
        public string Object_description { get; set; }

        public int? Building_material { get; set; }

        public decimal? Area { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Announcement_date { get; set; }

        public virtual Building_materials Building_materials { get; set; }

        public virtual Districts Districts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluations> Evaluations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
