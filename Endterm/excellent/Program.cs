using ZH_Parlament;
using TextFile;

namespace ZH_Parlament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Party> parties = new List<Party>();
            List<Congressman> cmen = new List<Congressman>();
            TextFileReader reader = new TextFileReader("input.txt");

            string str = reader.ReadLine();
            string[] tokens = str.Split(new char[] { ' ' });
            for (int i = 0; i < tokens.Length; i += 2)
            {
                cmen.Add(new Congressman(tokens[i] + " " + tokens[i + 1]));
            }
            Parliament p = new Parliament(cmen);

            str = reader.ReadLine();
            tokens = str.Split(new char[] { ' ' });
            for (int i = 0; i < tokens.Length; i++)
            {
                parties.Add(new Party(tokens[i], p));
            }

            str = reader.ReadLine();
            tokens = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i+=3)
            {
                string name = tokens[i]+" " + tokens[i+1];
                string party = tokens[i + 2];
                foreach(Congressman k in cmen)
                {
                    if (k.name==name)
                    {
                        foreach(Party pa in parties)
                        {
                            if (pa.name==party)
                            {
                                k.Enter(pa);
                                break;
                            }
                        }
                    }
                }
            }

            str = reader.ReadLine();
            tokens = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i += 2)
            {
                string name = tokens[i] + " " + tokens[i + 1];
                foreach (Congressman k in cmen)
                {
                    if (k.name == name)
                    {
                        k.Leave();
                        break;
                    }
                }
            }

            while (reader.ReadLine(out str))
            {
                tokens = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                    default: break;
                }
                if (t != null)
                {
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
            }
            List<string> list = p.ValidLaws();
            foreach (var s in list)
            {
                Console.Write(s+" ");
            }
            if (list.Count == 0)
                Console.WriteLine("none");
            else Console.WriteLine();

            Console.WriteLine(p.AbstainCount());
            p.Reject();
            foreach(DraftLaw t in p.laws)
            {
                Console.Write(t.ID+" ");
            }
            if (p.laws.Count == 0)
                Console.WriteLine("none");
            else Console.WriteLine();
            if (p.AbstainParty())
                Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}