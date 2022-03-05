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
