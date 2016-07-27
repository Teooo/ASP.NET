using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistCalcRESTService
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public  static double distance(Point startPoint, Point endPoit)
        {
            int deltaX = startPoint.X - endPoit.X;
            int deltaY = startPoint.Y - endPoit.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        }
        
    }
}