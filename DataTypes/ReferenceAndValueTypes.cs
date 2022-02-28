using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DataTypes
{
    internal class ReferenceAndValueTypes
    {
        public static void Do()
        {
            System.Int32 v = 5;
            System.Object o = v;
            v = 123;
            Console.WriteLine(v + ", " + o);
        }
        [StructLayout(LayoutKind.Auto)]
        public struct SimpleStruct
        {
            public string Name;
            public string Value;
        }
    }
}
