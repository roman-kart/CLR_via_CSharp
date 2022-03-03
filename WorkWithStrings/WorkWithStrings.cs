using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

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

            // interning
            var words = GetRandomStrings(10000000, 2);
            TimerDecorator<string, string[], int> timerDecorator = new TimerDecorator<string, string[], int>(NumTimesWordAppears);
            var count = timerDecorator.DetemineExecutionTime("ФЫ", words, out double executionTime);
            Console.WriteLine($"Without intern. count: {count}, milliseconds: {executionTime}");

            // интернируем все слова
            foreach (var word in words)
            {
                String.Intern(word);
            }
            TimerDecorator<string, string[], int> timerDecoratorIntern = new TimerDecorator<string, string[], int>(NumTimesWordAppearsIntern);
            count = timerDecoratorIntern.DetemineExecutionTime("ФЫ", words, out executionTime);
            Console.WriteLine($"With intern. count: {count}, milliseconds: {executionTime}");
        }
        private static string[] GetRandomStrings(int count = 100, int wordLength = 10)
        {
            var words = new string[count];
            var upperSymbolsSequence = 1040;
            var lowerSymbolSequence = 1072;
            string newWordStr;
            for (int i = 0; i < words.Length; i++)
            {
                char[] newWord = new char[wordLength];
                for (int j = 0; j < wordLength; j++)
                {
                    char currentChar = (char)RandomNumberGenerator.GetInt32(upperSymbolsSequence, lowerSymbolSequence);
                    newWord[j] = currentChar;
                }
                newWordStr = String.Concat(newWord);
                String.Intern(newWordStr);
                words[i] = String.IsInterned(newWordStr);
            }
            return words;
        }
        private static int NumTimesWordAppears(string word, string[] wordArray)
        {
            int count = 0;
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (word.Equals(wordArray[i], StringComparison.Ordinal))
                {
                    count++;
                }
            }
            return count;
        }
        private static int NumTimesWordAppearsIntern(string word, string[] wordArrayInterned)
        {
            int count = 0;
            for (int i = 0; i < wordArrayInterned.Length; i++)
            {
                if (Object.ReferenceEquals(word, wordArrayInterned[i]))
                {
                    count++;
                }
            }
            return count;
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
