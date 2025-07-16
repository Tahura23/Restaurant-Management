namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryExecutive")]
    public partial class DeliveryExecutive
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryExecutive()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int ExecutiveId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
