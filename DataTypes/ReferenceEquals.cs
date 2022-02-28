using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class ReferenceEqualsTest
    {
        public static void Do()
        {
            // int refEq
            int i1 = 5;
            int i2 = 5;
            Console.WriteLine(Object.ReferenceEquals(i1, i2));

            // string refEq
            string s1 = "Hey";
            string s2 = "Hey";
            Console.WriteLine(Object.ReferenceEquals(s1, s2));
            Console.WriteLine(Object.ReferenceEquals("Hey", s2));
            Console.WriteLine(Object.ReferenceEquals("Hey", "Hey"));

            // dynamic
            dynamic d = 10;
            object o = d;
            dynamic dd = o;

            Console.WriteLine(++d);
            // Console.WriteLine(o++); //Exception
            Console.WriteLine(++dd);

            int iii = d;
            Console.WriteLine(iii);
            d++;
            d++;
            d++;
            d++;

            iii = d;
            Console.WriteLine(iii);
        }
    }
}
