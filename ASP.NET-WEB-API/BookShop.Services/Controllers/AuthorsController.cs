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

namespace BookShop.Services.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private BookShopContext db = new BookShopContext();

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetBooksByAuthorId(int id)
        {
            var books = db.Authors.Where(a => a.Id == id).ToList();
            if(books.Count == 0)
            {
                return this.BadRequest();
            }
            List<AuthorViewModel> models = new List<AuthorViewModel>();
            foreach (var book in books)
            {
                models.Add(new AuthorViewModel(book));
            }
            return this.Ok(models);
        }

        [HttpPost]
        
        public IHttpActionResult PostAuthor([FromUri]AuthorBindingModel model)
        {
            var newAuthor = new Author();
            if(!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            newAuthor.Firstname = model.FirstName;
            newAuthor.Lastname = model.LastName;
            db.Authors.Add(newAuthor);
            db.SaveChanges();
            return this.Ok(model);
        }
        
    }
}