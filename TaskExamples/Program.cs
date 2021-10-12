using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            ExceptionInTask();

            //refer to TPL 
            //Task Parallel Library
        }

        //task throwming an exception
        public static void ExceptionInTask()
        {
            var task1 = Task.Run(() => { throw new InvalidOperationException(); });
            try
            {
                task1.Wait();
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("exception!" + ex.InnerException);
            }
        }

        //multiple task with exceptions
        public static void ExceptionInTask2()
        {
            var tasks = new List<Task<int>>();
            Func<object, int> func = (obj) =>
            {
                int i = (int)obj;
                if (i >= 2 && i <= 5)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine($"Task id: {Task.CurrentId}");
                Console.WriteLine($"Thread id for this task: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Value: {i}");

                return 100 * i;

            };

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task<int>.Factory.StartNew(func, i));

            }
            try
            {
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("Try block");
            }
            catch (AggregateException ex)
            {
                //multiple task throwming exception
                Console.WriteLine("exception happened");

                for (int i = 0; i < ex.InnerExceptions.Count; i++)
                {
                    Console.WriteLine("Inner ex caught" + ex.InnerExceptions);
                }
            }
        }

        //'whenAny' keyword
        public static async void WhenAnyExample()
        {
            Random rand = new Random();

            //a list of task enumerable way
            var tasks = Enumerable.Range(1, 5).Select(n => Task.Run(() =>
              {
                  Console.WriteLine($"In task {n}");
                  Thread.Sleep(rand.Next(1000, 10000));
                  return n;
              }));

            var temp = Task.WhenAny(tasks.ToArray());  //will give taskstemp that has completed
            var completedTask = await temp;

            //status

            Console.WriteLine("The completed task id;" + await completedTask);


            //once any task has completed, 
            //it will enter the temp and print that task ID
            //then exit with out waiting fr any other tasks to complete

            //if u want it to wait: "WhenAll"
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("all task competed");
        }


    }
}
