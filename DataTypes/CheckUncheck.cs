using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class CheckUncheck
    {
        public static void Do()
        {
            // Примитивные типы данных - типы, которые используются чаще всего
            int i = 10;
            double d = 20;
            byte b = 10;
            // decimal d = 10; // неверно, так как Decimal не является примитивным типом, а значит checked и unckecked не будут работать, т.к. нет IL-команд для манипуляции с Decimal
            // checked и unchecked
            // unchecked
            int uncheck = int.MaxValue - 1;
            uncheck = unchecked(uncheck + 2);
            Console.WriteLine(uncheck);

            // checked
            int check = int.MaxValue - 1;
            // check = checked(check + 2); // ошибка 
            Console.WriteLine(check);

            // проверка в блоке кода
            checked
            {
                for (int j = 0; j < int.MaxValue; j += (int.MaxValue - 5))
                {
                    Console.WriteLine(j);
                }
            }
            // можно включить проверку на переполнеие по умолчанию в настройках проекта
        }
    }
}
