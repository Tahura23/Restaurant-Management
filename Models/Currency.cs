namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Currency")]
    public partial class Currency
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string CurrencyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Symbol { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(150)]
        public string CurrencyCode { get; set; }

        public DateTime CreatedBy { get; set; }
    }
}
