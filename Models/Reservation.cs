namespace Restaurant_app.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int ReservationId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
      
        public int GuestId { get; set; }

        [Required]
   
        public int MealId { get; set; }

        [Required]
    
        public int TimeSlotId { get; set; }

        [Required]
        [StringLength(250)]
        public string Requestdes { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(250)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public int RestId { get; set; }

        public int BranchId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual OrganizationInfo OrganizationInfo { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }

        //public virtual Reservation Reservation1 { get; set; }

        //public virtual Reservation Reservation2 { get; set; }
    }
}

