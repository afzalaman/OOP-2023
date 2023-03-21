using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class Item
    {
        public int pr;
        public string data;

        public Item() { }
        public Item(int p, string str)
        {
            pr = p;
            data = str;
        }

        public override string ToString()
        {
            return "("+pr.ToString()+", "+"data"+")";
        }

        public void Read()
        {
            Console.WriteLine("Data: ");
            data = Console.ReadLine();
            Console.WriteLine("Priority: ");
            pr = int.Parse(Console.ReadLine());
        }
    }
    public class PrQueue
    {
        private readonly List<Item> seq = new ();  
        public class PrQueueEmpty : Exception{}

        public void Add(Item a)
        {
            seq.Add(a);
        }
        public Item RemMax() 
        {
            if (seq.Count == 0) throw new PrQueueEmpty();
            int ind = MaxIndex();
            Item best = seq[ind];
            seq.RemoveAt(ind);
            return best;
        }
        public Item GetMax()   
        {
            if (seq.Count == 0) throw new PrQueueEmpty();
            int ind = MaxIndex();
            return seq[ind];
        }
        public bool IsEmpty()  
        { 
            return seq.Count == 0; 
        }

        public int GetLength() {return seq.Count;}

        public void Write()
        {
            foreach(Item e in seq)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private int MaxIndex() 
        {
            int ind = 0;
            int maxkey = seq[0].pr;
            for ( int i = 1; i < seq.Count; ++i)
            {
                if (seq[i].pr > maxkey)
                {
                    ind = i;
                    maxkey = seq[i].pr;
                }
            }
            return ind;
        }
    }
}
