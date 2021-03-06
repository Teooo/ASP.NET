﻿

namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        private ICollection<Category> categories;

        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string Edition { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories 
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
