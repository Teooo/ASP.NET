using DistanceCalc.ConsoleClient.ServiceReferenceDistCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalc.ConsoleClient
{
    class ConsoleClient
    {
        static void Main(string[] args)
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

            DistCalcClient client = new DistCalcClient();
            Point startP = new Point()
            {
                X=x1,
                Y=y1
            };
            Point endP = new Point()
            {
                X =x2,
                Y =-y2
            };
            var result = client.distance(startP, endP);
            Console.WriteLine("The distance between these points is :{0}", result);
           

        }
    }
}
