using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Attributes
{
    internal class ColoriseWrite
    {
        public static TResult Do<TArgs, TResult>(System.Delegate delegateArg, TArgs args)
        {
            // если пользователь передал пустой делегат
            if (delegateArg == null)
            {
                return default(TResult); // завершаем работу метода
            }
            // если необходимо раскрасить консоль
            if (delegateArg.GetType().IsDefined(typeof(ConsoleForeignAttribute), false))
            {
                var atrs = delegateArg.GetType().GetCustomAttributes(typeof(ConsoleForeignAttribute), false);
                // если объявлен только 1 атрибут
                if (atrs.Length == 1)
                {
                    var atr = (ConsoleForeignAttribute)atrs[0]; // получаем атрибут
                    var originalForeign = Console.ForegroundColor; 
                    Console.ForegroundColor = atr.ForeignColor;
                    TResult result = (TResult)delegateArg.DynamicInvoke(args); // получаем результат
                    Console.ForegroundColor = originalForeign;
                    return result;
                }
                else
                {
                    throw new Exception("Должен быть только 1 атрибут ConsoleForeignAttribute");
                }
            }
            // если не надо раскрашивать консоль
            else
            {
                return (TResult)delegateArg.DynamicInvoke(); // вызываем выполнение делегата
            }
        }
    }
}
