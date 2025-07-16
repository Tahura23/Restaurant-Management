namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public int RoleId { get; set; }

        [Required]
        [StringLength(300)]
        public string RoleName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
