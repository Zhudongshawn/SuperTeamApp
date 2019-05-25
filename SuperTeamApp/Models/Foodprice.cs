using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTeamApp.Models
{
    public class Foodprice
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FPrice { get; set; }
        [Display(Name = "picture")]
        public string PictureUrl { get; set; }
    }
}
