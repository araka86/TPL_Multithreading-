using System.Collections.Concurrent;

//3.ConcurrentDictionary < TKey, TValue >
//Створити словник для зберігання комплектуючих та ПК з ключем +
//3 Код_ID: +
//Код_ID Категорія Назва Постачальник +
//Заповнити її в коді. +
//Знайти вказаний товар за ключем. +
//Відібрати товари за значенням, наприклад, Принтер.


namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int Id = 0;
            var listNmtPc = new ConcurrentDictionary<int, NomenclaturePc>();


            Task.Run(() =>
            {
                listNmtPc.TryAdd(Id++, new NomenclaturePc("2030w", "Canon", "Printer"));
                listNmtPc.TryAdd(Id++, new NomenclaturePc("Hp-st8", "Hp", "Pc"));
                listNmtPc.TryAdd(Id++, new NomenclaturePc("Redmi9", "Redmi", "Mobile"));

                var list = listNmtPc.TryGetValue(2, out var list2);
                var select = from t in listNmtPc.AsParallel().ToList()
                             where t.Value.category == "Printer"
                             select t;


                select.AsParallel().Select(t => t.Value).ForAll(t => Console.WriteLine($"{t.category} - {t.Name} - {t.brand}"));


                var NewlistNmtPc = select as ConcurrentDictionary<int, NomenclaturePc>;

            }).Wait();

            Console.ReadKey();

        }
    }
    record class NomenclaturePc(string Name, string brand, string category);


}