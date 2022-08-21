using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;





namespace Lab3_4_Parallel_ForEach
{
    //4. Parallel.ForEach()
    //Створити масив випадкових чисел в діапазоні(-100, 100).
    //Потім вибрати тільки від’ємні числа і знайти їх кількість.
    //Використати метод Parallel.ForEach(). 

   // .NET 6.0 (добавленный метод  NextInt64 в Rand)



    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            long[] mas = new long[50];
            long sum = 0; // сума від'ємних елементів
            int num = 0; // кількість від'ємних елементів

            Parallel.For(0, mas.Length, i =>
            {

                mas[i] = random.NextInt64(-100, 100);
            });

            Parallel.ForEach(mas, elem =>
            {
                if (elem < 0)
                {
                    sum += elem;
                    ++num;
                }
               
            });

            Console.WriteLine("sum = " + sum);
            Console.WriteLine("Count  = " + num);

            Console.ReadKey();
        }
    }
}
