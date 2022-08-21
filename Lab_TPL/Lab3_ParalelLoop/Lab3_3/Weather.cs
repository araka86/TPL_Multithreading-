using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Lab3_3
{
    public class Weather : IEnumerable
    {

        public int Year { get; set; }
        public int countDay { get; set; }


        public AllMonth[] weatherps;

        public Weather(AllMonth[] _weathers, int year = 2021)
        {
            weatherps = _weathers;
            this.Year = year;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var weather in weatherps) 
            {               
                countDay = weather.TemperatureDay.Length;
                yield return weather.Gettamperature();

            }
        }
    }


}
