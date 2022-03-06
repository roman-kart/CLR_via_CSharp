using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
    public class ConsoleForeignAttribute : System.Attribute
    {
        public ConsoleColor ForeignColor { get; set; }
        public ConsoleForeignAttribute(ConsoleColor foreignColor)
        {
            ForeignColor = foreignColor;
        }
        public override bool Match(object? obj)
        {
            // если передан пустой объект
            if (obj == null)
            {
                return false;
            }

            // объекты разных типов не могут быть равны
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            ConsoleForeignAttribute attr = (ConsoleForeignAttribute)obj; // получаем атрибут для сравнения
            // если цвета совпадают
            if (this.ForeignColor == attr.ForeignColor)
            {
                return true; // атрибуты равны
            }
            return false;
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            // если передан пустой объект
            if (obj == null)
            {
                return false;
            }

            // объекты разных типов не могут быть равны
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            ConsoleForeignAttribute attr = (ConsoleForeignAttribute)obj; // получаем атрибут для сравнения
            // если цвета совпадают
            if (this.ForeignColor == attr.ForeignColor)
            {
                return true; // атрибуты равны
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Int32)ForeignColor;
        }
    }
}
