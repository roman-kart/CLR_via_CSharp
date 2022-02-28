using SystemObject;
using SystemObject.Delivery;
using SystemObject.Restaurant;
using DeliveryPizza = SystemObject.Delivery.Pizza;
using RestaurantPizza = SystemObject.Restaurant.Pizza;

#region Type reflection
Manager Manager = new Manager(1, "Alex", 30000m, new List<Employee>());
Employee employee = Manager;
object managerObject = Manager;
object notManagerObject = "I'm not a manager";

Manager testManager = Manager as Manager;
if (testManager != null)
{
    Console.WriteLine(testManager.ToString());
}
else
{
    Console.WriteLine("Not a manager");
}

testManager = employee as Manager;
if (testManager != null)
{
    Console.WriteLine(testManager.ToString());
}
else
{
    Console.WriteLine("Not a manager");
}

testManager = notManagerObject as Manager;
if (testManager != null)
{
    Console.WriteLine(testManager.ToString());
}
else
{
    Console.WriteLine("Not a manager");
}

Employee testEmployee = Manager as Employee;
if (testEmployee != null)
{
    Console.WriteLine(testEmployee.ToString());
}
else
{
    Console.WriteLine("Not an employee");
}

testEmployee = managerObject as Employee;
if (testEmployee != null)
{
    Console.WriteLine(testEmployee.ToString());
}
else
{
    Console.WriteLine("Not an employee");
}

testEmployee = notManagerObject as Employee;
if (testEmployee != null)
{
    Console.WriteLine(testEmployee.ToString());
}
else
{
    Console.WriteLine("Not an employee");
}
#endregion

#region Ambiguos
//Pizza Pizza = new Pizza();

DeliveryPizza DeliveryPizza = new DeliveryPizza();
RestaurantPizza RestaurantPizza = new RestaurantPizza();
#endregion
