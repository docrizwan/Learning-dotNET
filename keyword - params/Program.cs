using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keyword___params
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total is: {0}", Add(12, 12, 12, 23, 23, 23, 25));
            Console.WriteLine("Total is: {0}", Add(12, 12, 12, 23, 23, 23, 25, 25, 25, 36, 36, 36, 36,36, 36, 47, 56, 23, 14, 34, 214234, 2342, 12, 124, 216));
            Console.WriteLine("Total is: {0}", Add(76,76,33,27,34, 76,965,324,54,345,3458,123,657,768,234,12, 12, 12, 23, 23, 23, 25));

            Console.ReadKey();
        }

        /*
        INPUT: sequence of INT parameters
        OUTPUT: returns INT sum of numbers
        */
        public static int Add(params int[] NumbersList)
        {
            var total = 0;
            foreach(int i in NumbersList)
            {
                total += i;
            }
            return total;
        }

    }
}
