namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permission
    {
        public int PermissionId { get; set; }

        [Required]
        [StringLength(200)]
        public string PermissionName { get; set; }

        [StringLength(250)]
        public string Category { get; set; }

        [StringLength(350)]
        public string Description { get; set; }

        [StringLength(350)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
