using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_app.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string GuestNumber { get; set; }
        public DateTime?  CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}