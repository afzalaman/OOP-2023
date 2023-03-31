using System.IO;
using System.Linq.Expressions;
using TextFile;

/** Calculate the average of daily temperatures
stored in a sequential input file.
a.) before the first temperature under the freezing point.
b.) after the first temperature under the freezing point.
c.) before and after the first temperature under the freezing point where in the after version the first freezing temperature is included, too.
*/

namespace SeqInFile
{
    internal class Program
    {
        public enum Status { norm, abnorm };

        public static void read(ref Status st, ref int e, ref TextFileReader f) // st,e,x:read
        {

            if (!f.ReadInt(out e))
            {
                st = Status.abnorm;
            }
            else
            {
                st = Status.norm;
            }
            //st = (!f.ReadInt(out e)) ? Status.abnorm : Status.norm;
        }

      
        public static void MenuPrint()
        {
            Console.WriteLine("\n0. Exit\n");
            Console.WriteLine("1. Average of file before the first freezing point\n");
            Console.WriteLine("2. Average of file after the first freezing point\n");
            Console.WriteLine("3. Average of file before and after (including) the first freezing point\n");
            Console.Write("Choose: ");
        }

        public static string ReadFileName()
        {
            //Console.WriteLine("Input file's name: ");
            //string fileName;
            //fileName = Console.ReadLine()!;
            //return fileName;
            return "input.txt";
        }

        public static void Execute(int n, TextFileReader f)
        {
            switch (n)
            {
                case 1:
                    Console.WriteLine(Average(f).ToString());
                    break;
                case 2:
                    Console.WriteLine(AvgAfterFreezing(f).ToString());
                    break;
                case 3:
                    Tuple<double, double> result = AvgBeforeAndAfterFreezing(f);
                    Console.WriteLine($"{result.Item1} {result.Item2}");
                    break;
            }
        }

        public static double Average(TextFileReader x)
        {
            double s = 0;
            int c = 0;
            Status st = Status.norm;
            int e = 0;
            read(ref st, ref e, ref x);
            while (e >= 0 && st == Status.norm)
            {
                s += e;
                ++c;
                read(ref st, ref e, ref x);
            }

            return (c==0)?0:s/c;
        }

        public static double AvgAfterFreezing(TextFileReader x)
        {
            Status st = Status.norm;
            int e = 0;
            read(ref st, ref e, ref x);
            while (e >= 0 && st == Status.norm)
            {
                read(ref st, ref e, ref x);
            }
            double s = 0;
            int c = 0;
            read(ref st, ref e, ref x);
            while (st == Status.norm)
            {
                s += e;
                ++c;
                read(ref st, ref e, ref x);
            }
           
            return (c==0)?0:s/c;
        }

        public static Tuple<double, double> AvgBeforeAndAfterFreezing(TextFileReader x)
        {
            Status st = Status.norm;
            int e = 0;
            double s1 = 0;
            int c1 = 0;
            read(ref st, ref e, ref x);
            while (e >= 0 && st == Status.norm)
            {
                s1 += e;
                ++c1;
                read(ref st, ref e, ref x);
            }
            double item1 = (c1 == 0) ? 0 : s1 / c1;

            double s2 = 0;
            int c2 = 0;
            while (st == Status.norm)
            {
                s2 += e;
                ++c2;
                read(ref st, ref e, ref x);
            }

            return new Tuple<double, double>(item1, (c2 == 0) ? 0 : s2 / c2);
        }

        static void Main(string[] args)
        {
            int menuItem = 5; /// if it is not set and wrong file name is given for the first time, the program terminates
            do
            {
                MenuPrint();
                menuItem = int.Parse(Console.ReadLine()!);
                if (menuItem > 0 && menuItem < 4)
                {
                    try
                    {
                        TextFileReader file=new(ReadFileName());
                        Execute(menuItem, file);
                    }
                    catch
                    {
                        Console.WriteLine("Wrong file name!");
                    }
                }
            } while (menuItem != 0);
        }
    }
}