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
    public static class Lab4
    {
        public static void Quest4()
        {
            Random random = new Random();
            string[] domain = new string[7] { "sit1.com", "sit2.ua", "sit3.ru", "sit4.pl", "site5.org", "site6.edu", "ukraine.kiev" };
            string ttttt = domain[0].ToString();
            string[] sites = new string[12];
            for (int i = 0; i < sites.Length; i++)
                sites[i] = $"{domain[random.Next(0, domain.Length)]}";

            var findSites = from site in sites.AsParallel()
                            where (site.Contains(".ru") || site.Contains(".ua"))
                            select site.ToArray();



            foreach (var item in findSites)
                Console.WriteLine(item);

        }


    }


}