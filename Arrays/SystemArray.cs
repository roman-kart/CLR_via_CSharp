using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class SystemArray
    {
        public static void Do()
        {
            int[] digits = { 1, 2, 3, 4 };
            string[] words = { "assfsfd", "asd", "qwerty", "qaz" };
            // ShowElements(digits); // ошибка! массивы значимых типов не содержат реализации для родительских типов
            ShowElements(words);
        }
        private static void ShowElements(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
