using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkWithStrings
{
    internal class WorkWithChars
    {
        public static void Do()
        {
            char anyChar = 'f';
            var toUpper = Char.ToUpper(anyChar, CultureInfo.CurrentCulture);
            var toLower = Char.ToLower(anyChar, CultureInfo.CurrentCulture);
            Console.WriteLine($"anyChar = {anyChar}");
            Console.WriteLine($"toUpper = {toUpper}");
            Console.WriteLine($"toLower = {toLower}");
            Console.WriteLine($"Char.GetUnicodeCategory(anyChar) = {Char.GetUnicodeCategory(anyChar)}");

            var symbols = new char[] { 'a', 'b', '\"', '9', '1', '\t', '.', '`'};
            foreach (var symbol in symbols)
            {
                WriteDefinedCharType(symbol);
            }

            if (Char.TryParse(";", out Char parsedChar))
            {
                Console.WriteLine($"Parsed char: \"{parsedChar}\"");
            }

            // converting
            char c = (Char)66;
            int n = (Int32)c;
            Console.WriteLine($"{c}:{n}");
            n += 10;
            c = Convert.ToChar(n);
            Console.WriteLine($"{c}:{n}");

            // concatenating
            string str = "Hello" + ", " + "World!"; // в скомпилированном коде окажется лишь строка "Hello, World!"
            Console.WriteLine(str);

            // ignore reversed slash
            string path = @"C:\Users";
            //string pathErr = "C:\Users"; // Error
            Console.WriteLine(path);
        }
        public static void WriteDefinedCharType(char symbol)
        {
            if (Char.IsDigit(symbol))
            {
                Console.WriteLine($"{symbol} is a digit");
            }
            else if (Char.IsLetter(symbol))
            {
                Console.WriteLine($"{symbol} is a letter");
            }
            else if (Char.IsControl(symbol))
            {
                Console.WriteLine($"{symbol} is a control");
            }
            else if (Char.IsSymbol(symbol))
            {
                Console.WriteLine($"{symbol} is a symbol, but isn't digit or letter");
            }
            else
            {
                Console.WriteLine($"{symbol} is {Char.GetUnicodeCategory(symbol)}");
            }
        }
    }
}
