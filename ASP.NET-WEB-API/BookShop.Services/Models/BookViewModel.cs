
namespace BookShop.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BookShop.Models;

    public class BookViewModel
    {
        
        public string TitleModel { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string Author { get; set; }

        public ICollection<CategoryViewModel> CategoriesModel;

        public BookViewModel(Book book)
        {
            
            this.TitleModel = book.Title;
            this.Author = book.Author.Firstname + " " + book.Author.Lastname;
            this.Price = book.Price;
            this.Copies = book.Copies;
            this.CategoriesModel = new List<CategoryViewModel>();
            foreach (var category in book.Categories)
            {
                CategoriesModel.Add(new CategoryViewModel(category));
            }
            
           
            
        }
    }
}