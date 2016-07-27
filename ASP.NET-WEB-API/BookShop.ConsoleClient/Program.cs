
namespace BookShop.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookShop.Models;
    using BookShop.Data;


    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            Console.WriteLine(context.Books.Count());
        }
    }
}
