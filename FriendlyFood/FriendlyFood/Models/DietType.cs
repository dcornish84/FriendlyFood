using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class DietType
    {
        public int Id { get; set; }

        [Display(Name = "Diet")]
        public string DietName { get; set; }

        public List<MealDiet> MealDiets { get; set; }
    }
}
