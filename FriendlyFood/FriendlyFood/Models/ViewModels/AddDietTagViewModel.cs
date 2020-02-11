using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models.ViewModels
{
    public class AddDietTagViewModel
    {
        public int RestaurantId { get; set; }

        public List<DietType> DietTypes { get; set; }

        public List<int> DietTypeIds { get; set; }

        public List<RestaurantDiet> RestaurantDiets { get; set; }
    }
}
