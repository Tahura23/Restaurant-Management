namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentStatu
    {
        [Key]
        public int PaymentSId { get; set; }

        [Required]
        [StringLength(200)]
        public string PaymentStatus { get; set; }

        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
