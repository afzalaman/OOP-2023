using System;
using System.Collections.Generic;
using System.Text;

namespace FunFair
{
    abstract class Prize
    {
        public Gallery Gallery { get; }
        public ISize Size { get; }
        public Prize(Gallery g, ISize s) { Gallery = g; Size = s; }

        public virtual int Value()
        {
            return Point() * Size.Mult();
        }
        public abstract int Point();

    }

    class Teddy : Prize
    {
        public Teddy(Gallery g, ISize s) : base(g, s) { }
        public override int Point() { return 3;}
    }

    class Doll : Prize
    {
        public Doll(Gallery g, ISize s) : base(g, s) { }
        public override int Point() { return 2; }
    }

    class Ball : Prize
    {
        public Ball(Gallery g, ISize s) : base(g, s) { }
        public override int Point() { return 1; }
    }
}
