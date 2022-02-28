using System;
using System.Collections.Generic;
using System.Text;

namespace Methods
{
    class Product
    {
        public string Name;
        public DateTime DateTime;
        public MyStruct MyStruct;
        public Product() { }
        public Product(string name)
        {
            Name = name;
        }
    }
}
