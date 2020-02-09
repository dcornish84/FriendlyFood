using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models.ViewModels
{
    public class DietsViewModel
    {
        public List<RestaurantDiet> RestaurantDiet { get; set; }

        public List<MealDiet> MealDiet { get; set; }

    }
}
