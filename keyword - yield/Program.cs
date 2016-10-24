using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keyword___yield
{
    class Program
    {
        static List<int> list = new List<int>();
        static void FillValues()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
        }
        static void Main(string[] args)
        {
            /*
            uses of 'yield' keyword:
            1. custom iteration without temp collection
            2. stateful iteration
            

            It returns values one by one as it finds the first, then second, next, next, etc
            in foreach or other iteration, whenever it finds matching value,
            it immediately returns value and gets back to that function/method and continues for next matching
            // can be checked by using debug mode
            */

            FillValues();
            // situation 1
            Console.WriteLine("Situation 1: Simple list iteration");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }


            
            // situation 2
            /*
            in it, first, Filter1() is executed completely and returns a list;
            then this below foreach loop iterates through all those items one by one
            */
            Console.WriteLine("Situation 2: Filter using temp list");
            foreach (int i in Filter1())
            {
                Console.WriteLine(i);
            }


            // situation 3: Custom Iteration using yield
            /*
            in it, Filter2() is not completely executed; it returns the values one by one as it finds matching
            let say, Filter2() returns 1st value it had, then control moved to below foreach loop, this will display that value,
            then, control moved to Filter2() for matching next value,
            if that gets new matching value, it returns control to below loop and displays it;
            and so on for all values.
            */
            Console.WriteLine("Situation 3: (Custom Iteration) Filter using yield");
            foreach (int i in Filter2())
            {
                Console.WriteLine(i);
            }


            // situation 4: Stateful Custom Iteration using yield
            /*
            in it, Filter2() is not completely executed; it returns the values one by one as it finds matching
            let say, Filter2() returns 1st value it had, then control moved to below foreach loop, this will display that value,
            then, control moved to Filter2() for matching next value,
            if that gets new matching value, it returns control to below loop and displays it;
            and so on for all values.
            */
            Console.WriteLine("Situation 4: (Stateful Custom Iteration) using yield");
            foreach (int i in RunningTotal())
            {
                Console.WriteLine(i);
            }




            Console.ReadKey();
        }
        static IEnumerable<int> Filter1()
        {
            List<int> temp = new List<int>();
            foreach (int i in list)
            {
                if (i > 3)
                {
                    temp.Add(i);   
                }
            }
            return temp;
        }

        static IEnumerable<int> Filter2()
        {
            foreach (int i in list)
            {
                if(i > 3)
                {
                    yield return i;
                }
            }
        }

        static IEnumerable<int> RunningTotal()
        {
            // for second time, control gets into this function, the value of 'runningtotal' variable is preserved due to yield

            int runningtotal = 0;
            foreach (int i in list)
            {
                runningtotal += i;
                yield return runningtotal;
            }
        }

    }
}
