using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantsAndFields
{
    internal class Constants
    {
        // public const List<int> ints = new List<int>(); // Excption, так как в качестве константы может быть только примитивный тип
        // public const MyReadonlyStruc myReadonlyStruc = new MyReadonlyStruc("Adasd"); // Excption, так как в качестве константы может быть только примитивный тип
        // public static const int i = 12; // Exception, так как константа не может быть static
        public const int i = 12; // можно, так как примитивный тип
        public const string str = "Aasdasd"; // можно, так как примитивный тип
        public const List<int> NullValue = null; // можно, так как присваивается значение null
    }
    internal readonly struct MyReadonlyStruc
    {
        public readonly string Name;
        public MyReadonlyStruc(string name)
        {
            Name = name;
        }
    }
}
