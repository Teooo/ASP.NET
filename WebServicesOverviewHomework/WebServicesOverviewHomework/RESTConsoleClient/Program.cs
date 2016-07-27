using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DistCalcRESTService;


namespace RESTConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine("Enter the cordinates of the first point.");
                Console.Write("X=");
                int x1 = int.Parse(Console.ReadLine());
                Console.Write("Y=");
                int y1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the cordinates of the second point.");
                Console.Write("X=");
                int x2 = int.Parse(Console.ReadLine());
                Console.Write("Y=");
                int y2 = int.Parse(Console.ReadLine());
                string uri = "http://localhost:54376/dist?x1="+x1+"&y1="+y1+"&x2="+x2+"&y2="+y2;
                string response = client.UploadString(uri,"POST","");


                Console.WriteLine("The distance between these points is :{0}", response);
            }
        }
    }
}
