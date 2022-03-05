# Массивы
CLR поддерживает:
- одномерные (single-demension)
```
int[] didits = new int[10];
```
- многомерные (multidemesion)
```
int[,] digits2 = new int[10, 20];
```
- нерегулярные (jagged)
```
int[][] digitsJagged = new int[3][]; // массив массивов
```

Массивы всегда размещаются в куче. Базовым для всех массивов является тип System.Array.
[!Размещение массива в куче](./imgReadme/arr_heap_1.png)

## Инициализация элементов массива
String[] names = new String[] { "Aidan", "Grant" };

## Приведение типов в массивах
Для массивов с элементами ссылочного типа допустимо приведение.
Явно преобразовывать значимые типы в другие типы нельзя, но это ограничение можно обойти при помощи метода Array.Copy.

```
// преобразование массивов из ссылочных типов
Product[] products = new Product[]
{
	new Product{ Name = "Apple", Price = 100},
	new Product{ Name = "Milk", Price = 80}
};

// неявное преобразование к родительскому типу
Object[] objects = products;

// явное преобразование (компилируется, но происходит ошибка времени выполнения)
// String[] strings = (String[])objects;

// проверка при помощи as
var transformed = objects as String[];
if (transformed != null)
{
	String[] strings = (String[])objects;
}
else
{
	Console.WriteLine("Can't transform objects as String[]");
}

// явное преобразование, выполнится успешно
Product[] productsTransformed = (Product[])objects;

// преобразование массивов из значимых типов
Int32[] ints = new int[] { 1, 2, 3 };

// компилируется с ошибкой, так как приведение значимых типов запрещено
// Object[] objects1 = (Object[])ints;

// для преобразования значимых типов можно использовать метод Array.Copy
Object[] objectsInt = new object[ints.Length];
Array.Copy(ints, objectsInt, ints.Length);
foreach (var item in objectsInt)
{
	Console.WriteLine(item);
}
```

## Array.Copy
Производит поверхностное (shallow) копирование. **На ссылочные объекты копируется ссылка.**
Метод Array.Copy действует следующим образом:
- Упаковывает элементы значимого типа в элементы ссылочного типа (копирование int[] в object[]);
- Распаковка элементов ссылочного типа в элементы значимого типа (копирование object[] в int[]);
- Расширение (widening) примитивных типов значимых типов, например копирование int[] в double[];
- Понижающее приведение в случаях, когда совместимость массивов невозможно определить по их типам.
Сюда относится, к примеру, приведение массива типа object[] в массив типа IFormattable[].
Если все объекты в массиве object[] реализуют интерфейс IFormattable[], приведение пройдет успещно.
```
// Array.Copy()
ProductComp[] productComps = new ProductComp[]
{
	new ProductComp
	{
		Name = "Melon",
		Price = 60
	},
	new ProductComp
	{
		Name = "Coca-cola",
		Price = 100
	}
};

// неявное преобразование 
IComparable<ProductComp>[] comparables = productComps;
```

## System.Buffer.BlockCopy
Для более быстрого копирования массивов значимых типов можно использовать метод System.Buffer.BlockCopy. Он работает быстрее, чем Array.Copy. Использует поразрадное копирование.
```
// более быстрое копирование при помощи System.Buffer
int length = int.MaxValue / 16;
var randInts = GetRandomInt32Array(length: length);
int[] randIntDestination = new int[randInts.Length];
// 177
var arrayCopyTime = CustomTimer.DefifneArrayCopyTime<int[], int[], int>(Array.Copy, randInts, randIntDestination, randInts.Length);

int[] randIntsBuffer = GetRandomInt32Array(length: length);
int[] randIntDestinationBuffer = new int[randIntsBuffer.Length];
// 43
var bufferCopyTime = CustomTimer.DefifneBlockCopyTime<int[], int[]>(Buffer.BlockCopy, randIntsBuffer, randIntDestinationBuffer, randIntDestinationBuffer.Length);|
```

## Array.ConstrainedCopy
Для надежного копирования набора элементов из одного массива в другой используйте метод ConstrainedCopy класса System.Array. Он гарантирует, что в случае
неудачного копирования будет выдано исключение, но данные в целевом массиве
останутся неповрежденными.

## Реализация интерфейсов IEnumerable, ICollection IList
System.Array реализует интерфейсы IEnumerable, ICollection IList.
При создании одномерного массива с начинающейся с нуля индексацией CLR автоматически реализует интерфейсы IEnumerable<T>, ICollection<T> IList<T>,
а также три интерфейса для всех базовых типов массива при условии, что эти типы являются ссылочными.
```
Object
	Array (необобщенные IEnumerable, ICollection, IList)
		Object[] (IEnumerable, ICollection, IList of Object)
			String[] (IEnumerable, ICollection, IList of String)
			Stream[] (IEnumerable, ICollection, IList of Stream)
			FileStream[] (IEnumerable, ICollection, IList of FileStream)
			.
			. (другие массивы ссылочных типов)
			.
```

Это означает, что можно передать в метод Method1(IEnumerable<object>) массив строк.
**Значимые типы реализуют только интерфейсы своего типа (object и ValueType не будет).**

## Передача массива в качестве аргумента
При передаче массива в качестве аргумента передается ссылка на массив.

## Массивы с ненулевой нижней границы
Создать можно при помощи Array.CreateInstance: 
```
int[] lengths = {3, 4};
int[] lowerBounds = { -9, 10 };
var arr = Array.CreateInstance(typeof(string), lengths, lowerBounds);
string[,] arrStrs = (string[,])arr;
```
Type[*] - массивы с ненулевой границей

## Массивы в CLR
Лучше использовать векторы с нулевой индексацией, так как компилятор оптимизирует код для таких массивов, 
а также сам код выполняется эфективнее.