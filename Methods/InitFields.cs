using System;
using System.Collections.Generic;
using System.Text;

namespace Methods
{
    class InitFields
    {
        public int i = 5;
        public string str = "Hello there!";
        public DateTime DateTime = new DateTime();
        public InitFields()
        {
            i = 100;
            str = "Change the world, my final message, goodbye!";
        }
        public InitFields(int i)
        {
            this.i = i;
        }
        public InitFields(int i, string str)
        {
            this.i = i;
            this.str = str;
        }
        public InitFields(int i, string str, DateTime dateTime)
        {
            this.i = i;
            this.str = str;
            this.DateTime = dateTime;
        }
    }
    class InitFieldsChild : InitFields
    {
        public int iChild = 10;
        public InitFieldsChild() { }
        public InitFieldsChild(int i, string str, DateTime dateTime, int iChild) : base(i, str, dateTime)
        {
            this.iChild = iChild;
        }
    }
}
