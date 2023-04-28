using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    class Product
    {
        public Product(string str, double n)
        {
            Name = str; Price = n;
        }
        public string Name { get; }
        public double Price { get; }
    }
}
