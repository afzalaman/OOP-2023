using System;
using System.Collections.Generic;
using System.Text;
using TextFile;

namespace Customer
{
    class Department
    {
        public List<Product> stock = new ();
        public Department(string filename)
        {
            TextFileReader reader = new (filename);
            reader.ReadString(out string str);
            while(reader.ReadDouble(out double i))
            {
                stock.Add(new Product(str, i));
                reader.ReadString(out str);
            }
        }

    }
}
