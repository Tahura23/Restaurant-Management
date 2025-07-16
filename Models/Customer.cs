namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        [StringLength(250)]
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
