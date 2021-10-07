using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDays
{
    /// <summary>
    /// find out the total number of days and sessions you have joined till now 
    /// then convert the total time into seconds.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input start date:");
            string dtInput = Console.ReadLine();

            bool validInput = DateTime.TryParse(dtInput, out DateTime dT);
            if (validInput)
            {
                DateTime dtNow = DateTime.Now;
                var dateDiff = dtNow.Subtract(dT).TotalSeconds;

                Console.WriteLine("Total time in seconds: " + dateDiff);

            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
}
