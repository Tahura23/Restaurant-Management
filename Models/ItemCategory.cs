namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("ItemCategory")]
    public partial class ItemCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

       

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        
        [StringLength(200)]
        public string CreatedBy { get; set; }

        [Required]
        public int RestId { get; set; }

        [Required]
        public int BranchId { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }

        public int MenuId { get; set; }


        public virtual Branch Branch { get; set; }


    }
}
