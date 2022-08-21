using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Plinq;


//1.Згенерувати масив даних про температуру за місяць. 
//Сформувати і виконати запит PLINQ для вибору днів місяця, в яких температура була більше 20С.

// .NET 6.0

namespace Lab4_PLINQ
{


    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition = true;
            do
            {
                try
                {
                    Console.WriteLine(@"   
                                   1.Згенерувати масив даних про температуру за місяць. 
                                      Сформувати i виконати запит PLINQ для вибору днiв місяця, 
                                      в яких температура була бiльше 20С.
                                   2. Реалізувати функцію пошуку слова у тексті.
                                      Слово вводиться з консолі або з текстового поля форми. 
                                      Текст знаходиться в масивi.
                                  3. Створити клас Auto з полями: Model, Price, Year, Made. 
                                      Створити колекцію з 10 об’єктів цього класу. 
                                      Запитом PLINQ відібрати екземпляри за таким критерієм ціна-якість: 
                                      Price<=20 000, Year<2000, Made=”Корея”
                                   4.Створити у коді масив з 12 різних доменних імен сайтів. 
                                      Відібрати сайти “.com” та “.ua”.

                                   5 Знайти всі від’ємні числа в масиві. Постановка задачі. 
                                     Створити масив чисел великого розміру. int[] data = new int[10000000];
                                     Ініціалізувати масив даних позитивними значеннями
                                   6 EXIT

                            ");

                    var choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Lab1.Qest1();
                            break;
                        case 2:
                            Lab2.Quest2();
                            break;
                        case 3:
                            Lab3.Quest3();
                            break;
                        case 4:
                            Lab4.Quest4();
                            break;
                        case 5:
                            Personal.personalMethod();
                            break;
                        case 6:
                            condition = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (condition);



        }
    }

    record class Auto(string Model, double Price, int Year, string Made);


}