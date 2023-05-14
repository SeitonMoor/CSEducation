using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class ExpiredProducts
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();

            supermarket.FindExpiredProducts();
        }
    }

    enum CannedMeatName
    {
        Hormel,
        Grace,
        Argentina,
        Exeter,
        Brookdale,
        Hereford,
        LibbyS
    }

    class Supermarket
    {
        private List<CannedMeat> _cannedMeats = new List<CannedMeat>();
        private readonly int _cannedMeatCount = 25;

        public Supermarket()
        {
            FillWarehouse(_cannedMeatCount);
        }

        public void FindExpiredProducts()
        {
            Console.WriteLine("Поиск просрочки на складе.");

            List<CannedMeat> expiredProducts = GetExpiredProducts();

            Print(expiredProducts);
        }

        private List<CannedMeat> GetExpiredProducts() => _cannedMeats.Where(meat => meat.ProductionYear + meat.ShelfLife < DateTime.Now.Year).ToList();

        private void Print(List<CannedMeat> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("\nПросроченных продуктов нет.");
                return;
            }

            Console.WriteLine("\nПросроченные продукты:");

            foreach (CannedMeat product in products)
            {
                Console.WriteLine($"{product.Name} | Год производства: {product.ProductionYear} | Срок годности: {product.ShelfLife}");
            }
        }

        private void FillWarehouse(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _cannedMeats.Add(new CannedMeat());
                Thread.Sleep(25);
            }
        }
    }

    class CannedMeat
    {
        private readonly Random _random = new Random();

        public CannedMeat()
        {
            FillInformation();
        }

        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ShelfLife { get; private set; }

        private void FillInformation()
        {
            int minId = 1;

            int minYear = 2016;
            int maxYear = 2024;

            int minShelfLife = 1;
            int maxShelfLife = 8;

            Name = GetRandomName(minId);
            ProductionYear = _random.Next(minYear, maxYear);
            ShelfLife = _random.Next(minShelfLife, maxShelfLife);
        }

        private string GetRandomName(int minId)
        {
            Array names = Enum.GetValues(typeof(CannedMeatName));

            int nameId = GetRandomId(minId, names.Length);
            CannedMeatName name = (CannedMeatName)nameId;

            return name.ToString();
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
