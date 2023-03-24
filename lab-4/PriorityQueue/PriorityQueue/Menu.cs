using System;

namespace PriorityQueue
{
    class Menu
    {
        private PrQueue pq = new PrQueue();

        private static int GetMenuInput()
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

        public void Run()
        {
            int v;
            do
            {
                v = GetMenuInput();
                switch (v)
                {
                    case 0:
                        Console.WriteLine("\nBye!");
                        break;
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
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            } while (v != 0);
        }
        
        private void PutIn()
        {
            Item e = new();
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
                Console.WriteLine($"Taken element:\n {e}");
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
                Console.WriteLine($"Maximal element:\n \n {e}");
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
        private void Write() //print
        {
            pq.Write();
        }

    }
}
