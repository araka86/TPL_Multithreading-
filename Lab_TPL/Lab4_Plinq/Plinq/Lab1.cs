using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Linq;



namespace Lab4_PLINQ
{
    static class Lab1 
    {
      public  static void Qest1()
        {

            Console.WriteLine("______________Liear version_____________");
            var mounth = new double[30];
            Random random = new Random();
            for (int i = 0; i < mounth.Length; i++)
                mounth[i] = random.Next(0, 30);
            var dayTemperature = mounth.AsParallel().Where(x => x > 20).ToList();
            for (int i = 0; i < mounth.Length; i++)
            {
                foreach (var day in dayTemperature)
                {
                    if (mounth[i] == day)
                    {
                        Console.WriteLine($"day{i} - {mounth[i]}");
                        break;
                    }

                }
            }

            Console.WriteLine("__________Paralel version_____________");
            Parallel.For(0, mounth.Length, (x) =>
            Parallel.ForEach(dayTemperature, (double day, ParallelLoopState state) =>
            {
                if (mounth[x] == day)
                {
                    Console.WriteLine($"day{x} - {mounth[x]}");
                    state.Break();
                }
            }
            ));
        }
    }


}