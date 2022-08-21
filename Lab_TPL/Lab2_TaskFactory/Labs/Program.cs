using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//1.Клас Task.Factory.
//Метод StartNew()
//Написати програму обчислення середньої температури за літо (за 3 місяці).
//Дані про температури зберігаються у трьох одновимірних масивах. +
//Створити клас з одним методом обчислення середньої + температури за місяць та полями для масивів та середніх значенень. +
//Написати послідовну і паралельну версію програми (з використанням класу Task.Factory). +
//Визначити час виконання послідовної і паралельної версії програми.
//Звільнити ресурси після завершення.

namespace Lab2
{

    public class Summer
{

    private double[] june = new double[30];
    private double[] jul = new double[30];
    private readonly double[] august = new double[30];
    private double sum = 0;
    private double AvJune = 0;
    private double AvJul = 0;
    private double AvAugust = 0;
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
            AvJune += june[i];
            AvJul += jul[i];
            AvAugust += august[i];
        }


        AvJune /= june.Length;
        Thread.Sleep(50);
        AvJul /= jul.Length;
        Thread.Sleep(50);
        AvAugust /= august.Length;
        Thread.Sleep(50);
        sum = (AvJune + AvJul + AvAugust) / 3;


        Console.WriteLine($"Averge temperature june: {AvJune:N2}");
        Console.WriteLine($"Averge temperature jul: {AvJul:N2}");
        Console.WriteLine($"Averge temperature august: {AvAugust:N2}");

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
            var task = Task.Factory.StartNew(summer.AvergeTemperature);

            task.Wait();
            task.Dispose();
            stopwatch.Stop();

            Console.WriteLine($"Time work:{stopwatch.ElapsedMilliseconds} # Task");
            stopwatch.Reset();
            stopwatch.Start();

            Console.WriteLine("_____________________________________________");
            summer.AvergeTemperature();
            stopwatch.Stop();
            Console.WriteLine($"Time work:{stopwatch.ElapsedMilliseconds} # Wihout Task");


            Console.ReadKey();


        }
    }
}
