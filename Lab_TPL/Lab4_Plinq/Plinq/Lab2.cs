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
    public static class Lab2 
    {
        public static void Quest2() 
        {
            Console.WriteLine("Enter Words (and)");
            string text = "Hello wodld and other";
            string[] spl = text.Split(' ');
            var input = Convert.ToString(Console.ReadLine());
            var findText = spl.AsParallel().Where(x => x == input).ToList();
            Console.WriteLine((findText.Count > 0 && findText[0].ToString() == input) ? "text is find" : "Text is not fount!!!");
        }


    }


}