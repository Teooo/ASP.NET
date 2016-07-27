using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookShop.Data;
using BookShop.Models;
using BookShop.Services.Models;
using System.Web;
using Microsoft.AspNet.Identity;

namespace BookShop.Services.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookShopContext db = new BookShopContext();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult  GetBookById(int id)
        {
            var book = db.Books.FirstOrDefault(i=>i.Id==id);
            if(book == null)
            {
                return this.BadRequest();
            }
            return this.Ok(new BookViewModel(book));
        }
        [HttpGet]
        [Route("search={word}")]
        public IHttpActionResult GetTop10BooksContainsSbstr(string word)
        {
            var books = db.Books.Where(t => t.Title.Contains(word)).OrderBy(t=>t.Title).Take(3);
            List<Top10Books> topBooks = new List<Top10Books>();
            foreach(var book in books)
            {
                topBooks.Add(new Top10Books(book));
            }
            return this.Ok(topBooks);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBookById(int id)
        {
            var book = db.Books.FirstOrDefault(i => i.Id == id);
            if(book != null)
            {
                db.Books.Remove(book);

                db.SaveChanges();
                return this.Ok("Succesfully deleted book");
            }
            return this.BadRequest("Cannot find book!");

        }

        [HttpPost]
        public IHttpActionResult PostNewBook([FromUri]BookBindingModel model)
        {
            var book = new Book();
            if(!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            book.Title = model.Title;
            book.Description = model.Description;
            book.Copies = model.Copies;
            book.AuthorId = model.AuthorId;
            book.Price = model.Price;
            book.Edition = model.Edition;
            db.Books.Add(book);
            db.SaveChanges();
            return this.Ok("Succesfully added new book.");
        }
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateBook(int id, [FromUri]BookBindingModel model)
        {
            var book = db.Books.FirstOrDefault(i => i.Id == id);
            if(!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            book.Title = model.Title;
            book.Description = model.Description;
            book.Copies = model.Copies;
            book.AuthorId = model.AuthorId;
            book.Price = model.Price;
            book.Edition = model.Edition;
            db.SaveChanges();
            return this.Ok();
        }
        //Creates a purchase with the specified book and the currently logged user. Decrements the book's copies by 1. If there are no copies, return an appropriate status code.

        [Authorize]
        [HttpPost]
        [Route("{title}")]
        public IHttpActionResult MakePurchase(string title)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            string userId = HttpContext.Current.User.Identity.GetUserId();
            
            var book = db.Books.FirstOrDefault(t => t.Title == title);
            if(book.Copies ==0)
            {
                return this.BadRequest();
            }
            var purchase = new Purchase();
            purchase.BookId = book.Id;
            purchase.Price = book.Price;
            purchase.UserId = userId;
            purchase.Username = userName;
            purchase.IsRecalled = false;
            purchase.PurchaseDate = DateTime.Now;
            book.Copies--;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return this.Ok("Succesfull purchase.");
        }
        [HttpPut] 
        [Route("recall/{id}")]
        [Authorize]
        public IHttpActionResult Recall(int id)
        {
            var purchase = db.Purchases.FirstOrDefault(p => p.Id == id);
            if(purchase == null )
            {
                return this.BadRequest();
            }
            if(purchase.IsRecalled == true)
            {
                return this.BadRequest("Cannot recall recalled purchase");
            }
            var book = db.Books.FirstOrDefault(b => b.Id == purchase.BookId);
            if(book == null)
            {
                return this.BadRequest();
            }
            purchase.IsRecalled = true;
            book.Copies++;
            db.SaveChanges();
            return this.Ok("Recalled purchase.");
        }
        

    }
    
}