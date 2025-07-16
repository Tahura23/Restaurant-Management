namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int MenuId { get; set; }

        [Required]
        [StringLength(250)]
        public string MenuName { get; set; }


       

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }
        [Display(Name = "Branch")]

        public int BranchId { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }

        public IEnumerable<SelectListItem> Branches { get; set; }
    }
}
