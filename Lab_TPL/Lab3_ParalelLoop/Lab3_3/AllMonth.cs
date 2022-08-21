using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Lab3_3
{
    public class AllMonth :IEnumerable
    {
        public AllMonth() {}
        private Mounth typeMount;
       
        public double[] TemperatureDay { get; set; }

        public double[] Gettamperature() => TemperatureDay;
        public AllMonth NameMounth { get; set; }

        public AllMonth(Mounth typeMount)
        {
            this.typeMount = typeMount;
            this.TemperatureDay = InitTemperature(typeMount);
        }


        public double[] InitTemperature(Mounth mounth)
        {
           
            switch (mounth)
            {
                case Mounth.January: return GenerateTemp(31,-10,-15);
                case Mounth.February: return GenerateTemp(28,-20,-25);
                case Mounth.March: return GenerateTemp(31,-25,-35);
                case Mounth.April: return GenerateTemp(30,5,9);
                case Mounth.May: return GenerateTemp(30,1,10);
                case Mounth.June: return GenerateTemp(30,10,15);
                case Mounth.July: return GenerateTemp(31,15,20);
                case Mounth.August: return GenerateTemp(29,20,26);
                case Mounth.September: return GenerateTemp(30,25,30);
                case Mounth.October: return GenerateTemp(31,15,20);
                case Mounth.November: return GenerateTemp(30,12,15);
                case Mounth.December: return GenerateTemp(31,1,12);
                default: return GenerateTemp(0,0,0);
            }

        }

        public double[] GenerateTemp(int day,double firstTemp,double lasttemp) 
        {
            Random rand = new Random();
            double[] temp = new double[day];         
            for (int i = 0; i < day; i++)
            {
                temp[i] = Convert.ToInt32(rand.NextDouble(firstTemp, lasttemp));
            }
            return temp;
        }
     
        public void CountTemperature(Weather weather) 
        {
            int cnt = 0;
            double allTemperatureFor12Mounth = 0;

            Stopwatch sw3 = Stopwatch.StartNew();          
            foreach (double[] wt in weather) 
            {
                int days = weather.countDay;
                int cntForDay = 0;
                int cntForDayParalel = 0;

                double cntForMonthTemp = 0;
                double cntForMonthTempParalel = 0;

                string currentMounth = weather.weatherps[cnt++].typeMount.ToString();
        //        Console.WriteLine("\n\n"+ currentMounth);
              

                for (int i = 0; i < days; i++)
                {
        //            Console.Write(wt[i] + " ");
                    cntForMonthTemp += wt[i];
                    cntForDay++;
                }
                 allTemperatureFor12Mounth += cntForMonthTemp / cntForDay;


                Parallel.For(0, days, i =>
                {
         //           Console.Write(wt[i] + " ");
                    cntForMonthTempParalel += wt[i];
                    cntForDayParalel++;
                });


         //       Console.WriteLine($"\nAverg temperature for {currentMounth}: {cntForMonthTemp/cntForDay:N2}");
          //      Console.WriteLine("\n_______________");

            }
        //    Console.WriteLine($"Averg temperature for 12 mount: {allTemperatureFor12Mounth/12}");


            sw3.Stop();
            Console.WriteLine($"Time for linear loop : {sw3.ElapsedTicks}");
            sw3.Reset();
            sw3.Start();






            int cnt2 = 0;
            foreach (double[] wt in weather)
            {
                int days = weather.countDay;            
                int cntForDayParalel = 0;              
                double cntForMonthTempParalel = 0;
                string currentMounth = weather.weatherps[cnt2++].typeMount.ToString();
         //       Console.WriteLine("\n\n" + currentMounth);
                Parallel.For(0, days, i =>
                {
            //        Console.Write(wt[i] + " ");
                    cntForMonthTempParalel += wt[i];
                    cntForDayParalel++;
                });
            }
            Console.WriteLine();
            Console.WriteLine($"time for paralel Loop {sw3.ElapsedTicks}");
















        }

        public IEnumerator GetEnumerator()
        {
            yield return TemperatureDay;
        }
    }


}
