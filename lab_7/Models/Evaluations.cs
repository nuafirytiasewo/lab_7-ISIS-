namespace lab_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Evaluations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Evaluation_id { get; set; }

        public int? Object_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Evaluation_date { get; set; }

        public int? Criteria_id { get; set; }

        public decimal? Evaluation { get; set; }

        public virtual Evaluation_criteria Evaluation_criteria { get; set; }

        public virtual Real_estate_objects Real_estate_objects { get; set; }
    }
}
