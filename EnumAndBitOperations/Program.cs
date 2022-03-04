using System;

namespace EnumAndBitOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Color))); // получение базового типа

            // вывод значения перечислимого типа в разных форматах
            var c = Color.Blue;
            Console.WriteLine(c);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.ToString("G")); // стандартный
            Console.WriteLine(c.ToString("D")); // десятичный
            Console.WriteLine(c.ToString("X")); // шестнадцатеричный

            // форматирование перечисления при помощи Format
            // если для переданного значения есть соответствующий объект в перечислении - возвращаем значение объекта в определенном формате,
            // иначе - переданное число
            Console.WriteLine(Enum.Format(typeof(Color), 2, "G"));

            // получение значений, определенных в перечислении
            Console.WriteLine("\nEnum values: ");
            var enumValues = Enum.GetValues<Color>();
            foreach (var enumValue in enumValues)
            {
                Console.WriteLine($"{enumValue}: {((long)enumValue)}");
            }

            // имя определенного значения в перечислении
            var cName = Enum.GetName<Color>(Color.Blue);
            Console.WriteLine("\ncName: ");
            Console.WriteLine(cName);

            // имена всех значений в перечислении
            var cNames = Enum.GetNames<Color>();
            Console.WriteLine("\ncNames: ");            
            foreach (var cNameVal in cNames)
            {
                Console.WriteLine(cNameVal);
            }

            // Парсинг
            // корректное значение
            if (Enum.TryParse<Color>("Blue", true, out Color resultCorrect))
            {
                Console.WriteLine($"Parsed. {resultCorrect}: {((long)resultCorrect)}");
            }

            // некорректное значение
            if (Enum.TryParse<Color>("Grey", true, out Color resultIncorrect))
            {
                Console.WriteLine($"Parsed. {resultIncorrect}: {((long)resultIncorrect)}");
            }

            // корректное значение в виде числа
            if (Enum.TryParse<Color>("0", true, out Color resultNumCorrect))
            {
                Console.WriteLine($"Parsed. {resultNumCorrect}: {((long)resultNumCorrect)}");
            }

            // некорректное значение в виде числа (будет возвращено 111:111)
            if (Enum.TryParse<Color>("111", true, out Color resultNumIncorrect))
            {
                Console.WriteLine($"Parsed. {resultNumIncorrect}: {((long)resultNumIncorrect)}");
            }

            Console.WriteLine("\nIsDefined: ");
            for (int i = 0; i < 5; i++)
            {
                if (Enum.IsDefined<Color>((Color)i))
                {
                    Console.WriteLine($"{(Color)i} is defined in Color");
                }
                else
                {
                    Console.WriteLine($"{i} isn't defined in Color");
                }
            }

            // Flags
            var parsedTwoArgs = Enum.Parse<ColorBit>("Blue, Red, Green", true);
            Console.WriteLine($"\n{parsedTwoArgs.ToString()}"); // RGB

            parsedTwoArgs = Enum.Parse<ColorBit>("Red, Green", true);
            Console.WriteLine($"{parsedTwoArgs.ToString()}"); // Red, Green

            parsedTwoArgs = Enum.Parse<ColorBit>("7", true);
            Console.WriteLine($"{parsedTwoArgs.ToString()}"); // RGB

            parsedTwoArgs = Enum.Parse<ColorBit>("5", true);
            Console.WriteLine($"{parsedTwoArgs.ToString()}"); // Red, Blue
        }
    }
    [Flags]
    enum ColorBit
    {
        None = 0,
        Red = 0x0001,
        Green = 0x0002,
        Blue = 0x0004,
        RGB = Red | Green | Blue
    }
    enum Color
    {
        Red,
        Green,
        Blue,
    }
}
