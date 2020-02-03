using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class Cuisine
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RestaurantId { get; set; }

        [Display(Name = "Cuisine")]
        public string CuisineName { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
