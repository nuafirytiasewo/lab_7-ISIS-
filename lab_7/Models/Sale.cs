namespace lab_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sale_id { get; set; }

        public int? Object_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Sale_date { get; set; }

        public int? Realtor_id { get; set; }

        public decimal? Cost { get; set; }

        public virtual Real_estate_objects Real_estate_objects { get; set; }

        public virtual Realtor Realtor { get; set; }
    }
}
