namespace LowerTriangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            LTMatrix a = new LTMatrix();
            LTMatrix b = new LTMatrix();
            LTMatrix c = new LTMatrix(2);
            Console.WriteLine($"a:\n{a}\n\n");
            Console.WriteLine($"b:\n{b}\n");
            Console.WriteLine($"a[2,3]= {a.GetElement(1, 2)}\n");
            Console.WriteLine($"a[3,2]= {a.GetElement(2, 1)}\n\n");
            Console.WriteLine($"a+b:\n{LTMatrix.Add(a, b)}\n\n");
            Console.WriteLine($"a*b:\n{LTMatrix.Multiply(a, b)}\n\n");

            LTMatrix d = new LTMatrix("input.txt");
            Console.WriteLine($"d:\n{d}\n\n");
            try
            {
                LTMatrix e = new LTMatrix("wrong_length.txt");
                Console.WriteLine($"e:\n{e}\n\n");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The file does not exist.");
            }
            catch (LTMatrix.InvalidVectorException ex)
            {
                Console.WriteLine("invalid vector length: exception caught\n\n");
            }


            try
            {
                Console.WriteLine($"invalid sum:");
                Console.WriteLine(LTMatrix.Add(c, a)+"\n\n");
            }
            catch (LTMatrix.DimensionMismatchException ex)
            {
                Console.WriteLine("exception caught\n\n");
            }
            try
            {
                Console.WriteLine($"invalid mul:");
                Console.WriteLine(LTMatrix.Multiply(c, b) + "\n\n");
            }
            catch (LTMatrix.DimensionMismatchException ex)
            {
                Console.WriteLine("exception caught\n\n");
            }
            try
            {
                Console.WriteLine($"invalid vector length:");
                a.SetVec(new List<int>(){2,3,4,5});
            }
            catch (LTMatrix.InvalidVectorException ex)
            {
                Console.WriteLine("exception caught\n\n");
            }
        }
    }
}