

using System.Diagnostics;

namespace LessonSyncronization
{
    internal class Program
    {
        private static Random rnd = new Random();
        static async Task Main(string[] args)
        {

            //First example + Second:
            /*
            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            ThreadPool.QueueUserWorkItem((state) =>
            {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"Thread in thread pool Id: {Thread.CurrentThread.ManagedThreadId}");
                }
                
                Thread.Sleep(5000);

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Work finished on thread with ID: {Thread.CurrentThread.ManagedThreadId}");
                }
            });

            
            Thread.Sleep(6000);

            Console.ReadLine();
            */



            //Third Example
            /*
            int workerThreads;
            int portThreads;

            ThreadPool.GetMinThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMinimum worker threads: \t{workerThreads} "
                + $"\nMinimum complection port threads: {portThreads}");

            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);

            ThreadPool.GetMinThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMaximum worker threads: \t{workerThreads} "
                + $"\nMaximum complection port threads: {portThreads}");

            ThreadPool.SetMaxThreads(12, 1000);

            ThreadPool.GetMinThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMinimum worker threads: \t{workerThreads} "
                + $"\nMinimum complection port threads: {portThreads}");

            Console.WriteLine($"Number of work items that currently queued to be processed: {ThreadPool.PendingWorkItemCount}");

            ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMinimum worker threads: \t{workerThreads} "
                + $"\nMinimum complection port threads: {portThreads}");

            */

            //Fourth Example

            /*
            Random random = new Random();
            Task task = new Task(SomeWork); // What is SomeWork?
            task.Start();

            Console.WriteLine("Hello from Main!");

            task.Wait();

            Console.WriteLine("Finist");

            Task taskA = Task.Run(SomeWork);

            taskA.Wait();

            Task task1 = Task.Run(SomeWork);
            Task task2 = Task.Run(SomeWork);
            Task task3 = Task.Run(SomeWork);

            Task WhenAll = Task.WhenAll(taskA, task1, task2, task3);
            Task WhenAny = Task.WhenAny(taskA, task1, task2, task3);
            WhenAll.Wait();
            WhenAny.Wait();
            Console.WriteLine("All Tasks have been completed.");
            */

            //Fifth Example

            /*
            Task<int> taskI1 = new Task<int>(RandomNumber);
            Task<int> taskI2 = new Task<int>(RandomNumber);
            Task<int> taskI3 = new Task<int>(RandomNumber);

            taskI1.Start();
            taskI2.Start();
            taskI3.Start();

            int[] results = Task.WhenAll(taskI1, taskI2, taskI3).Result;

            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
            */

            //Sixth Example - Could work if "MAIN" was async, but i can't do that, need to ask teacher how did he did.

            /*
            var task = SayHelloAsync();

            await task;

            Console.WriteLine("Finish");
            */

            //Seven Example 

            /*
            Task task4 = Task.Run(async () =>
            {
                await Task.Delay(1000);

            });

            while (!task4.IsCompleted)
            {
                Console.WriteLine(".");
                await Task.Delay(1000); //IDK why here await don't work
            }

            Console.WriteLine("\nDone");
            */

            //Eigth Example
            /*
            var sw = Stopwatch.StartNew();

            Console.WriteLine($"Threads started in Main: {Thread.CurrentThread.ManagedThreadId}");

            Task t1 = SimulateWorkAsync("Task 1", 2000);
            Task t2 = SimulateWorkAsync("Task 2", 3000);
            Task t3 = SimulateWorkAsync("Task 3", 4000);

            Console.WriteLine("All Tasks started syncronazed");

            Console.WriteLine($"Time (async): {sw.Elapsed.TotalSeconds} sec");

            Console.WriteLine("All Tasks complete");

            sw = Stopwatch.StartNew();

            await SimulateWorkAsync("Task 1 ", 2000);
            await SimulateWorkAsync("Task 2 ", 2000);
            await SimulateWorkAsync("Task 3 ", 2000);

            Console.WriteLine($"Time (FIFO): {sw.Elapsed.TotalSeconds} sec");
            */

            //Practical Task
            Task < CoffeeCup > coffee = Task.Run(PouringCoffee);
            Task eggsTask = Task.Run(() => FryEggsOrBecon(0));
            Task beconTask = Task.Run(() => FryEggsOrBecon(1));
            Task jamSandvichesTask = Task.Run(CookingJamSandviches);
            Task JuiceTask = Task.Run(PouringJuice);

            
            Console.Read();

        }

        private static void PrintThreadIdAndWait(object? state) {
            Console.WriteLine($"Thread in thread pool Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"Work finished on thread with ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void SomeWork()
        {
            Console.WriteLine("Did Some Work");
            Thread.Sleep(1000);
            Console.WriteLine("Task Completed");
        }

        public static int RandomNumber()
        {
            Random random = new Random();
            int result = random.Next(1000, 5000);
            Task.Delay(result).Wait();
            return result;
        }

        private static async Task SayHelloAsync()
        {
            Console.WriteLine("Working...");
            await Task.Delay(1000);
            Console.WriteLine("Hello World!");
        }

        public static async Task SimulateWorkAsync(string str, int integer)
        {
            Console.WriteLine($"Starting do: {str}");
            await Task.Delay(integer);
            Console.WriteLine($"Task {str} completed ");
        }

        public static CoffeeCup PouringCoffee() { // Pour Coffee
            Console.WriteLine("Pouring Task");
            CoffeeCup coffeeCup = new CoffeeCup( "Black Coffee", 60);
            Task.Delay(10000);
            Console.WriteLine("Complete of Pouring Task");
            return coffeeCup;
        }

        public static async Task<Food> FryEggsOrBecon(int Choose)
        {
            if (Choose == 0)
            {
                Console.WriteLine("Frying three eggs");
                await Task.Delay(3000);
                Console.WriteLine("Eggs Cooked");
                EGGS eGGS = new EGGS();
                return eGGS;
            }
            else if (Choose == 1)
            {
                Console.WriteLine("Frying two Becon");
                await Task.Delay(4000);
                Console.WriteLine("Becon cooked");
                Becon becon = new Becon();
                return becon;
            }
            else { Console.WriteLine("Error try again"); return null; }
        }

        public static async Task CookingJamSandviches()
        {
            Console.WriteLine("Toasting Bread Slices");
            await Task.Delay(3000);
            Console.WriteLine("First two done");
            await Task.Delay(3000);
            Console.WriteLine("Jamming Bread Slices");
            await Task.Delay(3000);
            Console.WriteLine("Jam Sandviches Done!");
        }

        public static async Task PouringJuice()
        {
            Console.WriteLine("Pouring Juice");
            await Task.Delay(500);
            Console.WriteLine("Pouring Juice in cup Done");
        }


    }
}
