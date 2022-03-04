# Перечисления
Перечислимым (enumerated type) называют тип, в котором описан набор пар, состоящих из символьных имен и значений.
**Перечислимый тип лучше определять на уровне класса.**
```
enum MyEnum
{
	val0,
	val1,
	val2
}
```
## Преимущества перечислений
- Программу, где используются перечислимые типы, проще написать и понять,
а у разработчиков возникает меньше проблем с ее сопровождением;
- Перечислимые типы подвергаются строгой проверке типов;
## Как примерно компилятор преобразовывает перечисления
```
internal struct Color : System.Enum {
 // Далее перечислены открытые константы,
 // определяющие символьные имена и значения
 public const Color White = (Color) 0;
 public const Color Red = (Color) 1;
 public const Color Green = (Color) 2;
 public const Color Blue = (Color) 3;
 public const Color Orange = (Color) 4;
 // Далее находится открытое поле экземпляра со значением переменной Color
 // Код с прямой ссылкой на этот экземпляр невозможен
 public Int32 value__;
}
```
Описанные перечислимым типом символы являются константами. Встречая в коде
символическое имя перечислимого типа, компилятор заменяет его числовым значением. В результате определяющая перечислимый тип сборка может оказаться ненужной во время выполнения. Но если в коде присутствует ссылка не на определенные
перечислимым типом символические имена, а на сам тип, присутствие сборки на
стадии выполнения будет обязательным. Поэтому **при изменении перечисления надо перекомпилировать код, который ее использует.**

## Определение базового типа перечисления
```
public static Type GetUnderlyingType(Type enumType);
```
Базовым типом может быть любой примитивный значимый тип, определенный в CLR.
## Вывод значения перечисления в определенном формате
```
// вывод значения перечислимого типа в разных форматах
            var c = Color.Blue;
            Console.WriteLine(c);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.ToString("G")); // стандартный
            Console.WriteLine(c.ToString("D")); // десятичный
            Console.WriteLine(c.ToString("X")); // шестнадцатеричный
            Console.WriteLine(c.ToString("F")); // вывод флагов (для битовых масок)
```

## Форматирование при помощи Format
```
// форматирование перечисления при помощи Format
            // если для переданного значения есть соответствующий объект в перечислении - возвращаем значение объекта в определенном формате,
            // иначе - переданное число
            Console.WriteLine(Enum.Format(typeof(Color), 2, "G"));
```

## Получение значений в перечислений
```
// получение значений, определенных в перечислении
            Console.WriteLine("\nEnum values: ");
            var enumValues = Enum.GetValues<Color>();
            foreach (var enumValue in enumValues)
            {
                Console.WriteLine($"{enumValue}: {((long)enumValue)}");
            }
```

## Имена значений, определенный в перечислении
```
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
```

## Разбор из строки
```
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
```

## Проверка на существование значения
```
if (Enum.IsDefined<Color>((Color)i))
	{
		Console.WriteLine($"{(Color)i} is defined in Color");
	}
```
При всем удобстве метода IsDefined применять его следует с осторожностью. Вопервых, он всегда выполняет поиск с учетом регистра, во-вторых, работает крайне
медленно, так как в нем используется отражение.

## Битовые флаги
[Flags]
enum EnumAttrubutes
{
	None = 0
	Read = 0x0001,
	Write = 0x0002,
	ReadWrite = Actions.Read | Actions.Write,
	Delete = 0x0004,
	Query = 0x0008,
	Sync = 0x0010
}

### Парсинг битовых масок
```
// Flags
var parsedTwoArgs = Enum.Parse<ColorBit>("Blue, Red, Green", true);
Console.WriteLine($"\n{parsedTwoArgs.ToString()}"); // RGB

parsedTwoArgs = Enum.Parse<ColorBit>("Red, Green", true);
Console.WriteLine($"{parsedTwoArgs.ToString()}"); // Red, Green

parsedTwoArgs = Enum.Parse<ColorBit>("7", true);
Console.WriteLine($"{parsedTwoArgs.ToString()}"); // RGB

parsedTwoArgs = Enum.Parse<ColorBit>("5", true);
Console.WriteLine($"{parsedTwoArgs.ToString()}"); // Red, Blue

[Flags]
enum ColorBit
{
	None = 0,
	Red = 0x0001,
	Green = 0x0002,
	Blue = 0x0004,
	RGB = Red | Green | Blue
}
```

**IsDefined не применяется к битовым маскам**
