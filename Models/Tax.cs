namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tax")]
    public partial class Tax
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string TaxName { get; set; }

        [Required]
        [StringLength(250)]
        public string TaxPercent { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}
