using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyFood.Models
{
    public class Cuisine
    {
        public int Id { get; set; }

    [Display(Name = "Cuisine")]
        public string CuisineName { get; set; }

     
    }
}
