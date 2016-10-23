using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Named_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {

            // this makes ambiguity bcz a lot are the parameters
            // may be placed at wrong place
            // sequence of parameters should be strictly followed, cannot bear any inorder parameter
            string s1 = PersonWithAllNames("Rizwan Ali",
                                "Rizwan",
                                "Ali",
                                "Doc",
                                "Rizwan");
            Console.WriteLine("{0}", s1);

            // Named Parameters
            // more cleared parameters
            string s2 = PersonWithAllNames(Name : "Rizwan Ali",
                                FirstName : "Rizwan",
                                LastName : "Ali",
                                PetName : "Doc",
                                ShortName : "Rizwan");
            Console.WriteLine("{0}", s2);

            // Named Parameters
            // sequence of parameters is allowed to be changed
            string s3 = PersonWithAllNames(PetName : "Doc",
                                FirstName : "Rizwan",
                                ShortName : "Rizwan",
                                LastName : "Ali",
                                Name : "Rizwan Ali");
            Console.WriteLine("{0}", s3);


            Console.ReadKey();

        }
        static string PersonWithAllNames(string Name, string FirstName, string LastName, string PetName, string ShortName)
        {
            return Name + " whose first & last names are " + FirstName +" and " + LastName + " and petname is "+PetName+", he is simply called \""+ShortName+"\"";

        }
    }
}
