using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class TestStackTrace
    {
        public static void DifferenceThrow()
        {
            Console.WriteLine("\nCatchThrowNew");
            try
            {
                CatchThrowNew();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nCatchThrow");
            try
            {
                CatchThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void GenerateEx()
        {
            throw new Exception("AAAAAAA");
        }
        public static void CatchThrowNew()
        {
            try
            {
                GenerateEx();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CatchThrow()
        {
            try
            {
                GenerateEx();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
