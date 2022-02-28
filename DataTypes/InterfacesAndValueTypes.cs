using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public interface MyInterface
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public interface MyChange
    {
        public void ChangeName(string name);
    }
    public struct MyStructInterface : MyInterface, MyChange
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public void ChangeName(string name)
        {
            Name = name;
        }
    }
    internal class InterfacesAndValueTypes
    {
        public static void Do()
        {
            MyStructInterface myStructInterface = new MyStructInterface() { Name = "Init", Description = "Init"};
            
            MyInterface myInterface = myStructInterface; // неявная упаковка
            myInterface.Name = "Interface";
            myInterface.Description = "Interface";
            Console.WriteLine("Before: ");
            Console.WriteLine($"Struct: {myStructInterface.Name}, {myStructInterface.Description}");
            Console.WriteLine($"Inter: {myInterface.Name}, {myInterface.Description}");

            Object a = new MyStructInterface() { Name = "Init1", Description = "Init1" };
            // не изменится, так как происходит распаковка и измененыый распакованный объект удаляется
            ((MyStructInterface)a).ChangeName("Obj1");
            Console.WriteLine(((MyStructInterface)a).Name);

            // изменится, так как просто приводим упакованный объект к интерфейсу
            ((MyChange)a).ChangeName("ObjInterface1");
            Console.WriteLine(((MyStructInterface)a).Name);
        }
    }
}
