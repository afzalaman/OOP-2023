using System;

namespace PointCircle
{
    class Point
    {
        public readonly double x;
        public readonly double y; 
        public Point(double a, double b) { x = a; y = b; }
        public double Distance(Point p) {
            return Math.Sqrt(Math.Pow(x-p.x,2) + Math.Pow(y-p.y,2));
        }
    }
}
