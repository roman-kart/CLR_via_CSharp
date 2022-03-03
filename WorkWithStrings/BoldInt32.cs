using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithStrings
{
    internal sealed class BoldInt32 : IFormatProvider, ICustomFormatter
    {
        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public object? GetFormat(Type? formatType)
        {
            throw new NotImplementedException();
        }
    }
}
