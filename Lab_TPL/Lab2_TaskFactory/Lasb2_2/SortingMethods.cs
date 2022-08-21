
//2.Створення продовження задачі
//Створення масивів та їх сортування.
//Написати 3 методи генерації масивів з 100 елементів. 
//Створити три задачі для виклику цих методів. 
//Створити продовження задачі для сортування цих масивів

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public partial class SortingMethods
{

    public double[] massDouble { get;  set; }




    public SortingMethods()
    {
            
    }

    public SortingMethods(object iniMas)
    {

        
        var rnd = new Random();
        var originalArray = new double[(int)ConvertInt(iniMas)];
        Console.Write("Start Array\n");
        for (int i = 0; i < originalArray.Length; i++)
        {
            originalArray[i] = rnd.Next(0, originalArray.Length);
            Console.Write(originalArray[i] + " ");
        }
        massDouble = originalArray;

    }


    public double ConvertInt(object a)
    {
        double b;
        bool c = double.TryParse(a.ToString(), out b);
        return b;
    }

   

  


    public void sortDecending(double[] convertA)
    {
      //  var convertA = (double[])a;
        ////sort buble 
        double temp;
        for (int i = 1; i < convertA.Length; i++)
            for (int j = 0; j < convertA.Length - i; j++)

                if (convertA[j] > convertA[j + 1])
                {
                    temp = convertA[j];
                    convertA[j] = convertA[j + 1];
                    convertA[j + 1] = temp;
                }
        Thread.Sleep(1000);
        Console.WriteLine("\n Sort Array");
        for (int i = 0; i < convertA.Length; i++)
            Console.Write(convertA[i] + " ");
        Thread.Sleep(1000);
      
    }
    public void SortHora(double[]arr, long last, long first ) 
    { 
            double p = arr[(last - first) / 2 + first];
            double temp;
            long i = last, j = first;
            while (i <= j)
            {
                while (arr[i] > p && i >= last) ++i;
                while (arr[j] < p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j < first) SortHora(arr, first, j);
            if (i > last) SortHora(arr, i, last);

        if (last > 80) 
        {
            Console.WriteLine("\n Sort Array Hora Decending");
            foreach (double x in arr)
            {
                Console.Write(x + " ");
            }

        }
      
    }





}

