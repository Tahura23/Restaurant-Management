namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int MenuItemId { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }

        public decimal SGST { get; set; }

        public decimal CGST { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        public int SubTotal { get; set; }

        public int Total { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }
    }
}
