namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderStatu
    {
        [Key]
        public int OrderStatusId { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
