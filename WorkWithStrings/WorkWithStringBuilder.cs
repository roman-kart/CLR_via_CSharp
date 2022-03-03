using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace WorkWithStrings
{
    internal class WorkWithStringBuilder
    {
        public static void Do()
        {
            int stringLength = 200001;
            int fragmentLength = 1;

            TimerDecorator<int, int, string> timerDecorator = new TimerDecorator<int, int, string>(GetStrings);
            var result = timerDecorator.DetemineExecutionTime(stringLength, fragmentLength, out double duration);
            Console.WriteLine($"String: duration = {duration}, result length = {result.Length}");

            TimerDecorator<int, int, string> timerDecoratorBuilder = new TimerDecorator<int, int, string>(GetStringsStringBuilder);
            result = timerDecorator.DetemineExecutionTime(stringLength, fragmentLength, out duration);
            Console.WriteLine($"StringBuilder: duration = {duration}, result length = {result.Length}");
        }
        private static string GetStrings(int count = 100, int wordLength = 10)
        {
            string resultWord = "";
            var upperSymbolsSequence = 1040;
            var lowerSymbolSequence = 1072;
            string newWordStr;
            for (int i = 0; i < count; i++)
            {
                char[] newWord = new char[wordLength];
                for (int j = 0; j < wordLength; j++)
                {
                    char currentChar = (char)RandomNumberGenerator.GetInt32(upperSymbolsSequence, lowerSymbolSequence);
                    newWord[j] = currentChar;
                }
                newWordStr = String.Concat(newWord);
                resultWord += newWordStr;
            }
            return resultWord;
        }
        private static string GetStringsStringBuilder(int count = 100, int wordLength = 10)
        {
            var resultWord = new StringBuilder();
            var upperSymbolsSequence = 1040;
            var lowerSymbolSequence = 1072;
            string newWordStr;
            for (int i = 0; i < count; i++)
            {
                char[] newWord = new char[wordLength];
                for (int j = 0; j < wordLength; j++)
                {
                    char currentChar = (char)RandomNumberGenerator.GetInt32(upperSymbolsSequence, lowerSymbolSequence);
                    newWord[j] = currentChar;
                }
                newWordStr = String.Concat(newWord);
                resultWord.Append(newWordStr);
            }
            return resultWord.ToString();
        }
    }
}
