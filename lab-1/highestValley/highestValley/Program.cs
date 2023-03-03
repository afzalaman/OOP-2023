using TextFile;

namespace highestValley
{
    class Program
    {

        private static bool fileRead(out List<int> vec,in String fileName)
        {
            vec = new List<int>();
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                while (f.ReadInt(out int e))
                {
                    vec.Add(e);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool condMaxSearch(in List<int> x, out int max, out int ind)
        {
            bool l = false;
            max = 0;
            ind = 0;
            for (int i = 1; i < x.Count - 1; i++) 
            {
                if (l && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    if (max < x[i])
                    {
                        max = x[i];
                        ind = i;
                    }
                }
           
                else if (!l && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    l = true;
                    max = x[i];
                    ind = i;
                }
            }
            return l;
        }

        private static bool condMaxSearchFromFile(in String fileName, out int max)
        {
            max = 0;
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                bool l = false;
                int before;
                int current;
                int after;
                f.ReadInt(out before);
                f.ReadInt(out current);
                //f.ReadInt(out after);//this is a mistake, thanks for pointing it out.
                //actually the "after" is initialised later as a condition of
                //the while loop, if we do it here as well then we are skipping a value in each iteration. 
                while (f.ReadInt(out after))
                {
                    //Console.WriteLine($"{before} - {current} - {after}");
                    if (l && current <= before && current <= after)
                    {
                        if (max < current)
                        {
                            max = current;
                        }
                    }
                    else if (!l && current <= before && current <= after)
                    {
                        l = true;
                        max = current;
                    }
                    before = current;
                    current = after;
                }
                return l;
            }
            catch
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("File's name: ");
            string fileName = Console.ReadLine();
            List<int> vec = new List<int>();
            if (fileRead(out vec, in fileName))
            {
                int max, ind;
                if (condMaxSearch(vec, out max, out ind))
                {
                    Console.WriteLine($"Highest valley from the first function is {max} high.");
                    //Console.WriteLine("Highest valley from the first function is " +max+" high.");
                }
                else
                {
                    Console.WriteLine($"There is no valley.");
                }

                if (condMaxSearchFromFile(fileName, out max)) ///it is sure that the file exists
                {
                    Console.WriteLine($"Highest valley from the second function is {max} high");
                    //Console.WriteLine("Highest valley from the first function is " +max+" high.");
                }
                else
                {
                    Console.WriteLine("There is no valley.");
                }

            }
            else
            {
                Console.WriteLine("Wrong file name!");
            }
        }
    }
}