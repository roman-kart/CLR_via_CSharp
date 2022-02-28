using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Product product = new Product();
            //Console.WriteLine(product.Name);
            //Console.WriteLine(product.DateTime);
            //Console.WriteLine(product.MyStruct.i);
            //Console.WriteLine(product.MyStruct.obj);

            //InitFields initFields = new InitFields();
            //Console.WriteLine(initFields.i);

            //InitFieldsChild initFieldsChild = new InitFieldsChild();
            //Console.WriteLine(initFieldsChild.i);
            //Console.WriteLine(initFieldsChild.str);

            //Console.WriteLine(StaticFieldsInit.i);



            List<Action> strings = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                var meth = () => { Console.WriteLine(i); };
                strings.Add(meth);
            }
            foreach (var item in strings)
            {
                item.Invoke();
            }
        }
    }
}
