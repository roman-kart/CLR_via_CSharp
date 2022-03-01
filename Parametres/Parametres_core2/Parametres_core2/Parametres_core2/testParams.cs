using System;
using System.Collections.Generic;
using System.Text;

namespace Parametres_core2
{
    class testParams
    {
        public int i;
        public List<int> ints;
        public testParams()
        {
            Console.WriteLine("\tdefault");
        }
        public testParams(int i)
        {
            Console.WriteLine("\ttestParams(int i)");
        }
        public testParams(int i, int ii)
        {
            Console.WriteLine("\ttestParams(int i, int ii)");
        }
        public testParams(int i, int ii, int iii)
        {
            Console.WriteLine("\ttestParams(int i, int ii, int iii)");
        }
        public testParams(int i, int ii, int iii, int iiii, int iiiii)
        {
            Console.WriteLine("\ttestParams(int i, int ii, int iii, int iiii, int iiiii)");
        }
        public testParams(int i, params int[] ints)
        {
            Console.WriteLine("\tparams");
        }
    }
}
