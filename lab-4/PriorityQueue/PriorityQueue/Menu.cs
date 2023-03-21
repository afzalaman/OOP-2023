using System;

namespace PriorityQueue
{
    class Menu
    {
        private readonly PrQueue pq = new ();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1:
                        PutIn();
                        Write();
                        break;
                    case 2:
                        RemoveMax();
                        Write();
                        break;
                    case 3:
                        GetMax();
                        Write();
                        break;
                    case 4:
                        CheckEmpty();
                        Write();
                        break;
                    case 5:
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nBye!");
                        break;

                }
            } while (v != 0);
        }
        private static int GetMenuPoint()
        {
            int v;
            Console.WriteLine("\n********************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. RemMax");
            Console.WriteLine("3. GetMax");
            Console.WriteLine("4. IsEmpty");
            Console.WriteLine("5. Print");
            Console.WriteLine("****************************************");

            v = int.Parse(Console.ReadLine());

            return v;
        }
        private void PutIn()
        {
            Item e = new ();
            Console.WriteLine("What shall I add?");
            e.Read();
            pq.Add(e);
        }
        private void RemoveMax()
        {
            Item e;
            try
            {
                e = pq.RemMax();
                Console.WriteLine("Taken element:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Error: The queue is empty!\n");
            }
        }
        private void GetMax()
        {
            Item e;
            try
            {
                e = pq.GetMax();
                Console.WriteLine("Maximal element:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Error: The queue is empty!\n");
            }
        }
        private void CheckEmpty()
        {
            if (pq.IsEmpty())
                Console.WriteLine("The queue IS empty!\n");
            else
                Console.WriteLine("The queue is NOT empty!\n");
        }
        private void Write()
        {
            pq.Write();
        }

    }
}
