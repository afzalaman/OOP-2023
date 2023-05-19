using System;
using System.Collections.Generic;
using System.Text;

namespace FunFair
{
    interface ISize
    {
        int Mult();
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

        public int Mult() {return 1;}
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
        public int Mult() { return 2; }
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
        public int Mult() { return 3; }
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
        public int Mult() { return 4; }
    }
}
