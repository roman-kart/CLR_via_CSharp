using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

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

            var cultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.NeutralCultures);
            foreach (var culture in cultures)
            {
                Console.WriteLine($"{culture}: {culture.NativeName}");
            }

            // CurrentCulture
            ShowCurrentThreadCultures();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US", false);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US", false);
            ShowCurrentThreadCultures();

            ChangeCurrentCulture("ar-SA");
            ShowCurrentThreadCultures();

            ChangeCurrentCulture("ka-GE");
            ShowCurrentThreadCultures();

            ChangeCurrentCulture("ml-IN");
            ShowCurrentThreadCultures();

            var ci = new CultureInfo("en-US");
            var comi = ci.CompareInfo;
        }
        private static void ShowCompareResult<TVal, TResult>(TVal val1, TVal val2, TResult result, string operation, string addition)
        {
            Console.WriteLine($"\"{val1}\" {operation} \"{val2}\" ({addition})? Result: {result}");
        }
        private static void ShowCurrentThreadCultures()
        {
            Console.WriteLine();
            Console.WriteLine($"Thread.CurrentThread.CurrentCulture: {Thread.CurrentThread.CurrentCulture}");
            Console.WriteLine($"Thread.CurrentThread.CurrentUICulture: {Thread.CurrentThread.CurrentUICulture}");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
        }
        private static void ChangeCurrentCulture(string code)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(code, false);
        }
    }
}
