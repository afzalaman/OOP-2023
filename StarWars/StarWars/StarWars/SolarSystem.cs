using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    class SolarSystem
    {
        private SolarSystem() { Planets = new List<Planet>(); }
        private static SolarSystem instance = null;
        public static SolarSystem Instance() 
        {
            if (null == instance) instance = new SolarSystem(); 
            return instance;
        }
        public List<Planet> Planets { get; }

        public bool MaxPowerShip(out StarShip bestship)
        {
            bool l = false;
            double maxpower = 0;
            bestship = null; ;
            foreach (Planet e in Planets)
            {
                bool ll = e.MaxPower(out double power, out StarShip ship);
                if (!ll) continue;
                if (!l) { l = true; maxpower = power; bestship = ship; }
                else
                {
                    if (maxpower < power) { maxpower = power; bestship = ship; }
                }
            }
            return l;
        }

        public Planet Unprotected()
        {
            foreach (Planet e in Planets)
            {
                if (0 == e.ShipCount()) return e;
            }
            return null;
        }


    }
}
