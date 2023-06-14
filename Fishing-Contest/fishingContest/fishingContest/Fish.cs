using System;
namespace fishingContest
{
	abstract class Fish
	{
		public abstract int Mult();

		public virtual bool isBream()
		{
			return false;
		}
        public virtual bool isCarp()
        {
            return false;
        }
        public virtual bool isCatfish()
        {
            return false;
        }
    }

    class Bream : Fish
    {
        private Bream() { }

        private static Bream? instance;

        public static Bream Instance()
        {
            if (instance == null) instance = new Bream();
            return instance;
        }

        public override int Mult()
        {
            return 2;
        }

        public override bool isBream()
        {
            return true;
        }
    }

    class Carp : Fish
    {
        private Carp() { }

        private static Carp? instance;

        public static Carp Instance()
        {
            if (instance == null) instance = new Carp();
            return instance;
        }

        public override int Mult()
        {
            return 1;
        }

        public override bool isCarp()
        {
            return true;
        }
    }

    class Catfish : Fish
    {
        private Catfish() { }

        private static Catfish? instance;

        public static Catfish Instance()
        {
            if (instance == null) instance = new Catfish();
            return instance;
        }

        public override int Mult()
        {
            return 3;
        }

        public override bool isCatfish()
        {
            return true;
        }
    }
}

