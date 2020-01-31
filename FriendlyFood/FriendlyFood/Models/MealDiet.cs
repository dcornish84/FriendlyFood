using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class MealDiet
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        public int DietTypeId { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
