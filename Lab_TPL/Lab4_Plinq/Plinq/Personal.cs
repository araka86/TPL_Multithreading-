using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plinq
{
    public static class Personal
    {


        public static void personalMethod()
        {
            int[] data = new int[10000000];
            for (int i = 0; i < data.Length; i++) data[i] = i;
            data[1000] = -1;
            data[14000] = -2;
            data[15000] = -3;
            data[676000] = -4;
            data[8024540] = -5;
            data[9908000] = -6;
            //    var negativeNumb = data.AsParallel().AsOrdered().Where(x => x < 0).ToList();



            var negativeNumb = data
                .AsParallel()
                .AsOrdered()
                .Select((x, y) => new { Value = x, Index = y })
                .Where(x=>x.Value <0).ToList();




            foreach (var item in negativeNumb) 
                Console.WriteLine($"[{item.Index}] = {item.Value}");
        }


    }
}
