namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        public int StaffId { get; set; }

        [Required]
        [StringLength(200)]
        public string MemberName { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }
    }
}
