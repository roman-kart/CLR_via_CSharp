using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography;

namespace WorkWithStrings
{
    internal class WorkWithStringInfo
    {
        public static void Do()
        {
            string sourceStr = " اِنفِجَار";
            Console.WriteLine(sourceStr.Length); // в первом случае будет 10 символов, так как в этом слове есть символы-заменители
            StringInfo stringInfo = new StringInfo(sourceStr);
            Console.WriteLine(stringInfo.LengthInTextElements); // во втором случае будет уже 7 символов,
                                                                // так как символы заменители, которые нужны для отображения другого символа, не учитываются
        }
    }
}
