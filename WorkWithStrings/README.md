# Работа со строками
## Символы
Символы в C# всегда представлены 16-разрядными кодами стандарта Unicode.
Символ представлен типом System.Char (значимый тип).
### Методы System.Char
- ToLower(char, CultureInfo), ToUpper(char, CultureInfo) - возвращают эквивалент текущего символа, приведенный к нижнемы или верхнему регистру соответственно. Принимают символ и параметры культуры.
- ToUpperInvariant, ToLowerInvariant - приводят символ к верхнему и нижнему регистру соответственно, но без учета региональных стандартов;
- GetUnicodeCategory() - возвращает тип символа в таблице Unicode;
- IsDigit, IsLetter, IsWhiteSpace, IsUpper, IsLower, IsPunctuation, IsLetterOrDigit, IsControl, IsNumber, IsSeparator, IsSurrogate, IsLowSurrogate, IsHighSurrogate, IsSymbol - упрощения для работы с GetUnicodeCategory;
- CompareTo - сравнение символов без учета региональных стандартов;
- ConvertFromUtf32 - возвращает строку, состоящую из 1 или 2-х символов UTF-16, полученную из одного символа UTF-32;
- ConvertToUtf32 - создает символ UTF-32 для суррогатной пары или строки;
- Parse и TryParse - возвращают символ UTF-16 из односимвольной строки;
- GetNumericValue - числовой эквивалент строки;

### Преобразование символов
- приведение;
- System.Convert;

## System.String
Строки - примитивный тип, который, однако, наследуется от типа Object, поэтому является ссылочным.
Компилятор помещает эти литеральные строки в метаданные модуля, откуда они загружаются и используются во время выполнения.
**Строки не изменяются**.
```
Environment.NewLine // последовательность для перехода на новую строку в консоли
```
Конкатенация литеральных строк происходит на этапе компиляции:
```
string str = "Hello" + ", " + "World!"; // в скомпилированном коде окажется лишь строка "Hello, World!"
```
Конкатенацию нелитеральных строк нежелательно использовать, для этих целей лучше подойдет StringBuilder.</br>
Игнорирование символа "\", применяется при хранении пути до файла
```
string str = @"path\to\something\"; // не требует экранировать обратный слэш
```
### Сравнение строк
Для сравнения строк можно использовать:
- static Equals и Equals;
- static Compare;
- StartWith, EndWith
Будьте внимательны, **в стандартной сортировке регистр символов не учитывается!**

#### Типы сравнения строк
StringComparison:
- Ordinal, OrdinalIgnoreCase - сравнение без учета региональных стандартов;
- CurrentCulture, CurrentCultureIgnoreCase - сравнение с учетом стандартов культуры (для вывода отсортированной последовательности строк на экран);
- InvariantCulture, InvariantCultureIgnoreCase - инвариантный язык - английский, не привязанный к конкретной стране или региону. Используется для системных строк;
Если хотите выполнить простое сравнение - ToUpperInvariant и ToLowerInvariant.
**При нормализации строк рекомендуется использовать ToUpperInvariant, так как сравнение строк в верхнем регистре оптимизированно.**</br>
System.Globalization.CultureInfo:
- GetCultures() - получение списка культур;
- CurrentUICulture - получение ресурсов, видимых конечному пользователю;
- CurrentCulture - используется во всех случаях, в которых не используется CurrentUICulture, в том числе для форматирования чисел, дат, приведения и сравнения строк.

CompareInfo - для более детального сравнения:
- Compare;
- IndexOf;
- IsLastIndexOf;
- IsPrefix;
- IsSeffix;

System.StringComparer - многократные однотипные сравнения множества строк.

System.Thread:
- Thread.GetCurrentCulture - свойство, которое позволяет получить или задать культуру для текущего потока;
- Thread.GetCurrentUICulture - свойство, которое позволяет получить или задать культуру для отображения пользователю текущего потока;

### Интернирование строк
Если в программе строки часто сравниваются методом порядкового сравнения с учетом регистра или ожидается появление множества одинаковых строковых объектов - 
можно применить поддежрижваемый CLR механизм интернирования строк (string interning).
При инициалиализации CLR создает внутреннюю хеш-таблицу, в которой ключами являются строки, а значениями - ссылки на строковые объекты в управляемой куче.</br>
Методы для доступа к хеш-таблице:
- String.Intern(String str); // если строка находится в хеш-таблицу, то возвращает ссылку на него, иначе - добавляет и возвращает ссылку,
- String.IsInterned(String str); // если строки находится в хеш-таблице, то возвращает ссылку на строку, иначе - не добавляет строку в таблицу и возвращает null,

### Пул строк
Компилятор C# все литеральные строки, которые находятся в коде программы, сохраняет в пуле, а в коде сами строки заменяет на ссылки.
### Работа с текстовыми элементами
Некоторые символы представляют собой комбинацию 2-х символов (high surrogate и low surrogate), такие символы востребованы в странах Восточной Азии.
Для корректной работы с ними предназначен тип System.Globalization.StringInfo.
Можно просто создать экземпляр этого типа, передав в качестве параметра конструктора строку.</br>
Узнать кол-во символов можно при помощи LengthInTextElements:
```
string sourceStr = " اِنفِجَار";
Console.WriteLine(sourceStr.Length); // в первом случае будет 10 символов, так как в этом слове есть символы-заменители
StringInfo stringInfo = new StringInfo(sourceStr);
Console.WriteLine(stringInfo.LengthInTextElements); // во втором случае будет уже 7 символов,
													// так как символы заменители, которые нужны для отображения другого символа, не учитываются
```
[!Методы копирования строк](./imgReadme/str_meth1.png)

## Получение строкового представления объекта
Тип Object реализует метод ToString(), который просто возвращает тип объекта.
Остальные типы могут переопределять метод ToString. 
Желательно в своих типах переопределять метод ToString, чтобы иметь корректное представление объекта в виде строки. 
### Форматы и региональные стандарты
Интерфейс IFormattable позволяет указать для возвращаемой строки формат и региональные стандарты.
Данный интерфейс содержит метод ToString(string format, IFormatProvider), который возвращает отформатированную строку.
format - буквеннные обозначения различных форматов.
IFormatProvider - объект, в котором есть данные о культуре. CultureInfo реализует IFormatProvider.
Получение формата для определенного типа:
```
IFormatProvider.GetFormat(typeof(Type)); // возвращает объект типа Object, который потом можно преобразовать в нужный тип.
```
```
CultureInfo.InvariantCulture // формат для форматирования без определенного регионального стандарта
```
IFormatProvider реализуется следующими типами FCL:
- CultureInfo;
- NumberFormatInfo;
- DateTimeFormatInfo;

### Форматирование нескольких объектов в одну строку
Чтобы создать строку, в которой будет содержаться информация о нескольких объектах, можно воспользоваться следующим синтаксисом:
```
String.Format("{0}, {1} == {1} : {2}", i, d, dateTime); // возвращает форматированную строку
```
Чтобы расширить стандартное форматирование объекта можно указать через двоеточие код форматирования.
Однако, методы Write и WriteLine могут принимать только форматированные строки с указанием формата, но для этих методов нет реализации с IFormatProvider.

### Получение объекта из строки
У каждого базового типа есть метод разбора из строки. Вот, например, методы для разбора целочисленного числа:
```
public static Int32 Parse(String s, NumberStyle sltyle, IFormatProvider);
public static Boolean TryParse(String s, NumberStyle sltyle, IFormatProvider, out int Result);
```
## StringBuilder
Для создания объекта StringBuilder можно задать следующие параметры:
- int maxCapacity - создает объект StringBuilder с определенной максимальной емкостью. По умолчанию емкость равна int.MaxValue.
Для созданного объекта StringBuilder это значение нельзя изменить;
- int capacity - изначально заданная емкость. По умолчанию равна 16;
- char[] characterArray - изначально заданный массив символов;
### Методы
[!Члены класса StringBuilder1](./imgReadme/strbld_meth1.png)
[!Члены класса StringBuilder2](./imgReadme/strbld_meth2.png)
[!Члены класса StringBuilder3](./imgReadme/strbld_meth3.png)

## Кодирование и декодирование текста
Виды кодировок:
- UTF-16 кодирует каждый символ в 2 байта (используется по умолчанию в CLR);
- UTF-8 кодирует символы в зависимости от их размера в 1, 2, 3 или 4 байта;
- UTF-32 кодирует все символы в 4 байта;
- UTF-7 использует для кодирования 7 разрядов. **UTF-7 следует избегать**;
- ASCII кодирует символы в один байт.

Кодирование и декодирование в C#:
```
System.Text.Encoding.UTF8.GetBytes(string forEncoding);
System.Text.Encoding.UTF8.GetString(char[] forDecoding);
```
Методы класса Encoding:
[!Методы класса Encoding](./imgReadme/str_enc_meth1.png)

### Decoder
Для декодирования строки байтов удобно использовать объект класса Decoder, 
который позволяет декодировать символы в потоке. Если при декодировании остаются лишние байты, которые невозможно декодировать - 
он сохраняет их и применяет при следующем декодировании.
Для кодирования в потоке может использоваться Encoder.