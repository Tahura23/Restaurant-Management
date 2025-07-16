namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeZone")]
    public partial class TimeZone
    {
        public int Id { get; set; }

        [Column("TimeZone")]
        [Required]
        [StringLength(250)]
        public string TimeZone1 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }
    }
}
