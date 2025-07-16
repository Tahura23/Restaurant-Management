namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KOT")]
    public partial class KOT
    {
        public int KOTId { get; set; }

        public int OrderId { get; set; }

        public int MenuItemId { get; set; }

        public int Qty { get; set; }

        [Required]
        [StringLength(200)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }
    }
}
