using System;
using System.Collections.Generic;
using System.Text;

namespace FunFair
{
    class Guest
    {
        public string Name { get; }
        public List<Prize> Prizes { get; }

        public Guest(string name) { Name = name; Prizes = new List<Prize>(); }

        public void Win(Prize prize)
        {
            Prizes.Add(prize);
        }
        public int Result(Gallery g)
        {
            int s = 0;
            foreach (Prize p in Prizes)
            {
                if (p.Gallery == g)
                {
                    s += p.Value();
                }
            }
            return s;
        }
    }
}
