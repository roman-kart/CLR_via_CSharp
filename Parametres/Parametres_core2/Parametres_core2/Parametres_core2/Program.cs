using System;

namespace Parametres_core2
{
    class Program
    {
        public static void RefAndOut(ref int iRef, out int iOut, int iIn)
        {
            iRef = 10;
            iOut = 100;
            iIn = 1000;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int iRef = 1;
            int iOut = 2;
            int iIn = 3;
            Console.WriteLine($"Before: iRef = {iRef}, iOut = {iOut}, iIn = {iIn}");
            RefAndOut(ref iRef, out iOut, iIn);
            Console.WriteLine($"After: iRef = {iRef}, iOut = {iOut}, iIn = {iIn}");

            // params
            Console.WriteLine("testParams(): ");
            testParams testParams = new testParams();

            Console.WriteLine("testParams(1): ");
            testParams = new testParams(1);

            Console.WriteLine("testParams(1, 2): ");
            testParams = new testParams(1, 2);

            Console.WriteLine("testParams(1, 2, 3): ");
            testParams = new testParams(1, 2, 3);

            Console.WriteLine("testParams(1, 2, 3, 4): ");
            testParams = new testParams(1, 2, 3, 4);

            Console.WriteLine("testParams(1, 2, 3, 4, 5): ");
            testParams = new testParams(1, 2, 3, 4, 5);

            Console.WriteLine("testParams(1, 2, 3, 4, 5, 6): ");
            testParams = new testParams(1, 2, 3, 4, 5, 6);

            Console.ReadKey();
        }
    }
}
