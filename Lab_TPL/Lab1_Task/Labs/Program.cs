using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    public class Summer
    {
        private double[] june = new double[30];
        private double[] jul = new double[30];
        private readonly double[] august = new double[30];
        private double sum = 0;
        private double temp1 = 0;
        private double temp2 = 0;
        private double temp3 = 0;
        Random random = new Random();

        public Summer()
        {
            for (int i = 0; i < 30; i++)
            {
                june[i] = random.Next(20, 30);
                jul[i] = random.Next(24, 36);
                august[i] = random.Next(21, 30);
            }
        }

        public void AvergeTemperature()
        {

            for (int i = 0; i < june.Length; i++)
            {
                temp1 += june[i];
                temp2 += jul[i];
                temp3 += august[i];
            }

            temp1 /= june.Length;
            Thread.Sleep(50);
            temp2 /= jul.Length;
            Thread.Sleep(50);
            temp3 /= august.Length;
            Thread.Sleep(50);
            sum = (temp1 + temp2 + temp3) / 3;


            Console.WriteLine($"Averge temperature june: {temp1:N2}");
            Console.WriteLine($"Averge temperature jul: {temp2:N2}");
            Console.WriteLine($"Averge temperature august: {temp3:N2}");
            Console.WriteLine($"Averge temperature Summer: {sum:N2}");

        }

    }

    internal class Program
    {


        static void Main(string[] args)
        {
            Summer summer = new Summer();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task = new Task(summer.AvergeTemperature);
            task.Start();
            task.Wait();

            stopwatch.Stop();

            Console.WriteLine($"Time work:{stopwatch.ElapsedMilliseconds} # Task");
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("_____________________________________________");

            summer.AvergeTemperature();
            stopwatch.Stop();
            Console.WriteLine($"Time work:{stopwatch.ElapsedMilliseconds} # Wihout Task");
            Console.WriteLine("_____________________________________________");
            stopwatch.Reset();

            stopwatch.Start();
            Thread thread = new Thread(summer.AvergeTemperature);
            thread.Start();
            thread.Join();


            stopwatch.Stop();
            Console.WriteLine($"Time work:{stopwatch.ElapsedMilliseconds} # Wiht Threat");

            Console.ReadKey();
        }
    }
}
