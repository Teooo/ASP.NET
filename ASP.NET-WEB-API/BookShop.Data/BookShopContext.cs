namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BookShop.Models;
    using BookShop.Data.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookShopContext : IdentityDbContext<ApplicationUser>
    {
        
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }
        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        public System.Data.Entity.DbSet<BookShop.Models.ApplicationUser> ApplicationUsers { get; set; }
        
    }

    
}