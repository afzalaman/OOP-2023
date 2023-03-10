using System;
using TextFile;
using System.Collections.Generic;

namespace PointCircle
{
    class Program
    {
        static void Main()
        {
            try
            {
                TextFileReader reader = new("input.txt");

                reader.ReadDouble(out double a);
                reader.ReadDouble(out double b);
                reader.ReadDouble(out double c);
                Circle k = new(new Point(a, b), c);

                reader.ReadInt(out int n);
                Point[] x = new Point[n];
                for (int i = 0; i < n; ++i)
                {
                    reader.ReadDouble(out a);
                    reader.ReadDouble(out b);
                    x[i] = new Point(a, b);
                }

                // linsearch
                bool l = false;
                for (int i = 0; i < x.Length && !l; i++)
                {
                    l = k.Contains(x[i]);
                }
                if (l)
                {
                    Console.WriteLine("There is point in the circle.");
                }
                else
                {
                    Console.WriteLine("There is not any point in the circle.");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The file does not exist.");
            }
            catch (Circle.WrongRadiusException)
            {
                Console.WriteLine("The radius of the circle cannot be negative.");
            }
        }
    }
}
