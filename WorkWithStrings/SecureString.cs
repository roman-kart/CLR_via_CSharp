using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace WorkWithStrings
{
    internal class SecureStringTest
    {
        public static void Do()
        {
            SecureString secureString = new SecureString();
            foreach (var symbol in "qwerty12345")
            {
                secureString.AppendChar(symbol);
            }
        }
    }
}
