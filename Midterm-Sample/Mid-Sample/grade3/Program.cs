using TextFile;
namespace grade3;
class Program
{
    public struct Database
    {
        public string semester;
        public string neptun;
        public int th;

        public Database()
        {
            semester = "";
            neptun = "";
            th = 0;
        }
    }

    public enum Status { norm, abnorm }

    public static void read(ref Status st, ref Database e, ref TextFileReader f)
    {
        if (!(f.ReadString(out e.semester) && f.ReadString(out e.neptun) && f.ReadInt(out e.th)))
        {
            st = Status.abnorm;
        }
        else
        {
            st = Status.norm;
        }
    }

    public static int numberOfTimes(TextFileReader x)
    {
        int count = 0;
        Status st = Status.norm;
        Database e = new();
        read(ref st, ref e, ref x);
        while (st == Status.norm && !(e.neptun == "gfhdjs" && e.th > 15))
        {
            read(ref st, ref e, ref x);
        }
        read(ref st, ref e, ref x);
        while (st == Status.norm)
        {
            if (e.neptun == "gfhdjs" && e.th < 12)
            {
                count++;
            }
            read(ref st, ref e, ref x);
        }
        return count;

    }
    static void Main(string[] args)
    {
        try
        {
            TextFileReader file = new("input.txt");
            Console.WriteLine(numberOfTimes(file));
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
    }
}

