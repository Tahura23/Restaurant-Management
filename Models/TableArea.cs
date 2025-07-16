namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("TableArea")]
    public partial class TableArea
    {
        [Key]
        public int TableId { get; set; }

        public int AreaId { get; set; }

        [Required]
        [StringLength(250)]
        public string TableCode { get; set; }

        public int SeatingCapacity { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public virtual Area Area { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }

    }
}
