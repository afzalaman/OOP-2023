using System;

namespace PointCircle
{
    class Circle
    {
        public class WrongRadiusException : Exception {}

        private readonly Point c;
        private readonly double r;
        public Circle(Point p, double d) 
        {
            if (d < 0) throw new WrongRadiusException();
            c = p; r = d;
        }
        public bool Contains(Point p) 
        {
            return c.Distance(p) <= r;
        }
    }
}
