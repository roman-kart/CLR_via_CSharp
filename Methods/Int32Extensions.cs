using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal static class Int32Extensions
    {
        public static string GetString(this int i)
        {
            return i.ToString();
        }
    }
}
