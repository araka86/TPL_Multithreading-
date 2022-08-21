using System.Collections.Concurrent;

//1.ConcurrentBag < T >
//Реалізувати колекцію ConcurrentBag<T> для зберігання об'єктів класу Співробітник.
//Реалізувати заповнення колекції об'єктами. 
//Відсортувати елементи колекції за зарплатою за допомогою PLINQ. 


record class Employe(int Id, string Name, int Age, double Salary);


namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<Employe> employesBag = new ConcurrentBag<Employe>();
            employesBag.Add(new Employe(11, "Ben", 44, 20000));
            employesBag.Add(new Employe(1, "Ben", 44, 20000));
            employesBag.Add(new Employe(4, "Ben", 44, 20000));
            employesBag.Add(new Employe(8, "Ben", 44, 20000));
            var sort = from e in employesBag.AsParallel().ToList()
                       orderby (e.Id)
                       select e;


            foreach (var item in sort)
                Console.WriteLine(item);

            Console.WriteLine("_____________________________________________________");
            ConcurrentBag<Employe[]> employesBag2 = new ConcurrentBag<Employe[]>();
            Employe[] employeps ={
                new Employe(7,"Ben",44,20000),
                new Employe(3,"Tery",42,30000),
                new Employe(1,"Angelica",40,42000),
                new Employe(2,"Mary",41,22000)
            };
            employesBag2.Add(employeps);
            var sort2 = from t in employesBag2.AsParallel().ToList()
                        from tt in t.ToList()
                        orderby tt.Salary
                        select tt;
            foreach (var item in sort2)
                Console.WriteLine(item);


            Console.ReadKey();

        }
    }



}