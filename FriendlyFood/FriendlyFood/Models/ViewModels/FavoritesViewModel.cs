using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models.ViewModels
{
    public class FavoritesViewModel
    {

        [Display(Name = "Favorite Restaurants")]
        public List<FavoriteRestaurant> FavoriteRestaurant { get; set; }


        [Display(Name = "Favorite Meals")]
        public List<FavoriteMeal> FavoriteMeal { get; set; }

       
    }
}
