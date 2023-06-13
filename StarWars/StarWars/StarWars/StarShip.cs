using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    abstract class StarShip
    {
        public string Name { get; }
        public int Shield { get; }
        public int Armor { get; }
        public int SpaceGuard { get; }
        public Planet Planet { get; private set; }
        public StarShip(string name, int shield, int armor, int guard)
        {
            Name = name; Shield = shield; Armor = armor; SpaceGuard = guard;
        }
        public void Protect(Planet planet)
        {
            if (Planet != null) return;
            Planet = planet;
            planet.Protect(this);
        }
        public void Leave()
        {
            if (Planet == null) return;
            Planet = null;
            Planet.Leave(this);
        }
        public abstract int Power();
    }

    class Destroyer : StarShip
    {
        public Destroyer(string name, int shield, int armor, int guard) : base(name, shield, armor, guard) { }
        public override int Power()
        {
            return Shield / 2;
        }
    }

    class Transport : StarShip
    {
        public Transport(string name, int shield, int armor, int guard) : base(name, shield, armor, guard) { }
        public override int Power()
        {
            return SpaceGuard;
        }
    }

    class Ironclad : StarShip
    {
        public Ironclad(string name, int shield, int armor, int guard) : base(name, shield, armor, guard) { }
        public override int Power()
        {
            return Armor;
        }
    }
}
