using System;
using TextFile;

namespace StarWars
{
    class Program
    {
        static void Main()
        {
            SolarSystem ss = SolarSystem.Instance();
            try 
            {
                TextFileReader reader = new ("input.txt");

                reader.ReadInt(out int n);
                for (int i = 0; i < n; ++i)
                {
                    reader.ReadString(out string planetname); 
                    reader.ReadInt(out int m);
                    Planet planet = new (planetname);
                    for (int j = 0; j < m; ++j)
                    {
                        reader.ReadString(out string shipname);
                        reader.ReadString(out string type);
                        reader.ReadInt(out int s);
                        reader.ReadInt(out int a);
                        reader.ReadInt(out int g);

                        StarShip ship = null;
                        if (type == "Destroyer") ship = new Destroyer(shipname, s, a, g);
                        else if (type == "Transport") ship = new Transport(shipname, s, a, g);
                        else if (type == "Ironclad") ship = new Ironclad(shipname, s, a, g);
                        if (ship != null)
                            ship.Protect(planet);
                    }
                    ss.Planets.Add(planet);
                }

                if (ss.MaxPowerShip(out StarShip starship)) Console.WriteLine(starship.Name);
                else Console.WriteLine("There is no planet with starships.");

                Console.WriteLine($"shield of Earth: {ss.Planets[0].TotalShield()}");

                Console.WriteLine($"{ss.Unprotected().Name} is defensless.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Wrong file name.");
            }
        }
    }
}
