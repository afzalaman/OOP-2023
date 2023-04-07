namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Number of occurrences of numbers ---\n\n");
            bool fileError = true;
            do
            {
                try
                {
                    //Console.Write("File's name: ");
                    string fileName = "input.txt";
                    //fileName = Console.ReadLine();
                    Infile t = new(fileName);

                    for (t.First(); !t.End(); t.Next())
                    {
                        Console.WriteLine($"Number: {t.Current().number} occurrence: {t.Current().count}");
                    }
                    fileError = false;
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("File not found!\n\n");
                }
            } while (fileError);

        }
    }
}