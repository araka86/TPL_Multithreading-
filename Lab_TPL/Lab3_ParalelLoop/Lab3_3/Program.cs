using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab3_3
{


    //3.  Parallel.For(), Parralel.Invoke
    //    Написати програму обчислення середньої температури за кожний місяць року. 
    //    Дані про температуру зберігаються в двовимірному масиві і заповнюються випадковими числами.
    //    Для заповнення масиву використати Parralel.Invoke.
    //    Для обчислення температури використати послідовний і паралельний цикли.
    //    Обчислити час роботи послідовної і паралельної версій за допомогою  класуStopwatch.



    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int cnt = 0;
            AllMonth[] allMonthArray;
            allMonthArray = new AllMonth[Enum.GetValues(typeof(Mounth)).Length];
            foreach (var current in Enum.GetValues(typeof(Mounth)))
            {
                var typeMount = (Mounth)current;
                allMonthArray[cnt++] = new AllMonth(typeMount);
            }
            var Weather = new Weather(allMonthArray);
            AllMonth all = new AllMonth();
            all.CountTemperature(Weather);

            sw.Stop();
            Console.WriteLine($"Time For Linear operation is: {sw.ElapsedTicks}");
            Console.WriteLine("_____________________________________________________");
            Thread.Sleep(1000);
            sw.Reset();
            sw.Start();

            Parallel.Invoke(new Action(() =>
            {
                int cnt2 = 0;
                AllMonth[] allMonthArray2;
                allMonthArray2 = new AllMonth[Enum.GetValues(typeof(Mounth)).Length];
                foreach (var current2 in Enum.GetValues(typeof(Mounth)))
                {
                    var typeMount2 = (Mounth)current2;
                    allMonthArray2[cnt2++] = new AllMonth(typeMount2);
                }
                var Weather2 = new Weather(allMonthArray2);
                AllMonth all2 = new AllMonth();
                all.CountTemperature(Weather2);
            }));
            sw.Stop();
            Console.WriteLine($"Time For Paralel operation is: {sw.ElapsedTicks}");
            Console.WriteLine("_____________________________________________________");

            Console.ReadKey();
        }
    }
}
