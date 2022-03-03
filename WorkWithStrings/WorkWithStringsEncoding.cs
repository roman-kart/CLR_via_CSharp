using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithStrings
{
    internal class WorkWithStringsEncoding
    {
        public static void Do()
        {
            string str = "Привет, я подсяду?";
            Encoding encoding = Encoding.UTF8;

            var encondingStr = encoding.GetBytes(str);
            Console.WriteLine(BitConverter.ToString(encondingStr));

            var decodedStr = Encoding.UTF8.GetString(encondingStr);
            Console.WriteLine(decodedStr);

            foreach (var encodingInfo in Encoding.GetEncodings())
            {
                var encodingItem = encodingInfo.GetEncoding();
                Console.WriteLine($"{encodingInfo.Name}" +
                    $"\n\t{encodingInfo.DisplayName}" +
                    $"\n\tCodePage: {encodingInfo.CodePage}" +
                    $"\n\t{encodingItem.BodyName}" +
                    $"\n\t{encodingItem.WebName}" +
                    $"\n\tIsBrowserDisplay: {encodingItem.IsBrowserDisplay}" +
                    $"\n\tIsSingleByte: {encodingItem.IsSingleByte}" +
                    $"\n\tIsBrowserSave: {encodingItem.IsBrowserSave}" +
                    $"\n\tIsMailNewsDisplay: {encodingItem.IsMailNewsDisplay}" +
                    $"\n\tIsMailNewsSave: {encodingItem.IsMailNewsSave}" +
                    $"\n\tWindowsCodePage: {encodingItem.WindowsCodePage}");
            }

            // decoding partitial data
            var data = Encoding.UTF8.GetBytes("Цвер, Іван");
            int firstPartLength = 5;
            int secondPartLength = data.Length - firstPartLength;

            byte[] data1 = new byte[firstPartLength];
            byte[] data2 = new byte[secondPartLength];
            
            Array.Copy(data, 0, data1, 0, firstPartLength);
            Array.Copy(data, firstPartLength, data2, 0, secondPartLength);
            
            var decoder = Encoding.UTF8.GetDecoder();

            char[] result1 = new char[decoder.GetCharCount(data1, false)];
            char[] result2 = new char[decoder.GetCharCount(data2, false)];

            int count1 = decoder.GetChars(data1, 0, data1.Length, result1, 0);
            int count2 = decoder.GetChars(data2, 0, data2.Length, result2, 0);

            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine($"Count1 = {count1}:");
            foreach (var decodedSymbol in result1)
            {
                Console.WriteLine($"\t{decodedSymbol}");
            }
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Count2 = {count2}:");
            foreach (var decodedSymbol in result2)
            {
                Console.WriteLine($"\t{decodedSymbol}");
            }
        }
    }
}
