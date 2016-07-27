

namespace BookShop.Services.Controllers
{
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
    
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private BookShopContext db = new BookShopContext();
     
        [HttpGet]
        public IHttpActionResult GetCagetories()
        {
            List<Category> inputs = db.Categories.ToList();
            List<CategoryViewModel> models = new List<CategoryViewModel>();
            
            if(inputs.Count !=0)
            {
                foreach (var model in inputs)
                {
                    models.Add(new CategoryViewModel(model));
                    
                }
                return this.Ok(models);
            }
          
                return this.BadRequest();
            
        }
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = db.Categories.FirstOrDefault(i => i.Id == id);
            if(category == null)
            {
                return this.BadRequest();
            }
            return this.Ok(new CategoryViewModel(category));
        }

        [HttpPost]
        [Route("{Name}")]
        public IHttpActionResult PostCategory([FromUri]CategoryBindingModel model)
        {
            var test = db.Categories.FirstOrDefault(c => c.Name == model.Name);
            if (test != null && !ModelState.IsValid)
            {
                return this.BadRequest();
            }
            else
            {
                Category newCategory = new Category() { Name = model.Name };
                db.Categories.Add(newCategory);
                db.SaveChanges();
                return this.Ok(model);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(i => i.Id == id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return this.Ok();
            }
            return this.BadRequest();
        }

        [HttpPut]
        [Route("{id}/{Name}")]
        public IHttpActionResult UpdateCategory(int id,string Name)
        {
            
            var categoryIdTest = db.Categories.FirstOrDefault(i => i.Id == id);
            string old = categoryIdTest.Name;
            var categoryNameTest = db.Categories.FirstOrDefault(n => n.Name == Name);
            if(categoryIdTest != null && categoryNameTest == null && ModelState.IsValid)
            {
                categoryIdTest.Name = Name;
                db.SaveChanges();
                return this.Ok(string.Format("updated category: {0} to :{1}",old,Name));

            }
            return this.BadRequest();
        }
    }
}