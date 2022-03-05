using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    class Arrays
    {
        public static void Do()
        {
            var digits = new decimal[12000000]; // будет сразу же выделено 200 мегабайт на хранение данных массива

            int[,] digits2 = new int[10, 20];

            int[][] digitsJagged = new int[3][];

            // преобразование массивов из ссылочных типов
            Product[] products = new Product[]
            {
                new Product{ Name = "Apple", Price = 100},
                new Product{ Name = "Milk", Price = 80}
            };

            // неявное преобразование к родительскому типу
            Object[] objects = products;

            // явное преобразование (компилируется, но происходит ошибка времени выполнения)
            // String[] strings = (String[])objects;

            // проверка при помощи as
            var transformed = objects as String[];
            if (transformed != null)
            {
                String[] strings = (String[])objects;
            }
            else
            {
                Console.WriteLine("Can't transform objects as String[]");
            }

            // явное преобразование, выполнится успешно
            Product[] productsTransformed = (Product[])objects;

            // преобразование массивов из значимых типов
            Int32[] ints = new int[] { 1, 2, 3 };

            // компилируется с ошибкой, так как приведение значимых типов запрещено
            // Object[] objects1 = (Object[])ints;

            // для преобразования значимых типов можно использовать метод Array.Copy
            Object[] objectsInt = new object[ints.Length];
            Array.Copy(ints, objectsInt, ints.Length);
            foreach (var item in objectsInt)
            {
                Console.WriteLine(item);
            }

            // Array.Copy()
            ProductComp[] productComps = new ProductComp[]
            {
                new ProductComp
                {
                    Name = "Melon",
                    Price = 60
                },
                new ProductComp
                {
                    Name = "Coca-cola",
                    Price = 100
                }
            };

            // неявное преобразование 
            IComparable<ProductComp>[] comparables = productComps;

            // более быстрое копирование при помощи System.Buffer
            int length = int.MaxValue / 16;
            var randInts = GetRandomInt32Array(length: length);
            int[] randIntDestination = new int[randInts.Length];
            // 177
            var arrayCopyTime = CustomTimer.DefifneArrayCopyTime<int[], int[], int>(Array.Copy, randInts, randIntDestination, randInts.Length);

            int[] randIntsBuffer = GetRandomInt32Array(length: length);
            int[] randIntDestinationBuffer = new int[randIntsBuffer.Length];
            // 43
            var bufferCopyTime = CustomTimer.DefifneBlockCopyTime<int[], int[]>(Buffer.BlockCopy, randIntsBuffer, randIntDestinationBuffer, randIntDestinationBuffer.Length);

            Console.WriteLine($"Array.Copy = {arrayCopyTime}");
            Console.WriteLine($"Buffer.BlockCopy = {bufferCopyTime}");

            SystemArray.Do();
        }
        private static int[] GetRandomInt32Array(int length = 100, int min = 0, int max = int.MaxValue)
        {
            int[] result = new int[length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = RandomNumberGenerator.GetInt32(min, max);
            }
            return result;
        }
    }
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class CustomTimer
    {
        public static decimal DefifneArrayCopyTime<TSourceArray, TDestinationArray, TLength>(Action<TSourceArray, TDestinationArray, TLength> copyMethod, TSourceArray sourceArray, TDestinationArray destinationArray, TLength length)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            copyMethod.Invoke(sourceArray, destinationArray, length);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public static decimal DefifneBlockCopyTime<TSourceArray, TDestinationArray>(Action<TSourceArray, int, TDestinationArray, int, int> copyMethod, TSourceArray sourceArray, TDestinationArray destinationArray, int count, int offsetSource = 0, int offsetDest = 0)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            copyMethod.Invoke(sourceArray, offsetSource, destinationArray, offsetDest, count);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }

    class ProductComp : Product, IComparable, IComparable<ProductComp>
    {
        public int CompareTo(object obj)
        {
            var forCompare = obj as Product;
            if (forCompare != null)
            {
                return CompareTo(forCompare);
            }
            throw new TypeAccessException("Не удалось преобразовать аргумент в тип Product");
        }
        public int CompareTo(Product product)
        {
            return this.Name.CompareTo(product.Name);
        }

        public int CompareTo(ProductComp other)
        {
            return this.CompareTo((Product)other);
        }
    }
}
