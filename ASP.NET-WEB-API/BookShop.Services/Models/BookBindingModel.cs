using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class BookBindingModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string  Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string Edition { get; set; }

        public int? AuthorId { get; set; }
    }
}