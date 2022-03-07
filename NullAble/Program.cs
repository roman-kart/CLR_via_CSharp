Nullable<Int32> nullInt = null;
Nullable<Int32> notNullInt = 10;

Console.WriteLine($"nullInt = {nullInt.HasValue}");
Console.WriteLine($"notNullInt = {notNullInt}");

// with null
nullInt++;
nullInt--;
nullInt += nullInt;
nullInt -= 2;
nullInt *= nullInt;
nullInt /= 5;
Console.WriteLine($"nullInt = {nullInt.HasValue}");

notNullInt++;
notNullInt--;
notNullInt *= notNullInt;
notNullInt /= 5;
notNullInt += notNullInt;
notNullInt -= 3;
Console.WriteLine($"notNullInt = {notNullInt}");

// оператор объединения null-совместимых типов
int i = NullValues.GetNullAble() ?? int.MinValue;
Console.WriteLine(i);

i = NullValues.GetNullAble() ?? NullValues.GetNullAble() ?? NullValues.GetNullAble() ?? int.MaxValue; // несколько сравнений
Console.WriteLine(i);

int? a = null;
Object obj = a;
NullValues.ChangeIntObj(a);
Console.WriteLine(a);

a = 5;
obj = a;
Console.WriteLine((Int32?)obj);
Console.WriteLine((Int32)obj);

a = null;
obj = a;
Console.WriteLine((Int32?)obj);
// Console.WriteLine((Int32)obj); // NullReferenceException

int? aa;
aa = null;
// Console.WriteLine(aa.GetType()); // NullReferenceException
aa = 5;
Console.WriteLine(aa.GetType()); // Int32

int? aaa = 5;
Console.WriteLine(((IComparable)aaa).CompareTo(5));
aaa = null;
// Console.WriteLine(((IComparable)aaa).CompareTo(5)); // NullReferenceException