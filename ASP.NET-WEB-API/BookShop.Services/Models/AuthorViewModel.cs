using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class AuthorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<BookViewModel> Books { get; set; }

        public AuthorViewModel(Author author)
        {
            this.FirstName = author.Firstname;
            this.LastName = author.Lastname;
            Books = new List<BookViewModel>();
            foreach (var book in author.Books)
            {
                this.Books.Add(new BookViewModel(book));
            }
        }
    }
}