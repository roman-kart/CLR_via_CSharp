using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITestVirtualMethods
    {
        public void VirtualSealed();
        public virtual void VirtualNonSealed()
        {
            Console.WriteLine("ITestVirtualMethods.VirtualNonSealed");
        }
    }
    internal class TestInterface : ITestVirtualMethods
    {
        public void VirtualSealed()
        {
            Console.WriteLine("TestInterface.VirtualSealed");
        }
        public void VirtualNonSealed()
        {
            Console.WriteLine("TestInterface.VirtualNonSealed");
        }
    }
}
