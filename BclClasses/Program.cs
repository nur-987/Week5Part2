using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BclClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringExamples();

            //DateTimeExample();

            //DateTimeDifference();

            Console.ReadLine();
        }

        static void StringExamples()
        {
            //EXAMPLE 1
            //string compare => returns int

            string str1 = "hello";
            string str2 = "really";
            int res = str1.CompareTo(str2);
            Console.WriteLine("result of compare is: " + res);

            string str3 = "great";
            string str4 = "Great";
            int res2 = String.Compare(str3, str4, ignoreCase: true);
            Console.WriteLine("result of compare is: " + res2);

            //EXAMPLE 2
            Console.WriteLine("input string");
            var userInput = Console.ReadLine();
            Console.WriteLine(userInput.ToUpper());
            Console.WriteLine(userInput.ToLower());

            //EXAMPLE 3
            var str5 = "this_Is_a_SAmPLe_seSSiOn";
            //output: This_is_a_sample_session
            Console.WriteLine("correct format: ");
            Console.WriteLine(char.ToUpper(str5[0]) + str5.Substring(1).ToLower());

            //EXAMPLE 4
            var str6 = "I love to code in c#";
            string[] strArry = str6.Split(' ');
            foreach (string myString in strArry.Reverse())
            {
                var newStr = char.ToUpper(myString[0]) + myString.Substring(1).ToLower();
                Console.WriteLine(newStr);
            }

            //EXAMPLE 5
            string Str1 = null;
            if (String.IsNullOrEmpty(Str1))
            {
                Console.WriteLine("Is null or empty");
            }

            string Str2 = " ";
            if (String.IsNullOrEmpty(Str2))
            {
                Console.WriteLine("Is null or empty");
            }
            else if (String.IsNullOrWhiteSpace(Str2))
            {
                Console.WriteLine("Is null or whitespace");
            }

            string str7 = "            This is a sample ####**     ";
            char[] chartoRemove = { ' ', '#', '*' };
            var trimStr = str7.Trim(chartoRemove);
            Console.WriteLine(trimStr);

            string str8 = "            This is a     sample     ";
            var trimStr2 = str8.Trim(); //will not remove the space in between
            Console.WriteLine(trimStr2);

        }  

        static void DateTimeExample()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);

            Console.WriteLine(dt.Year);

            Console.WriteLine(dt.ToShortDateString());
            Console.WriteLine(dt.ToShortTimeString());
            Console.WriteLine(dt.ToLongTimeString());
            Console.WriteLine(dt.ToLongDateString());

            Console.WriteLine(dt.ToString("dd-MM-yy"));

            string str = "09/02/2020";
            DateTime.TryParse(str, out DateTime dt2);
            Console.WriteLine(dt2);

            DateTime dtObj1 = new DateTime(2020, 09, 13, 08, 20, 19);
            DateTime dtObj2 = new DateTime(2021, 09, 05, 16, 30, 20);

            var subAnsw = dtObj2.Subtract(dtObj1);
            Console.WriteLine("day difference" + subAnsw);

            if (dtObj1.Equals(dtObj2))
            {
                Console.WriteLine("Both equal");
            }

            DateTime dtObj3 = DateTime.Now;
            DateTime dtObj4 = DateTime.Now;

            if (dtObj3.Equals(dtObj4))
            {
                Console.WriteLine("Both equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
        }

        static void DateTimeDifference()
        {
            Console.WriteLine("input date time to compare");
            Console.WriteLine("use this format: DD/MM/YYY");

            string strDate = Console.ReadLine();

            bool correct = DateTime.TryParse(strDate, out DateTime dtInput);
            if (correct)
            {
                Console.WriteLine("input in valid");
                DateTime dtNow = DateTime.Now;

                if (dtInput < dtNow)
                {
                    var timeDiff = dtNow.Subtract(dtInput);
                    Console.WriteLine(timeDiff);
                }
                else
                {
                    var timeDiff = dtInput.Subtract(dtNow);
                    Console.WriteLine(timeDiff);
                }
            }
            else
            {
                Console.WriteLine("input is invalid");
            }

        }
    }
}
