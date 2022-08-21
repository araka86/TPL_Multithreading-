using System.Collections.Concurrent;

//Створити словник для зберігання комплектуючих та ПК з ключем 
//Код_ID:
//Код_ID Категорія Назва Постачальник
//Заповнити її в коді. Знайти вказаний товар за ключем.
//Відібрати товари за значенням, наприклад, Принтер.

namespace Lab5_3IEqualityComparer_ConcurrentDictionary
{
    public record Nomenclatura
    {

        public DateTime lastQueryDate { get; set; } //остання дата запиту
        private string? name { get; set; }
        public string? Name { get => name; set => name = value; }

        private string? category { get; set; }
        public string? Category { get => category; set => category = value; }

        private string? brand { get; set; }
        public string? Barnd { get => brand; set => brand = value; }

        private decimal latitude { get; set; }
        public decimal Latitude { get => latitude; set => latitude = value; }
        private decimal longitude { get; set; }
        public decimal Longitude { get => longitude; set => longitude = value; }
        private int[]? RecentHighTemperatures { get; set; }
        public int[]? RecentHighTemperatures2 { get => RecentHighTemperatures; set => RecentHighTemperatures = value; }

        public Nomenclatura(string? _name, string? _category, string? _brand)
        {
            Category = _category;
            Barnd = _brand;
            Name = _name;
            lastQueryDate = DateTime.Now;

        }

    }


    class Program
    {




        // Create a new concurrent dictionary.
        static ConcurrentDictionary<string, Nomenclatura> numclatures = new ConcurrentDictionary<string, Nomenclatura>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Nomenclatura[] data = {
            new Nomenclatura("Mi43UA","Tv","Xiaomi"),
            new Nomenclatura("APPLE IPHONE 13 MINI 128GB MIDNIGHT (MLK03)","Phone","Apple"),
            new Nomenclatura("VINGA WOLVERINE A5187","Pc","VINGA"),
            new Nomenclatura("MICROSOFT WINDOWS 10 PROFESSIONAL X64 RUSSIAN OEM","Soft","MICROSOFT"),
            new Nomenclatura("X-PRINTER XP-420B","Printer","X-PRINTER")};
            // Add some key/value pairs from multiple threads.

            Task.WhenAll(
            Task.Run(() => TryAddNMC(data)),
            Task.Run(() => TryAddNMC(data))).Wait();


            static void TryAddNMC(Nomenclatura[] data) //заповнення словника 
            {
                int cnt = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (numclatures.TryAdd(data[i].Name, data[i])) //key, value
                    {
                        Console.WriteLine("Added {0} on thread {1}", data[i].Name, Thread.CurrentThread.ManagedThreadId);
                        cnt++;
                    }
                    else
                        Console.WriteLine("Could not add {0} on thread {1}", data[i].Name, Thread.CurrentThread.ManagedThreadId);
                }
                Console.WriteLine($"Count Add: {cnt} , on thread {Thread.CurrentThread.ManagedThreadId}");

            }

            Console.WriteLine("______________________________________");

            Parallel.ForEach(numclatures, nmn =>
            {
                Console.WriteLine($"KEY: {nmn.Key},  Brand: { nmn.Value.Barnd} has been added");
            });
            Console.WriteLine("______________________________________");


            AddOrUpdateWithoutRetrieving(); //обновляем значение когда ключ существует
            RetrieveValueOrAdd(); // добавляем в словарь новую запись когда ключ не существует
            RetrieveAndUpdateOrAdd(); // добавляем ключ-значение когда ключ НЕ существует
            TryRemovenomenclatura(); // удалить
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
        //пробуємо додати об'єкт. Якщо такого об'єкту немає, додаємо його в словник. якощo він вже є, оновлюємо його значення
        private static void AddOrUpdateWithoutRetrieving() //AddOrUpdate (UpdateData)
        {
            // Sometime later. We receive new data from some source.
            //створення об'єкту 
            Nomenclatura ci = new Nomenclatura(
                "X-PRINTER XP-420B",
                "Printer",
                "X-PRINTER2");


            var rez = numclatures.AddOrUpdate(ci.Name, ci, (key, existingVal) =>
            {

                try
                {
                    if (ci != existingVal) //проверка на дубли
                        throw new ArgumentException("Duplicate city names are not allowed: {0}.", ci.Name);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                existingVal.lastQueryDate = DateTime.Now;     //обновить время (текущее дада) для дубля
                existingVal.Barnd = ci.Barnd;
                existingVal.Category = ci.Category;
                return existingVal;
            });
            // Verify that the dictionary contains the new or updated data.

            Console.WriteLine($"Model is{ci.Name} - exist, Update value:  categoty {ci.Category} Brand {ci.Barnd}");
            Console.WriteLine("______________________________________");
            Console.WriteLine();
        }



        // This method shows how to use data and ensure that it has been
        // added to the dictionary.
        private static void RetrieveValueOrAdd()
        {
            string searchKey = "CANON LBP-6030B";
            Nomenclatura? retrievedValue = null;
            try
            {
                retrievedValue = numclatures.GetOrAdd(searchKey, GetDataForNmcl(searchKey));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            // Use the data.
            if (retrievedValue != null)
            {
                Console.Write($"New Key {retrievedValue.Name} and new value is added (GetOrAdd)");
            }
            Console.WriteLine();
        }



        private static void RetrieveAndUpdateOrAdd()
        {
            Nomenclatura? retrievedValue;
            string searchKey = "HP LASERJET PRO M102W";
            if (numclatures.TryGetValue(searchKey, out retrievedValue)) //попытка найти значение по этому ключу
            {
                // use the data
                Console.Write($"Key  is find {retrievedValue.Name}");

                // Make a copy of the data. Our object will update its lastQueryDate automatically.
                var newValue = new Nomenclatura(
                retrievedValue.Name,
                retrievedValue.Category,
                retrievedValue.Barnd);
                // Заменить старые знвачения на новые
                if (!numclatures.TryUpdate(searchKey, retrievedValue, newValue))
                {
                    //The data was not updated. Log error, throw exception, etc.
                    Console.WriteLine("Could not update {0}", retrievedValue.Name);
                }
            }
            else
            {
                // Add the new key and value. Here we call a method to retrieve
                // the data. Another option is to add a default value here and 
                // update with real data later on some other thread.
                Nomenclatura newValue = GetDataForNmcl(searchKey);
                if (numclatures.TryAdd(searchKey, newValue))
                {
                    // use the data
                    Console.WriteLine($"New Key-value is add: {newValue.Name} - {newValue.Category} -{newValue.Barnd}");

                }
                else
                    Console.WriteLine("Unable to add data for {0}", searchKey);
            }

        }

        static void TryRemovenomenclatura()
        {
            Console.WriteLine("______________________________________");
            Console.WriteLine($"Total cities = {numclatures.Count}");

            var searchKey = "APPLE IPHONE 13 MINI 128GB MIDNIGHT (MLK03)";
            if (numclatures.TryRemove(searchKey, out Nomenclatura? retrievedValue))
            {
                Console.WriteLine($"Remove Object is {retrievedValue.Name}");
            }
            else
            {
                Console.WriteLine($"Unable to remove {searchKey}");
            }

            Console.WriteLine($"Total cities = {numclatures.Count}");
        }




        //Assume this method knows how to find long/lat/temp info for any specified city.
        static Nomenclatura GetDataForNmcl(string name)
        {
            // Real implementation left as exercise for the reader.
            if (string.CompareOrdinal(name, "CANON LBP-6030B") == 0)

                return new Nomenclatura(
               "CANON LBP-6030B",
               "Printer",
               "CANON");

            else if (string.CompareOrdinal(name, "HP LASERJET PRO M102W") == 0)
                return new Nomenclatura(
               "HP LASERJET PRO M102W",
               "Printer",
               "НР");
            else
                throw new ArgumentException("Cannot find any data for {0}", name);
        }


    }



}



