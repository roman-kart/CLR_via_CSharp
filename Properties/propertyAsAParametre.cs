using System;
using System.Collections.Generic;
using System.Text;

namespace Properties
{
    class propertyAsAParametre
    {
        public static void DoSomething(string str)
        {
            Console.WriteLine(str);
        }
        public static void DoSomethingRef(ref string str)
        {
            Console.WriteLine(str);
        }
    }
}
