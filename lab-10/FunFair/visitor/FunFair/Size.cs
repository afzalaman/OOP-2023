using System;
using System.Collections.Generic;
using System.Text;

namespace FunFair
{
    abstract class ISize
    {
        public abstract int Point(Ball p);
        public abstract int Point(Doll p);
        public abstract int Point(Teddy p);
    }

    class S : ISize
    {
        private static S? instance;
        private S() { }
        public static S Instance()
        {
            if (instance == null) instance = new S();
            return instance;
        }

        public override int Point(Ball p) { return 1 * 1; }
        public override int Point(Doll p) { return 2 * 1; }
        public override int Point(Teddy p) { return 3 * 1; }
    }

    class M : ISize
    {
        private static M? instance;
        private M() { }
        public static M Instance()
        {
            if (instance == null) instance = new M();
            return instance;
        }
        public override int Point(Ball p) { return 1 * 2; }
        public override int Point(Doll p) { return 2 * 2; }
        public override int Point(Teddy p) { return 3 * 2; }
    }

    class L : ISize
    {
        private static L? instance;
        private L() { }
        public static L Instance()
        {
            if (instance == null) instance = new L();
            return instance;
        }
        public override int Point(Ball p) { return 1 * 3; }
        public override int Point(Doll p) { return 2 * 3; }
        public override int Point(Teddy p) { return 3 * 3; }
    }

    class XL : ISize
    {
        private static XL? instance;
        private XL() { }
        public static XL Instance()
        {
            if (instance == null) instance = new XL();
            return instance;
        }
        public override int Point(Ball p) { return 1 * 4; }
        public override int Point(Doll p) { return 2 * 4; }
        public override int Point(Teddy p) { return 3 * 4; }
    }
}
