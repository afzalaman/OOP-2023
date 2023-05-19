using System;
using System.Collections.Generic;
using System.Text;

namespace FunFair
{
    class Gallery
    {
        public class NoGuestException : Exception { }

        public string Location { get; }
        public List<Guest> Guests { get; }
        public Gallery(string location) { Location = location; Guests = new List<Guest>(); }
        public static void Present() { }
        public void Register(Guest guest) { Guests.Add(guest); }
        public string Best()
        {
            if (Guests.Count  == 0) throw new NoGuestException();

            int max = Guests[0].Result(this);
            Guest elem = Guests[0];
            foreach (Guest e in Guests)
            {
                int p = e.Result(this);
                if (p > max)
                {
                    max = p; elem = e;
                }
            }
            return elem.Name;
        }
    }
}
