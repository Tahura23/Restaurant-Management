namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuItem()
        {
            KOTs = new HashSet<KOT>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        public int MenuId { get; set; }

        public int CategoryId { get; set; }

        public int Rate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

       
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int PreparationTime { get; set; }
        public string ItemImage { get; set; }
        public bool IsAvailable { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KOT> KOTs { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    
    }
}
