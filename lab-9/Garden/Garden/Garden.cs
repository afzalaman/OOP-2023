using System;
using System.Collections.Generic;

namespace Garden
{
    class Garden
    {
        public class WrongParcelNumberException : Exception { };

        private readonly List<Parcel> parcels;
        //garden[2]
        public Parcel this[int i]
        {
            get
            {
                if (0 <= i && i < parcels.Count) return parcels[i];
                else throw new WrongParcelNumberException();
            }
        }
        
        public Garden(int n) 
        {
            if (n <= 0) throw new WrongParcelNumberException();
            parcels = new List<Parcel>();
            for (int i = 0; i < n; ++i) parcels.Add(new Parcel());
        }

 
        public List<int> CanHarvest(int date)
        {
            List<int> result = new ();
            foreach (Parcel p in parcels)
            {
                if (null != p.Content && p.Content.IsVegetable() && date - p.PlantingDate == p.Content.RipeningTime)
                {
                    result.Add(p.Number);
                }    
            }
            return result;
        }
    }
}
