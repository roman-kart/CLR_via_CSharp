using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class StaticFieldsInit
    {
        public static int i = 5;
        static StaticFieldsInit()
        {
            i = 10;
        }
    }
}
