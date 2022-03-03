using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkWithStrings
{
    internal class WorkWithStringsFormat
    {
        public static void Do()
        {
            FormatProviderClass format = new FormatProviderClass() { Name = "Something", Description = "asdvbxcbxv", DateTime = DateTime.Now };
            Console.WriteLine(format.ToString());
            Console.WriteLine(format.ToString("d", CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine(format.ToString("n", CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine(format.ToString("D", CultureInfo.GetCultureInfo("en-US")));
            // Console.WriteLine(format.ToString("q", null)); // Error

            // formating
            int i = 10;
            decimal d = 10.2m;
            DateTime dateTime = DateTime.Now;
            string str = (String.Format(CultureInfo.GetCultureInfo("en-US"), "{0}, {1} == {1:E} : {2:D}", i, d, dateTime));
            Console.WriteLine(str);
        }
        public class FormatProviderClass : IFormattable
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime DateTime { get; set; }
            public override string ToString()
            {
                return $"FormatProviderClass: Name = {Name}, Description = {Description}, DateTime = {DateTime}";
            }
            public string ToString(string? format, IFormatProvider? formatProvider)
            {
                var formatDateTime = (DateTimeFormatInfo)formatProvider.GetFormat(typeof(DateTime));
                if (format != null)
                {
                    switch (format)
                    {
                        case "d":
                            return $"DateTime = {DateTime.ToString("G", formatProvider)}";
                        case "n":
                            return $"Name = {Name}";
                        case "D":
                            return $"Description = {Description}";
                        default:
                            throw new ArgumentOutOfRangeException("Укажите правильное значение");
                    }
                }
                return ToString();
            }
        }
    }
}
