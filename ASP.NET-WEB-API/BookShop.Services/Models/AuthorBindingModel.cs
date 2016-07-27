using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class AuthorBindingModel
    {
        [Required]
        [MinLength(2)]
        public string FirstName  { get; set; }

        public string LastName { get; set; }
    }
}