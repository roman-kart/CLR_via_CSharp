using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkWithStrings
{
    internal class WorkWithStringParse
    {
        public static void Do()
        {
            try
            {
                var parsed = Decimal.Parse("1,000,0000", NumberStyles.AllowThousands, CultureInfo.GetCultureInfo("en-US"));
                Console.WriteLine(parsed);

                parsed = Decimal.Parse("123.908", NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"));
                Console.WriteLine(parsed);

                parsed = Decimal.Parse("  123,908,098.109", NumberStyles.AllowThousands | NumberStyles.AllowLeadingWhite | NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"));
                Console.WriteLine(parsed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
