using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models.ViewModels
{
    public class FavoritesViewModel
    {

        
        public List<FavoriteRestaurant> FavoriteRestaurant { get; set; }

      

        public List<FavoriteMeal> FavoriteMeal { get; set; }

       
    }
}
