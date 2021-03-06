# Интерфейсы
CLR не позволяет определять множественное наследование, однако предлагает альтернативу в виде интерфейсов.
Ключевое отличие интерфейсов от классов в том, что **интерфейсы не содержат реализации, а лишь определяют сигнатуру**, кроме того, 
**все составляющие интерфейса должны быть публичными**. Другими словами, интерфейс определяет список действий, которые можно проводить над сущностью.
**НЕ СТОИТ ЗАБЫВАТЬ ПРО УПАКОВКУ И РАСПАКОВКУ ПРИ ИСПОЛЬЗОВАНИИ ИНТЕРФЕЙСОВ ДЛЯ СТРУКТУР.**
## Определение интерфейса
```
// название интерфейса лучше начинать со строчной буквой I
public interface IUserInterface{
	void DoSomething(); // метод по умолчанию считается публичным
}
```

## Наследование интерфейсов
Наследование интерфейсов происходит иначе, чем в классах. 
Интерфейсы, при наследование, перенимает контракты родительского интерфейса, 
то есть код, который воспользуется объектом, реализующим текущий интерфейс, 
может быть уверен в том, что объект реализует оба интерфеса.

## Методы интерфейсов
По умолчанию методы интерфейсов являются виртуальными и запечатанными.
Если объявить метод как виртуальный, то он станет виртуальным и незапечатанным.</br>
Также можно объявить отдельные методы как для реализации интерфейса, так и для самого объекта:
```
public interface MyInterface
{
	void DoSomething();
}
public class MyClass : MyInterface
{
	void DoSomething()
	{
		Console.WriteLine("MyClass.DoSomething"); // данные метод принадлежит классу
	}
	// уровень доступа указывать нельзя
	void MyInterface.DoSomething()
	{
		Console.WriteLine("MyInterface.DoSomething"); // данные метод используется для реализации интерфейса (явная реализация интерфейсного метода)
	}
}
```
Проблемы явной реализации:
- отсутсвует документация и поддержка IntelliSense;
- при приведении к интерфейсному типу экземпляры значимого типа упаковываются;
- EIMI нельзя вызвать из производного типа;
## Обобщенные интерфейсы
Обощенные интерфейсы предпочтительнее использовать.
Один класс может реализовать несколько обобщенных интерфейсов.
Обобщенные интерфейсы поддерживают ковариантность и контрвариантность.

## Обобщения и интерфейсы
Можно использовать интерфейсы для контроля за тем, реализуют ли обобщенные типы конкретные интерфейсы.
Это позволяет:
- определить необходимость поддерживать несколько интерфейсов;
- позволяет избегать упаковки значимых типов, которые должны реализовывать интерфейс или .

## Базовый класс или интерфейс
1. Связь потомка с предком. Должен ли класс состоять в иерархии или же он должен иметь определенный набор функций.
2. Простота использования. При наследовании мы меняем лишь часть кода, при реализации интерфейса приходится определять всю реализацию.
3. Управления версиями. При добавлении новой сущности к базовому типу код, использующий данный тип, не требует повторной компиляции. 
В случае с интерфейсом придется добавлять реализацию для все классов, определяющих интерфейс.
Также можно создать базовый тип, реализующий интерфейс.