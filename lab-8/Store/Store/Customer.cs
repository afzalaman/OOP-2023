using System;
using System.Collections.Generic;
using TextFile;

namespace Customer
{
    class Customer
    {
        public string Name { get; }
        private readonly List<string> list = new();
        public List<Product> cart = new();

        public Customer(string filename)
        {
            TextFileReader reader = new (filename);
            reader.ReadString(out string str);
            Name = str;
            while(reader.ReadString(out str))
            {
                list.Add(str);
            }
        }

        public void Purchase(Store store)
        {
            Console.WriteLine($"{Name} has bought the following products: ");

            foreach (string productName in list)
            {
                if (LinSearch(productName, store.foods, out Product product))
                {
                    Drag(product, ref store.foods);
                    Console.WriteLine($"{product.Name} {product.Price}");
                }
            }
            foreach (string productName in list)
            {
                if (MinSearch(productName, store.technical, out Product product))
                {
                    Drag(product, ref store.technical);
                    Console.WriteLine($"{product.Name} {product.Price}");
                }
            }
        }

        private void Drag(Product product, ref Department department)
        {
            department.stock.Remove(product); 
            cart.Add(product);
        }

        private static bool LinSearch(string name, Department d, out Product product)
        {
            bool l = false;
            product = null;
            foreach (Product p in d.stock)
            {
                if ((l = (p.Name == name)))
                {
                    product = p; break;
                }
            }
            return l;
        }

        private static bool MinSearch(string name, Department d, out Product product)
        {
            bool l = false;
            product = null;
            double min = 0;
            foreach (Product p in d.stock)
            {
                if (p.Name != name) continue;
                if (l)
                {
                    if (min > p.Price)
                    {
                        min = p.Price;
                        product = p;
                    }
                }
                else
                {
                    l = true;
                    min = p.Price;
                    product = p;
                }
            }
            return l;
        }
    }
}
