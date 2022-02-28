using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersAndTypes
{
    internal class SameMethodSignature
    {
        public void Something()
        {
            Console.WriteLine("SameMethodSignature.Something");
        }
        public virtual void Som()
        {
            Console.WriteLine("SameMethodSignature.Som");
        }
    }
    internal class SameMethodSignatureChild : SameMethodSignature
    {
        // new, так как метод с такой сигнатурой уже существует
        public new void Something()
        {
            Console.WriteLine("SameMethodSignatureChild.Something");
        }
        // override, так как в базовом классе есть виртуальный метод с такой же сигнатурой
        public override void Som()
        {
            Console.WriteLine("SameMethodSignatureChild.Som");
        }
    }
}
