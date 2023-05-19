using System;

namespace FunFair
{
    class Program
    {
        static void Main()
        {
            Gallery g1 = new ("Water");
            Gallery g2 = new ("Air");

            Prize p1 = new Ball(g1, S.Instance());
            Prize p2 = new Ball(g1, M.Instance());
            Prize p3 = new Teddy(g2, XL.Instance());
            Prize p4 = new Doll(g2, L.Instance());
            Prize p5 = new Doll(g2, L.Instance());

            Guest v1 = new ("Johnny");
            Guest v2 = new ("Jackie");
            g1.Register(v1); g1.Register(v2);
            g2.Register(v1); g2.Register(v2);

            v1.Win(p1);
            v2.Win(p2);
            v1.Win(p3);
            v2.Win(p4);
            v2.Win(p5);

            Console.WriteLine($"In Gallery {g1.Location} {g1.Best()} was the best.");
            Console.WriteLine($"In Gallery {g2.Location} {g2.Best()} was the best.");

        }
    }
}
