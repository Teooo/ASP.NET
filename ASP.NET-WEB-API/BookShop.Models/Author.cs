

namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }
        
        [Required]
        public string  Firstname { get; set; }

        public string Lastname { get; set; }

        public  virtual ICollection<Book> Books 
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
