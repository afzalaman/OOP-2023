using System;
using TextFile;
namespace fishingContest;
class Program
{
    static void Main(string[] args)
    {
        Club club = new();

        try
        {
            TextFileReader reader = new("contests.txt");
            reader.ReadLine(out string line);

            string[] tokens = line.Split(' ');

            for (int i = 0; i < tokens.Length; i++)
            {
                club.Enter(tokens[i]);
            }

            while (reader.ReadString(out string filename))
            {
                TextFileReader reader1 = new(filename);
                reader1.ReadLine(out string contestName);

                Contest contest = club.Organize(contestName);

                while (reader1.ReadString(out string anglerName))
                {
                    reader1.ReadString(out string fishName);
                    reader1.ReadDouble(out double weight);

                    Angler angler = club.IsMember(anglerName);
                    //Console.WriteLine(angler.name);
                    if (null == angler)
                    {
                        Console.WriteLine($"{anglerName} is not a member");
                    }
                    else
                    {
                        contest.Register(anglerName);

                        //Console.WriteLine(fishName);
                        if (fishName == "bream")
                        {
                            //Console.WriteLine("yes");
                            angler.Catch(Bream.Instance(), weight, contest);
                        }
                        else if (fishName == "carp") angler.Catch(Carp.Instance(), weight, contest);
                        else if (fishName == "catfish") angler.Catch(Catfish.Instance(), weight, contest);

                    }
                }

            }
            //Task1
            Tuple<int,double> task1 = club.catfishes("Johnny", "Doborgaz");
            Console.WriteLine($"Number of Catfish = {task1.Item1} Value = {task1.Item2}");


            //Task2

            if(club.Best().Item1)
            {
                Console.WriteLine($"The best Contest is {club.Best().Item2.location}");
            }
            else
            {
                Console.WriteLine("NO SUCH CONTEST");
            }

        }
        catch(System.IO.FileNotFoundException)
        {
            Console.WriteLine("FILE ERROR");
        }

    }
}