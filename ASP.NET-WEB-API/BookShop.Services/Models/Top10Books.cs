using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class Top10Books
    {
        public string Title { get; set; }

        public int id { get; set; }

        public Top10Books(Book book)
        {
            this.Title = book.Title;
            this.id = book.Id;
        }
    }
}