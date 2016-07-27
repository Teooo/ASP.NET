using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Services.Models
{
    public class PurchaseViewModel
    {
        public string UserName { get; set; }

        public string BookTitle { get; set; }

        public decimal  Price { get; set; }

        public DateTime Date { get; set; }

        public string IsRecalled { get; set; }

        public PurchaseViewModel(Purchase purchase)
        {
            this.UserName = purchase.User.UserName;
            this.BookTitle = purchase.Book.Title;
            this.Price = purchase.Price;
            this.Date = purchase.PurchaseDate;
            if(purchase.IsRecalled == true)
            {
                this.IsRecalled = "IsRecalled";
            }
            else
            {
                this.IsRecalled = "Is Not recalled";
            }
        }
    }
}