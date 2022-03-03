using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkWithStrings
{
    internal class TimerDecorator<T1, T2, TResult>
    {
        private Func<T1, T2, TResult> _decorated;
        public TimerDecorator(Func<T1, T2, TResult> forDecorate)
        {
            _decorated = forDecorate;
        }
        public TResult DetemineExecutionTime(T1 parametre1, T2 parametre2, out double executionTime)
        {
            var timer = new Stopwatch();
            

            timer.Start();
            TResult result = _decorated.Invoke(parametre1, parametre2);
            timer.Stop();
            executionTime = timer.ElapsedMilliseconds;
            
            timer.Reset();
            return result;
        }
    }
}
