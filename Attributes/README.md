# Атрибуты
Пример использования атрибутов:
```
using System;
[assembly: SomeAttr]     // Применяется к сборке
[module: SomeAttr]       // Применяется к модулю
[type: SomeAttr]         // Применяется к типу
internal sealed class SomeType<[typevar: SomeAttr] T> { // Применяется 
                         // к переменной обобщенного типа
  [field: SomeAttr]      // Применяется к полю
public Int32 SomeField = 0;
[return: SomeAttr]     // Применяется к возвращаемому значению
  [method: SomeAttr]     // Применяется к методу
public Int32 SomeMethod(
    [param: SomeAttr]    // Применяется к параметру
Int32 SomeParam) { return SomeParam; }
  [property: SomeAttr]   // Применяется к свойству
public String SomeProp {
    [method: SomeAttr]   // Применяется к механизму доступа get
get { return null; }
}
  [event: SomeAttr]      // Применяется к событиям
[field: SomeAttr]      // Применяется к полям, созданным компилятором
[method: SomeAttr]     // Применяется к созданным 
                         // компилятором методам add и remove
public event EventHandler SomeEvent;
}
```
Обычно все названия атрибутов заканчиваются на Attribute. Для удобства, при использовании можно не писать это слово.
## Именованные параметры
Атрибут - это класс, поэтому у него есть конструктор. Однако, у конструктора атрибута есть дополнительная возможность - в конструкторе можно присваивать значения открытым полям экземпляра.
```
[DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
```
## Правила при работе с атрибутами
- Простой,
- Один конструктор,
- Нет методов,
- Открытые поля и свойства допустимы.

## Создание атрибутов
Пример создания атрибута для перечисления:
```
[AttributeUsage(AttributeTargets.Enum, Inherited = false)]
public class FlagsAttribute : System.Attribute
{
	public FlagsAttribute()
	{

	}
}
```
AttributeUsage поддерживается компилятором по умолчанию. Его задача - определить, может ли данный атрибут применяться к какому-либо типу.

## Параметры атрибутов
- AllowMultiple: многократное использование атрибутов,
- Inherited: будет ли атрибут применяться к производным классам (наследование допустимо для классов, методов, свойств, событий, полей, возвращаемых значений, параметров).

## Конструктор атрибута и типы данных полей и свойств
Чтобы атрибут и его конструктор были CLS-совместимыми, поля и аргументы должны быть: примитивными типами, String, Type, Object.
## Проверка наличия атрибутов при помощи System.Reflection.CustomAttributeExtension
[!Проверка наличия атрибутов при помощи System.Reflection.CustomAttributeExtension](./imgReadme/sys_ref_atr.png)

## Безопасное получение информации об атрибуте
System.Reflection.CustomAttributeData помогает получить информацию об атрибутах, не выполняя при этом код конструктора проверяемого класса.