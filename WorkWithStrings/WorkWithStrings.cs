using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithStrings
{
    internal class WorkWithStrings
    {
        public static void Do()
        {
            // comparison
            string str1 = "Hello!";
            string str2 = "hello!";
            Console.WriteLine($"\"{str1}\" == \"{str2}\" (ignoring case)? Result: {String.Equals(str1, str2, StringComparison.CurrentCultureIgnoreCase)}");
            ShowCompareResult(str1, str2, String.Compare(str1, str2, StringComparison.CurrentCultureIgnoreCase), "compare", "ignoring case");
            ShowCompareResult(str1, str2, String.Compare(str1, str2, true, System.Globalization.CultureInfo.InstalledUICulture), "compare", "ignoring case, CultureInfo.InstalledUICulture");
            ShowCompareResult(str1, str2, String.Compare(str1, str2, false, System.Globalization.CultureInfo.InstalledUICulture), "compare", "not ignoring case, CultureInfo.InstalledUICulture");

            // start with and end with
            ShowCompareResult(str1, "f", str1.StartsWith('f'), "start with", "");
            ShowCompareResult(str1, "hel", str1.StartsWith("hel"), "start with", "not ingnoring case");
            ShowCompareResult(str1, "hel", str1.StartsWith("hel", StringComparison.CurrentCultureIgnoreCase), "start with", "ingnoring case, current culture");

            ShowCompareResult(str1, "ELLO!", str1.EndsWith("ELLO!", StringComparison.CurrentCultureIgnoreCase), "end with", "ingnoring case, current culture");
            ShowCompareResult(str1, "ELLO!", str1.EndsWith("ELLO!"), "end with", "not ingnoring case");
        }
        private static void ShowCompareResult<TVal, TResult>(TVal val1, TVal val2, TResult result, string operation, string addition)
        {
            Console.WriteLine($"\"{val1}\" {operation} \"{val2}\" ({addition})? Result: {result}");
        }
    }
}
