using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LabV2
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var sortingMethods = new SortingMethods();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var taskIni = Task<SortingMethods>.Factory.StartNew(() => sortingMethods = new SortingMethods(100));
            taskIni.Wait();


            var filaltask = Task.Factory.StartNew(() => sortingMethods.sortDecending(sortingMethods.massDouble));
            filaltask.Wait();

            Task taskContinue = taskIni.ContinueWith(t => sortingMethods.SortHora(sortingMethods.massDouble, 0, sortingMethods.massDouble.Length - 1));



            Thread.Sleep(900);
            Console.WriteLine();

            stopwatch.Stop();
            Console.WriteLine($"\nTime for task {stopwatch.ElapsedTicks}");
            Console.WriteLine("______________________________________");

            stopwatch.Reset();
            stopwatch.Start();

            new SortingMethods(100);

            sortingMethods.sortDecending(sortingMethods.massDouble);

            sortingMethods.SortHora(sortingMethods.massDouble, 0, sortingMethods.massDouble.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"\n\nTime witout task {stopwatch.ElapsedTicks}");
            Console.WriteLine("______________________________________");

            Console.ReadKey();




        }

    }
}
