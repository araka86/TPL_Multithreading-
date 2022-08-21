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
    public static class Lab3
    {
        public static void Quest3()
        {
            Random random = new Random();
            var models = new Auto[10];

            for (int i = 2; i < models.Length; i++)
            {
                models[0] = new Auto("Audi", 20000, 2000, "Корея");
                models[1] = new Auto("Bmw", 20000, 2000, "Корея");
                models[i] = new Auto(
                                    $"Model{i}",
                                    random.Next(1000, 10000),
                                    random.Next(1990, 2020),
                                    $"Made{i}");
            }


            var findParam = models.AsParallel().
                WithDegreeOfParallelism(4).
                Where(x => x.Price <= 20000 && x.Year <= 2000 && x.Made == "Корея").
                OrderBy(x => x.Model).
                ToArray();
            Console.WriteLine((findParam.Length > 0) ? "Found:" : "Not Fount!!");
            foreach (var model in findParam)
                Console.WriteLine(model.Model + " " + model.Made + " " + model.Year + " " + model.Price);
        }


    }


}