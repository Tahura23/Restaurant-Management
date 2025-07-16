using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant_app.Models
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId {  get; set; }
        public string Timing { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}