namespace grade5;
class Program
{

    static void Main(string[] args)
    {
        try
        {
            Semester sem = new("input.txt");
            sem.First();

            string name = sem.Current().semester;
            int totalHours = sem.Current().th;

            for (; !sem.End(); sem.Next())
            {
                if (sem.Current().th < totalHours)
                {
                    name = sem.Current().semester;
                    totalHours = sem.Current().th;
                }
            }

            //while (!sem.End())
            //{
            //    if (sem.Current().th < totalHours)
            //    {
            //        name = sem.Current().semester;
            //        totalHours = sem.Current().th;
            //    }
            //    sem.Next();
            //}
            Console.WriteLine(name);

        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("File not Found!");
        }


    }
}

