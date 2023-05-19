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

        public abstract int Value();

    }

    class Teddy : Prize
    {
        public Teddy(Gallery g, ISize s) : base(g, s) { }
        public override int Value() { return Size.Point(this);}
    }

    class Doll : Prize
    {
        public Doll(Gallery g, ISize s) : base(g, s) { }
        public override int Value() { return Size.Point(this); }
    }

    class Ball : Prize
    {
        public Ball(Gallery g, ISize s) : base(g, s) { }
        public override int Value() { return Size.Point(this); }
    }
}
