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

            // цепочка делегатов
            WriteNumber writeNumber1 = new WriteNumber(DelegatesStart.WriteNumberGreen);// добавляем в цепочку делегатов одни "зеленый" делегат
            writeNumber1 = (WriteNumber) System.Delegate.Combine(writeNumber1, new WriteNumber(DelegatesStart.WriteNumberRed)); // добавляем "красный" делегат
            writeNumber1 = (WriteNumber) System.Delegate.Combine(writeNumber1, new WriteNumber(DelegatesStart.WriteNumberRed)); // добавляем "красный" делегат
            writeNumber1 = (WriteNumber) System.Delegate.Combine(writeNumber1, new WriteNumber(DelegatesStart.WriteNumberGreen)); // добавляем "зеленый" делегат
            Console.WriteLine("\n");
            writeNumber1.Invoke(4); // вызываем цепочку

            writeNumber1 = (WriteNumber)System.Delegate.Remove(writeNumber1, new WriteNumber(DelegatesStart.WriteNumberGreen)); // удаляем один зеленый делегат
            Console.WriteLine("\n");
            writeNumber1.Invoke(3); // вызываем цепочку

            writeNumber1 = (WriteNumber)System.Delegate.Remove(writeNumber1, new WriteNumber(DelegatesStart.WriteNumberGreen)); // удаляем ещё один зеленый делегат
            Console.WriteLine("\n");
            writeNumber1.Invoke(2); // вызываем цепочку

            // работа с цепочкой делегатов
            Console.WriteLine("\n");
            Func<int, int> CalcSomething = DelegatesStart.CalcExcIf12;
            CalcSomething += CalcExcIf12;
            CalcSomething += CalcExcIf12;

            int digit = 11;
            var CalcSomnethingInvList = CalcSomething.GetInvocationList();
            foreach (var CalcSome in CalcSomnethingInvList)
            {
                try
                {
                    var CalcSomeCast = (Func<int, int>)CalcSome;
                    Console.WriteLine(CalcSomeCast(digit));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                digit++;
            }

            // анонимные методы
            Action writeDigitAnon = new Action(() => { Console.WriteLine("Digits: "); });
            // сохранение значения локальной переменной при вызове анонимных методов
            for (int i = 0; i < 12; i++)
            {
                writeDigitAnon += () => Console.WriteLine(i);
            }
            writeDigitAnon.Invoke(); // во всех строках будут числа 12
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
        private static int CalcExcIf12(int digit)
        {
            if (digit == 12)
            {
                throw new ArgumentException("Argument can't be a 12!");
            }
            return digit + 1;
        }
    }
}
