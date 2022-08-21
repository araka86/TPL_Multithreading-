using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Collections.Concurrent;

//    2.ConcurrentBag < T >
//    Створити колекцію ConcurrentBag<string>, яка містить список адрес сайтів.
//    Реалізувати методи додавання, видалення.
//    Сортування і пошук реалізувати за допомогою PLINQ.




namespace Lab5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {



            ConcurrentBag<string> listSite = new ConcurrentBag<string>();

            listSite.Add("www.ukr.net");
            listSite.Add("www.gmail.com");
            listSite.Add("www.mntu.edu");
            listSite.Add("www.yendex.ru");

            foreach (var item in listSite)
                Console.WriteLine(item);

            Console.WriteLine("_______________________");




            AddSite();  //добавления
            DellSite(); //удаления www.ukr.net из коллекции

            void AddSite()
            {
                bool condition = true;
                while (condition)
                {
                    try
                    {
                        Console.WriteLine("Enter Add WebSite Ex. (www.site.com.ua)");
                        string? input = Convert.ToString(Console.ReadLine());

                        if (input != null && input != string.Empty)
                        {
                            listSite.Add(input);
                            listSite.TryPeek(out string? input2);
                            Console.WriteLine($"Site {input2} is added\n");
                            condition = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }


            void DellSite()
            {
                var list = new List<string>();
                Task.Run(() =>
                {
                    int i = 0;
                    Parallel.ForEach(listSite, newList =>
                    {
                        list.Add(newList);

                        //  Console.WriteLine(list[i].ToString());
                        i++;
                    });
                }).Wait();
                string site = "www.ukr.net";
                if (list.Contains(site))
                {
                    var find = from t in list
                               where (t != site)
                               select t;
                    listSite = new ConcurrentBag<string>();


                    Parallel.ForEach(find, t =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine(t);
                    listSite.Add(t);

                });

                }
            }



            Console.ReadKey();

        }
    }



}