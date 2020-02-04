using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class RestaurantDiet
    {
        public int Id { get; set; }

       public int DietTypeId { get; set; }

        public int RestaurantId { get; set; }

       
    }
}
