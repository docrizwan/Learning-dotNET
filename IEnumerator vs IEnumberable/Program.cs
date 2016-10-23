using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerator_vs_IEnumberable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            IEnumerable, IEnumerator and IQueryable are stateless
            
            */
            


            // initial data
            List<int> listyears = new List<int>();
            listyears.Add(1990);
            listyears.Add(1991);
            listyears.Add(1992);
            listyears.Add(1993);
            listyears.Add(1994);
            listyears.Add(1995);


            // using LIST: iterate through data
            Console.WriteLine("List:");
            foreach (var year in listyears)
            {
                Console.WriteLine("{0}", year);
            }

            // using IENUMERABLE: iterate through data
            Console.WriteLine("IEnumerable:");
            IEnumerable<int> ienumyears = (IEnumerable<int>)listyears;
            foreach (var year in ienumyears)
            {
                Console.WriteLine("{0}", year);
            }

            // using IENUMERATOR: iterate through data
            Console.WriteLine("IEnumerator:");
            IEnumerator<int> ienumrtryears = listyears.GetEnumerator();
            while (ienumrtryears.MoveNext())
            {
                Console.WriteLine("{0}", ienumrtryears.Current.ToString());
            }


            // PART 2: IEnumerator
            // IEnumerator remembers its state
            Console.WriteLine("IEnumerator: Cursor state remembering example");
            Iterator1(listyears.GetEnumerator());

            // PART 3: IEnumerable
            // IEnumerable does not remember its state
            Console.WriteLine("IEnumerable: Cursor state not remembering example");
            Iterator3((IEnumerable<int>)listyears);



            Console.ReadKey();
        }

        static void Iterator1(IEnumerator<int> o)
        {
            Console.WriteLine("Iterator1:");
            while (o.MoveNext())
            {
                Console.WriteLine(o.Current.ToString());

                if (Convert.ToInt16(o.Current) > 1992)
                {
                    // here it sends its current state to the function below (that starts from its current state)
                    Iterator2(o);
                }


            }

        }
        static void Iterator2(IEnumerator<int> o)
        {
            Console.WriteLine("Iterator2:");
            while (o.MoveNext())
            {
                Console.WriteLine(o.Current.ToString());
            }
        }

        static void Iterator3(IEnumerable<int> o)
        {
            Console.WriteLine("Iterator3:");
            foreach(int i in o)
            {
                Console.WriteLine(i.ToString());

                if (i > 1992)
                {
                    // it sends its the whole IEnumerable to other function, for first value satistying IF condition,
                    // that function iterates through all the values and returns to this function,
                    // this again checks value for next value satistying condition, and passes whole data collection to that function again,
                    // that again iterates and returns until it falses the condition, this function iterates for all values in collection until the collection ends,
                    // whatever and whenever it finds value statisfying condition, it passes to Iterator4() method.
                    Iterator4(o);
                }
            }

        }
        static void Iterator4(IEnumerable<int> o)
        {
            Console.WriteLine("Iterator4:");
            foreach (int i in o)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
