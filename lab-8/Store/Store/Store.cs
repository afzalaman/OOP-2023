using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    class Store
    {
        public Department foods;
        public Department technical;

        public Store(string fname, string tname)
        {
            foods = new Department(fname);
            technical = new Department(tname);
        }
    }
}
