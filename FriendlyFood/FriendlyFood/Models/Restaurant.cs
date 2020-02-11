using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

       

        [Display(Name = "Restaurant")]

        public string RestaurantName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }

        public string City { get; set; }

        [Display(Name = "Cuisine")]
        public int CuisineId { get; set; }

        public Cuisine Cuisine { get; set; }
        public List<Cuisine> Cuisines { get; set; }

        public RestaurantDiet RestaurantDiet { get; set; }
        
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
