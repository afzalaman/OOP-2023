using ZH_Parlament;
using TextFile;

namespace ZH_Parlament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Congressman> cmen = new List<Congressman>();
            TextFileReader reader = new TextFileReader("input.txt");
            string str = reader.ReadLine();
            string[] tokens = str.Split(new char[] { ' ' });
            for (int i = 0; i < tokens.Length; i += 2)
            {
                cmen.Add(new Congressman(tokens[i] + " " + tokens[i + 1]));
            }
            Parliament p = new Parliament(cmen);
            while (reader.ReadLine(out str))
            {
                tokens = str.Split(new char[] { ' ' });
                DraftLaw? t = null;
                switch (tokens[0])
                {
                    case "Normal":
                        t = new Normal(tokens[2], tokens[1]);
                        break;
                    case "Cardinal":
                        t = new Cardinal(tokens[2], tokens[1]);
                        break;
                    case "Constitutional":
                        t = new Constitutional(tokens[2], tokens[1]);
                        break;
                    default:  break;
                }
                p.Submit(t);
                for (int i = 3; i < tokens.Length; i++)
                {
                    switch (tokens[i])
                    {
                        case "yes":
                            cmen[i - 3].Vote(true, t.ID);
                            break;
                        case "no":
                            cmen[i - 3].Vote(false, t.ID);
                            break;
                        default: break;
                    }
                }
            }
            List<string> list = p.ValidLaws();
            foreach (var s in list)
            {
                Console.Write(s+" ");
            }
            if (list.Count == 0)
                Console.Write("none");
        }
    }
}