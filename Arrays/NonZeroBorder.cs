using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class NonZeroBorder
    {
        public static void Do()
        {
            int[] lengths = {3, 4};
            int[] lowerBounds = { -9, 10 };
            var arr = Array.CreateInstance(typeof(string), lengths, lowerBounds);
            string[,] arrStrs = (string[,])arr;

            int lowerBoundFirst = arrStrs.GetLowerBound(0);
            int upperBoundFirst = arrStrs.GetUpperBound(0);

            if (lowerBoundFirst > upperBoundFirst)
            {
                int tmp = lowerBoundFirst;
                lowerBoundFirst = upperBoundFirst;
                upperBoundFirst = tmp;
            }

            int lowerBoundSecond = arrStrs.GetLowerBound(1);
            int upperBoundSecond = arrStrs.GetUpperBound(1);

            if (lowerBoundSecond > upperBoundSecond)
            {
                int tmp = lowerBoundSecond;
                lowerBoundSecond = upperBoundSecond;
                upperBoundSecond = tmp;
            }

            for (int i = lowerBoundFirst; i <= upperBoundFirst; i++)
            {
                for (int j = lowerBoundSecond; j <= upperBoundSecond; j++)
                {
                    arrStrs[i, j] = $"{i}:{j}";
                }
            }

            foreach (var item in arrStrs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
