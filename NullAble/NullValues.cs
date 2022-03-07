using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NullAble
{
    internal class NullValues
    {
        public static int? GetNullAble()
        {
            int? result = RandomNumberGenerator.GetInt32(-10, 30);
            result = result % 2 == 0 ? null : result;
            return result;
        }
        public static void ChangeIntObj(ref Object obj)
        {
            obj = 102342142;
        }
        public static void ChangeIntObj(Object obj)
        {
            obj = 102342142;
        }
    }
}
