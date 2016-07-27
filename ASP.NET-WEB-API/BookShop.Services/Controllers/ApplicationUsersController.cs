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
    [RoutePrefix("api/users")]
    public class ApplicationUsersController : ApiController
    {
        
        private BookShopContext db = new BookShopContext();

        [HttpGet]
        [Route("{username}/purchases")]
        public IHttpActionResult UserNamePurchases(string username)
        {
            var purchases = db.Purchases.Where(u => u.User.UserName == username).OrderBy(d => d.PurchaseDate);
            List<PurchaseViewModel> models = new List<PurchaseViewModel>();
            if(purchases == null)
            {
                return this.BadRequest();
            }
            foreach (var purchase in purchases)
            {
                models.Add(new PurchaseViewModel(purchase));
            }


            return this.Ok(models);

        }
    }
}