using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }

        public int CuisineId { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
