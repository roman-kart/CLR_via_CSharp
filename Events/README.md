# События
События - механизм, позволяющий уведомлять части программы о событии.
По факту событие - это сущность, хранящая набор методов от подписчиков,
которые могут быть вызваны при происшествии события.
## Тип для хранения всей дополнительной информации, передаваемой получателям уведомления о событии.
В FCL таким типом является **EventArgs**.
В чистом виде он не содержит полезных данных и выполнят роль "заглушки", 
от которой можно впоследствии наследоваться и создавать собственные типы.

## Определение члена-события
Событие:
```
public event EventHandler<UserEventArgsType> EventName;
```
Делегат для события
```
public delegate void EventHandler<EventArgsType>(Object sender, EventArgsType e) where EventArgsType: EventArgs;
```
Прототип метода для события:
```
void MethodName(Object sender, UserEventArgsType);
```
## Определение метода, ответственного за уведомление зарегистрированных объектов о событии
В соответствии с соглашением в классе должен быть виртуальный защищенный метод, вызываемый из кода класса и его потомков при возникновении события.
Этот метод принимает один параметр - объект UserEventArgsType, содержащий дополнительные сведения о событии.
Реализация по умолчанию этого метода просто проверяет, есть ли объекты, зарегистрированные для получения уведомления о событии, и при положительном результате проверки
сообщать зарегистрированным методам о возникновении события.</br>
Сохраняем ссылку на делегат во временной переменной для обеспечения безопасности потоков:
```
protected void OnEventHappend(UserEventArgsType e)
{
	EventHandler<EventArgsType> temp = Thread.VolatileRead(ref EventName); // копирует ссылку на переменную именнов в момент вызова
	if (temp != null)
	{
		temp(this, e);
	}
}
```
## Определение метода, преобразующего входную информацию в желаемое событие
Определяем метод, в котором вызываем выполнение события.

## Генерация компилятором
Компилятор не дает коду прямого доступа к событию, а только генерирует методы add_EventName и remove_EventName, 
при этом уровень доступа у данных методов совпадает с уровнем доступа изначально объявленного события.
Также методы могут быть как статическими, так и вирутальными.