using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Exceptions
{
    internal class CanGenerateException
    {
        public static int GetIntOrExcept()
        {
            var result = RandomNumberGenerator.GetInt32(-100, 100);
            // если число четное
            if (result % 2 == 0)
            {
                throw new Exception("The digit is even");
            }
            else
            {
                return result;
            }
        }
        public static void Step2()
        {
            try
            {
                throw new Exception("Step2::try");
            }
            catch
            {
                Console.WriteLine("Step2::catch");
                throw new Exception("Step2::Exception");
            }
            finally
            {
                Console.WriteLine("Step2::finally");
            }
        }
        public static void Step1()
        {
            try
            {
                Console.WriteLine("Step1::try (Before step2)");
                Step2();
                Console.WriteLine("Step1::try (After step2)");
            }
            catch (Exception)
            {
                Console.WriteLine("Step1::catch");
            }
            finally
            {
                Console.WriteLine("Step1::finally");
            }
        }
    }
}
