namespace Garden
{
    abstract class Plant
    {
        public int RipeningTime { get;}

        protected Plant(int i) { RipeningTime = i; }

        public virtual bool IsVegetable() { return false; }
        public virtual bool IsFlower() { return false; }
    }

    abstract class Vegetable : Plant
    {
        protected Vegetable(int i) : base(i) {  }
        public override bool IsVegetable()  { return true;}

    }

    abstract class Flower : Plant
    {
        protected Flower(int i) : base(i) { }
        public override bool IsFlower() { return true; }
    }

    class Potatoe : Vegetable
    {
        private Potatoe() : base(5) { }

        private static Potatoe instance;

        public static Potatoe Instance()
        {
            if (null == instance) instance = new Potatoe();
            return instance;
        }
    }
    class Pea : Vegetable
    {
        private Pea() : base(3) { }

        private static Pea instance;
        public static Pea Instance()
        {
            if (null == instance) instance = new Pea();
            return instance;
        }
    }
    class Onion : Vegetable
    {
        private Onion() : base(4) { }
        private static Onion instance;
        public static Onion Instance()
        {
            if (null == instance) instance = new Onion();
            return instance;
        }
    }
    class Rose : Flower
    {
        private Rose() : base(8) { }
        private static Rose instance;
        public static Rose Instance()
        {
            if (null == instance) instance = new Rose();
            return instance;
        }
    }
    class Carnation : Flower
    {
        private Carnation() : base(10) { }
        private static Carnation instance;
        public static Carnation Instance()
        {
            if (null == instance) instance = new Carnation();
            return instance;
        }
    }
    class Tulip : Flower
    {
        private Tulip() : base(7) { }
        private static Tulip instance;
        public static Tulip Instance()
        {
            if (null == instance) instance = new Tulip();
            return instance;
        }
    }
}
