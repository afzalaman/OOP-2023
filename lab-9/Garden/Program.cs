using System;

namespace Garden
{
    class Program
    {
        static void Main()
        {
            Garden garden = new (5);
            Gardener gardener = new (garden);

            gardener.Plant(1, Potatoe.Instance(), 3);
            gardener.Plant(3, Rose.Instance(), 3);
            gardener.Plant(2, Pea.Instance(), 3);
            gardener.Plant(4, Pea.Instance(), 3);

            Console.Write("Parcels to be harvested are: ");
            foreach (int i in gardener.garden.CanHarvest(6))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
