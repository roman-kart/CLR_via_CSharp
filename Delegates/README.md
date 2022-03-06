# Делегаты
Делегат - функция обратного вызова, безопасная по отношению к типам.
## Синтаксис
### Объявление делегата
public delegate void WriteNumber(int number);
### Работа с делегатами
```
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
```
## Тонкости работы делегатов
Строка, представленная ниже:
```
internal delegate void Feedback(Int32 value);
```
Преобразуется компилятором примерно в следующую строку:
```
internal class Feedback : System.MulticastDelegate {
	// Конструктор
	public Feedback(Object object, IntPtr method);
	// Метод, прототип которого задан в исходном тексте
	public virtual void Invoke(Int32 value);
	// Методы, обеспечивающие асинхронный обратный вызов
	public virtual IAsyncResult BeginInvoke(Int32 value,
	AsyncCallback callback, Object object);
	public virtual void EndInvoke(IAsyncResult result);
}
```
Все делегаты производны от System.MulticastDelegate, который в свою очередь явялется производным от System.Delegate. System.Delegate является производным от object.
[!Важные закрытые поля класса MulticastDelegate](./imgReadme/del_imp_1.png)
[!Важные закрытые поля класса MulticastDelegate](./imgReadme/del_imp_2.png)
Делегат - обертка для метода и класса, который содержит этот метод.
Invoke - метод для вызова метода определенного объекта.

## Обратный вызов нескольких методов (цепочка делегатов)
Цепочка (chaining) - коллекция делегатов, дающая возможность вызывать все методы, представленные этими делегатами.
**Каждый раз при добавлении делегата в цепочку создается новый делегат.**
[!Цепочка делегатов](./imgReadme/del_chn_1.png)
**Чтобы добавить в цепочку делегатов делегат, необходимо вызвать метод Combine у класса Delegate: **
**Чтобы удалить делегат из цепочки делегатов, необходимо использовать метод Remove класса Delegate. Он сканирует массив делегатов с конца и ищет делегат с такими же полями \_target и \_methodPtr**
Тогда, если в цепочке еще остались делегаты - возвращается новый объект делегата с обновленной цепочкой. В противном случае - null.
**Цепочка делегатов возвращает результат только последнего делегата!!!**
```
fbChain = (Feedback) Delegate.Combine(fbChain, fb1);

```
[!Цепочка делегатов](./imgReadme/del_chn_2.png)
[!Цепочка делегатов](./imgReadme/del_chn_3.png)
[!Цепочка делегатов](./imgReadme/del_chn_4.png)
## MulticastDelegate.GetInvocationList
MulticastDelegate.GetInvocationList позволяет получить список делегатов из цепочки делегатов и вызвать каждый из них по отдельности.
Это позволяет обрабатывать ошибки в делагатах и получать результат выполнения у каждого из делегатов.
## Обобщенные делегаты
Обобщенные делегаты - набор универсальных делегатов. Данные делегаты могут принимать до 16 аргументов. 
Обобщенные делегаты в FCL:
- Action: возвращает void, принимает до 16 аргументов,
- Predicate: возвращает bool, принимает до 16 аргументов,
- Func: возвращает TResult, принимает до 16 аргументов.

## Анонимные методы
Синтаксис создания:
```
(int a, int b) => {
	Console.WriteLine(a + b);
}
```
Если анонимный метод не использует экземпляры объекта - он будет сгенерирован как статический.
Если же использует - как экземплярный.
