namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            KOTs = new HashSet<KOT>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(200)]
        public string OrderStatusId { get; set; }

        public int BranchId { get; set; }

        [Required]
        [StringLength(200)]
        public string PaymentStatusId { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int AssignExecutiveId { get; set; }

        public int TotalAmount { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DeliveryExecutive DeliveryExecutive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KOT> KOTs { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
