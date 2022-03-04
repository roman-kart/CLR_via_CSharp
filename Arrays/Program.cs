using System;
using System.Threading;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var digits = new decimal[12000000]; // будет сразу же выделено 200 мегабайт на хранение данных массива

            int[,] digits2 = new int[10, 20];

            int[][] digitsJagged = new int[3][];
        }
    }
}
