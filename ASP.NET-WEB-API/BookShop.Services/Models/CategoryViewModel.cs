using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}