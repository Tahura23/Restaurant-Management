using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_app.Models
{
    public class Meal
    {
        public int MealId{ get; set; }
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}