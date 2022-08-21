using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lab3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //2.Parallel.For().Написати програму генерації 5 пар відкритих ключів. 
            //  икористати метод Parallel.For ()

            var keyPairs = new string[5];
            var keyPairs2 = new string[5];

            for (int j = 0; j < keyPairs.Length; j++)
            {
                keyPairs2[j] = RSA.Create().ToXmlString(true);
            }

            Parallel.For(0, keyPairs.Length, i => keyPairs[i] = RSA.Create().ToXmlString(true));
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + " ) " + keyPairs[i]);
            }


            Console.ReadKey();

        }
    }
}
