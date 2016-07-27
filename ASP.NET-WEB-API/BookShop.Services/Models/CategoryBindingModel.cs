using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class CategoryBindingModel
    {
       
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        
    }
}