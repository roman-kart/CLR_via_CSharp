# Исключения и управление состоянием
Обработка исключений (exception handing) - механизм, позволяющий типам сообщать об ошибках.
## Механика обработки исключений
Для работы с исключениями существует несколько блоков кода:
- try{}: область, в которой выполняется код, который может генерировать исключения;
- catch(ExceptionType ex){}: отлавливание исключения определенного типа;
- catch{}: отлавливание исключений всех типов;
- finally: выполняется всегда независимо от того, было ли сгенерированно исключение. 
Код, следующий за блоком finally, выполняется, если в блоке try не генерировалось исключение или если исключение было перехвачено блоком catch, а новое исключение не генерировалось.

**ЗАДАЧА С СОБЕСЕДОВАНИЙ!!! При обнаружении блока catch нужного типа CLR исполняет все внутренние блоки finally, начиная со связного с блоком try, в котором было вброшено исключение, 
и заканчивая блоком catch нужного типа. При этом ни один блок finally не выполняется до завершения действий с блоком catch, обрабатывающим исключение.**
После того, как код внутренних блоков finally будет выполнен, исполняется код из обрабатывающего блока catch. Здесь выбирается способ восстановления после исключения.
Затем можно выбрать несколько вариантов действий:
- Еще раз сгенерировать то же исключение для передачи дополнительной информации коду, расположенному в стеке выше;
- Сгенерировать исключение другого типа для передачи дополнительной информации коду, расположенному выше в стэке;
- Позволить программному потоку выйти из блока catch естественным образом.

В последнем случае происходит переход к блоку finally. 
После выполнения всего содержащегося в нем кода управление переходит к расположенной после блока finally инструкции.
Если finally отсутсвует - поток переходит к инструкции, расположенной за последним блоком catch.

## Блок finally
Код блока finally выполняется всегда. Обычно этот код производит очистку после выполнения блока try.
*Прерывание потока или выгрузка домена приложений является источником исключения ThreadAbortException, обеспечивающего выполнение блока finally. Если же поток прерывается функцией TerminateThread или методом FailFast класса System.Environment, блок finally не выполняется. Разумеется, Windows производит очистку всех ресурсов, которые использовались прерванным процессом.*

## Класс System.Exception
Исключения типа System.Exception и производные перехватываются всеми CLS-совместимыми ЯП.
**Важная информация о StackTrace: **
```
// обнуляет трассировку стэка (информацию о методе, в котором было сгенерировано исключение)
catch{
	throw new Exception();
}
// не обнуляет трассировку стэка
catch{
	throw;
}
```

## Генерирование исключений
При генерации исключений необходимо следовать следующим правилам:
- не создавать исключения базовых классов,
- писать текст сообщения на английском.

## Создание классов исключений
Все типы, производные от System.Exception должны иметь возможность сериализоваться, а это значит, что они не могут выйти 
за границы домена приложения и их нельзя записать в журнал или базу данных.

## Продуктивность вместо надежности
При написании кода просто невозможно учесть все возможные ошибки,
поэтому приходится мириться с кодов без проверки ошибок.
### Исправление проблемы искуственного состояния
- CLR запрещает аварийно завершать потоки во время выполнения кода блоков catch и finally.
```
public static void Transfer(Account from, Account to, Decimal amount) {
try { /* здесь ничего не делается */ }
finally {
	from -= amount;
	// Прерывание потока (из-за Thread.Abort/AppDomain.Unload)
	// здесь невозможно
	to += amount;
	}
}
```
**Использовать только для самых чувствительных состояний!**
- System.Diagnostics.Contracts,
- Область ограниченного исполнения (CER),
- System.Transactions.TransactionScope

Environment.FailFast - завершение работы приложения.

## Приемы работы с исключениями
- Активно использовать блоки finally. finally используется для lock, using, foreach:
-- lock. Блок finally снимает блокировку,
-- using. Внутри finally вызывается Dispose,
-- foreach. Dispose для IEnumerator,
-- Если определен деструктор, то внутри finally вызывается Finalize базового класса.
- Не надо перехватывать все исключения.
- Отмена незавершенных операция при невосстановимых исключениях.
- Сокрытие деталей реализации для сохранения контракта. Можно также добавлять данные в exception.Data.

## Необработанные исключения
Если CLR находит необработанное исключения - поток, в котором оно возникло, завершается.