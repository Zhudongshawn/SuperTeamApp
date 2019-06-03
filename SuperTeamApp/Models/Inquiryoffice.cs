using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTeamApp.Models
{
    public class Inquiryoffice
    {
        [Key]
        public int InquiryId { get; set; }
        public string FoodName { get; set; }
        public string Question{ get; set; }
        public string Answer { get; set; }
       
    }
}
