using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void WriteNumber(int number);
    internal class MethodsForDelegate
    {
        public ConsoleColor ConsoleColor { get; set; } = Console.ForegroundColor;
        public void WriteNumberColor(int number)
        {
            var prevForeign = Console.ForegroundColor;
            Console.ForegroundColor = this.ConsoleColor;
            Console.WriteLine(number);
            Console.ForegroundColor = prevForeign;
        }
    }
    internal class DelegatesStart
    {
        public static void Do()
        {
            // статические методы
            WriteNumber writeNumber = new WriteNumber(DelegatesStart.WriteNumberRed);
            writeNumber += DelegatesStart.WriteNumberDefault;
            writeNumber += DelegatesStart.WriteNumberGreen;

            writeNumber.Invoke(23);

            // экземплярные методы
            MethodsForDelegate methodsForDelegate = new MethodsForDelegate() { ConsoleColor = ConsoleColor.Magenta};
            writeNumber += methodsForDelegate.WriteNumberColor;
            writeNumber.Invoke(101);
        }
        private static void WriteNumberRed(int number)
        {
            var prevForeign = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(number);
            Console.ForegroundColor = prevForeign;
        }
        private static void WriteNumberGreen(int number)
        {
            var prevForeign = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number);
            Console.ForegroundColor = prevForeign;
        }
        private static void WriteNumberDefault(int number)
        {
            Console.WriteLine(number);
        }
    }
}
