using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class Meal
    {
        public int Id { get; set; }



        [Display(Name = "Meal")]

        public string MealName { get; set; }

       public string Description { get; set; }

        public int RestaurantId { get; set; }

        public List<Restaurant> Restaurants { get; set; }

        public Restaurant Restaurant { get; set; }

        

        public List<MealDiet> MealDiets { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
