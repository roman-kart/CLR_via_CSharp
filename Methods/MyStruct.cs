using System;
using System.Collections.Generic;
using System.Text;

namespace Methods
{
    struct MyStruct
    {
        public int i;
        public object obj;
        public MyStruct(int i, object obj)
        {
            this.i = i;
            this.obj = obj;
        }
        public static MyStruct operator +(MyStruct ms1, MyStruct ms2)
        {
            return new MyStruct(ms1.i + ms2.i, ms1.obj);
        }
    }
}
