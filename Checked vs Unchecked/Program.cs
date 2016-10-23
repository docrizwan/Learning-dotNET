using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checked_vs_Unchecked
{
    class Program
    {
        static void Main(string[] args)
        {

            // these keywords used to identify the overflow or bypass the overflow of the destination variable
            // it means the expression on right side of assignment operator is if creating overflow or we need to bypass that overflow
            // we use 'checked' or 'unchecked' keywords


            // both variables have the max value an INT32 can hold
            int x = int.MaxValue;
            int y = x;

            // ------------ part 1 ------------ \\
            // this is twice than the capacity of INT32, should throw exception of overflow, but it does not.
            // it returns -2 in 'z'
            // default behavious is: unchecked
            int z = x + y;

            // ------------ part 2 ------------ \\
            // now this throws exception of overflow
            try
            {
                z = checked(x + y);
            }
            catch (OverflowException ex)
            {

                Console.WriteLine(ex.Message);
            }


            // ------------ part 3 ------------ \\
            // now this does not throw exception of overflow
            // same as default behaviour
            // 'unchecked' works as default behaviour is
            z = unchecked(x + y);


            // ------------ part 4 ------------ \\
            // default behaviour may be changed
            const int a = int.MaxValue;
            const int b = a;
            // default is: checked
            // see the tooltip by un-commenting below
            // compiler sends Error
            //int c = a + b;

            // now for by-pass, use 'unchecked'
            // compiler sends warning
            int c = unchecked(a + b);


            Console.ReadKey();

        }
    }
}
