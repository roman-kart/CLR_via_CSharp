# Типы данных
## Примитивные типы
Примитивные типы - типы, которые используются так часто, что компилятор поддерживает их по-умолчанию.</br>
Таблица примитивных типов FCL (Framework Class Library):
![FCL-типы](./imgReadme/fcl_1.png)
![FCL-типы](./imgReadme/fcl_2.png)
![FCL-типы](./imgReadme/fcl_3.png)

### checked и unchecked
При выполеннии операций над примитивными числовыми типами может происходить переполнение - 
ситцация, когда значение результата выходит за рамки переменной, которой этот результат присваивается.</br> 
В C# для работы с такими ситцациями предусмотрены слова checked и unchecked:
- checked: проверяет на переполнение
- unchecked: не приверяет на переполенние
В настройках проекта по умолчанию выключена проверка на переполнение.
Для проверки блока кода на переполнение можно пеместить его в блок checked{}.
**Проверка в блоке checked{} распространяется только на арифметические операции внутри данного блока! На вызываемые методы НЕ распространяется**

## Ссылочные типы (class)
Характиристики:
- Хранятся в куче;
- При обращении к полю происходит разыменование указателя;
- При копировании происходит передача указателя;
- Могут наследоваться и реализовывать интерфейсы;
## Значимые типы (structure, enum)
Характиристики:
- Хранятся в стеке;
- При обращении к полю значение получается из стека;
- При копировании в стеке создается новый объект;
- Могут только реализовывать интерфейсы;
- По умолчанию память для членов структур размечается последовательно, однако, если структура не будет
использоваться в небезопасном коде, то лучше дать CLR самой разметить память. 
Сделать это можно при помощи атрибута **System.Runtime.InteropService.StructLayout(LayoutKind)**;
### boxing and unboxing:
- Boxing (упаковка) - приведение значимого типа к типу Object:
	1. В управляемой куче выделяется память, объем которой определяется длиной значимого типа и 
	двумя дополнительными членами - указателем на типовой объект и индексом блока синхронизации, 
	т.к. эти члены необходимы для всех объектов в управляемой куче,
	2. Поля значимого типа копируются в память - в только что выделенную кучу,
	3. Возвращается адрес объекта. Этот адрес являестя ссылкой на объект, то есть значимый тип превратился 
	в ссылочный.
	**Чтобы избежать проблем с производительностью, необходимо использовать обобщения (generic) и обобщенные коллекции!**
- Unboxing (распаковка) - приведение Object к значимому типу:
	1. Получаем объект, расположенный по адресу, указанному в Object,
	2. Проверяем, сопадает ли тип значимого объекта, хранящегося в куче с типом, к которому пытаемся его привести.
	**Явное приведение типов работать не будет!** Необходимо сначала привести именно к тому типу, который расположен в куче.
	3. Копируем значения из объекта, расположенного в куче, в объект, расположенный в стеке.
### Особенности работы со значимыми типами:
- При передачи пользовательского значимого типа в качестве аргумента для метода стандартной библиотеки, скорее всего будет происходить упаковка, 
так как из всех возможных вариантов методов будет выбран тип Object и будет происходить упаковка;
- При присваивании значимого объекта к интерфейсу будет происходить упаковка, так как интерфейсы могут ссылаться только на объекты в куче;
- Для вызова невиртуальных методов, определенных в типе Object, необходима ссылка на объект в куче, 
так как там содержится ссылка на типовой объект.
- Изменить значение в запакованном значимом объекте можно при помощи интерфейсов, так как при приведении запакованного 
к интерфейсу не будет происходить распаковки и обращение будет идти напрямую к областе в куче.
**Рихтер советует делать все поля в пользовательских значимых типах readonly**

## Equals
Метод Equals определен в типе Object и проверяет, тождественны ли два объекта (указывают ли ссылки на один и тот же участок памяти).
Однако, этот метод можно переопределить, поэтому для проверки на тождественность рекомендуется использовать статический метод Object.ReferenceEquals(), принимающий в себя 2 ссылки на объект.</br>
По умолчанию, метод Equals в значимых типах сравнивает значения всех полей, входящих в объект. 
Делает он это при помощи рефлексии (или отражения, перевод в книге), что медленно, поэтому 
**надо переопределять Equals в структурах**.</br>
Также может понадобиться реализовывать следующие интерфейсы:
1. System.IEquatable<T> - безопасный в отношении типов метод Equals;
2. == и != - для реализации можно использовать безопасный в отношении типов метод Equals;
3. System.IComparable<T> - для сортировки
4. <, <=, >, >= - для реализации можно использовать CompareTo
При переопределении Equals необходимо **переопределить GetHashCode**. Необходимо для hash-таблиц и словарей.
**Не используйте для собственных хэш-таблиц стандартные реализации GetHashCode, так как она может измениться в следующих версиях CLR**
[!Правила для алгоритма хэширования](./imgReadme/hash_1.png)
[!Правила для алгоритма хэширования](./imgReadme/hash_2.png)
