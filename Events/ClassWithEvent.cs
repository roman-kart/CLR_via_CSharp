using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class ClassWithEvent
    {
        public static void Do()
        {
        }
    }
    internal class SomethingHappendEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
