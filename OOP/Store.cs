using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Store
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            Buyer buyer = new Buyer();
            Seller seller = new Seller();

            market.Work(seller, buyer);
        }
    }
     
    class Market
    {
        public void Work(Seller seller, Buyer buyer)
        {
            const string SeeCommand = "1";
            const string BuyCommand = "2";
            const string ViewCommand = "3";
            const string ExitCommand = "0";

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Магазин");
                Console.Write($"\nДенег в кармане: {buyer.Money} | Вы можете:" +
                    $"\n\n{SeeCommand} - посмотреть список товаров." +
                    $"\n{BuyCommand} - купить товар." +
                    $"\n{ViewCommand} - посмотреть купленные товары." +
                    $"\n{ExitCommand} - закончить покупку." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case SeeCommand:
                        seller.ViewInventory();
                        break;

                    case BuyCommand:
                        Trade(seller, buyer);
                        break;

                    case ViewCommand:
                        buyer.ViewInventory();
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Данная команда неизвестна");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void Trade(Seller seller, Buyer buyer)
        {
            Product product = seller.TryGetProduct();

            if (product == null)
            {
                return;
            }

            bool isSold = false;

            while (isSold == false)
            {
                Console.Write($"Напишите количество {product.Name} для покупки: ");

                if (Int32.TryParse(Console.ReadLine(), out int desiredCount) == false)
                {
                    Console.WriteLine("Количество указано не верно.\n");
                    continue;
                }
                
                if (seller.HaveAvailability(desiredCount) == false)
                {
                    continue;
                }

                int productCount = seller.GetProductCount(product.Name);

                if (productCount < desiredCount)
                {
                    Console.WriteLine($"Данного количества товара нет в наличии, максимально возможное - {productCount}.\n");
                    continue;
                }

                if (buyer.CheckSolvency(product.Price * desiredCount) == false)
                {
                    return;
                }

                MakeDeal(seller, buyer, product, productCount, desiredCount);
                isSold = true;
            }
        }

        private void MakeDeal(Seller seller, Buyer buyer, Product product, int productCount, int desiredCount)
        {
            seller.Sell(product, productCount, desiredCount);
            seller.TakeMoney(buyer.ToPay());

            buyer.TakeItem(product, desiredCount);

            Console.WriteLine($"\nВы совершили покупку {product.Name} в количестве {desiredCount}");
        }
    }

    class Person
    {
        protected Inventory Inventory = new Inventory();

        protected int MoneyToPay;

        public int Money { get; protected set; }

        public void ViewInventory()
        {
            if (Inventory.GetItemsCount() == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
            }
            else
            {
                Inventory.PrintItemsInfo();
            }
        }

        public bool CheckSolvency(int money)
        {
            MoneyToPay = money;

            if (Money >= MoneyToPay)
            {
                return true;
            }
            else
            {
                MoneyToPay = 0;
                Console.WriteLine("У вас недостаточно средств.");

                return false;
            }
        }

        public void TakeMoney(int money)
        {
            if (money >= 0)
            {
                Money += money;
            }
        }

        public int ToPay()
        {
            Money -= MoneyToPay;

            return MoneyToPay;
        }
    }

    class Buyer : Person
    {
        public Buyer()
        {
            Random random = new Random();

            int minMoneyValue = 150;
            int maxMoneyValue = 2500;

            Money = random.Next(minMoneyValue, maxMoneyValue);
        }

        public void TakeItem(Product product, int count)
        {
            bool isFound = false;

            if (Inventory.TryGetProduct(product.Name) != null)
            {
                Inventory.HaveAvailability(count);
                Inventory.AddCount(product.Name);

                isFound = true;
            }

            if (isFound == false)
            {
                Inventory.Add(product, count);
            }
        }
    }

    class Seller : Person
    {
        public Seller()
        {
            Money = 0;

            FillProducts();
        }

        public bool HaveAvailability(int count)
        {
            return Inventory.HaveAvailability(count);
        }

        public int GetProductCount(string name)
        {
            return Inventory.TryGetCount(name);
        }

        public void Sell(Product product, int productCount, int desiredCount)
        {
            if (productCount == desiredCount)
            {
                Inventory.Remove(product);
            }
            else
            {
                Inventory.ReduceCount(product.Name);
            }
        }

        public Product TryGetProduct()
        {
            const string EndFind = "0";

            Product foundProduct = null;

            if (Inventory.GetItemsCount() == 0)
            {
                Console.WriteLine("Инвентарь торговца пуст.");
                return foundProduct;
            }

            bool isFound = false;

            while (isFound == false)
            {
                Console.Write($"\nУкажите желаемы продукт для покупки или {EndFind} - для отмены выбора товара: ");
                string name = Console.ReadLine();

                if (name == EndFind)
                {
                    Console.WriteLine("Выбор товара отменен.");
                    return foundProduct;
                }
                else
                {
                    foundProduct = Inventory.TryGetProduct(name);
                    if (foundProduct != null)
                    {
                        isFound = true;
                    }

                    if (isFound == false)
                    {
                        Console.WriteLine("\nДанный товар отсутствует, посмотрите что имеется в наличии:");
                        ViewInventory();
                    }
                }
            }

            return foundProduct;
        }

        private void FillProducts()
        {
            Inventory.Add(new Product("Арбуз", 120), 11);
            Inventory.Add(new Product("Апельсин", 60), 99);
            Inventory.Add(new Product("Яблоко", 150), 210);
            Inventory.Add(new Product("Виноград", 50), 45);
            Inventory.Add(new Product("Кофе", 340), 6);
            Inventory.Add(new Product("Миндаль", 330), 12);
        }
    }

    class Inventory
    {
        private Dictionary<Product, int> _items = new Dictionary<Product, int>();
        private int _countToChange;

        public void Add(Product product, int count)
        {
            _items.Add(product, count);
        }

        public void Remove(Product product)
        {
            _items.Remove(product);
        }

        public bool HaveAvailability(int count)
        {
            _countToChange = 0;

            if (count <= 0)
            {
                Console.WriteLine("Отрицательное количество, минимально возможное - 1.\n");
                return false;
            }
            else
            {
                _countToChange = count;
                return true;
            }
        }

        public void AddCount(string name)
        {
            Product product = TryGetProduct(name);

            _items[product] += _countToChange;
        }

        public void ReduceCount(string name)
        {
            Product product = TryGetProduct(name);

            _items[product] -= _countToChange;
        }

        public Product TryGetProduct(string name)
        {
            Product foundProduct = null;

            foreach (KeyValuePair<Product, int> item in _items)
            {
                if (item.Key.Name == name)
                {
                    foundProduct = item.Key;
                }
            }

            return foundProduct;
        }

        public int TryGetCount(string name)
        {
            int foundCount = 0;

            foreach (KeyValuePair<Product, int> item in _items)
            {
                if (item.Key.Name == name)
                {
                    foundCount = item.Value;
                }
            }

            return foundCount;
        }

        public int GetItemsCount()
        {
            return _items.Count;
        }

        public void PrintItemsInfo()
        {
            foreach (KeyValuePair<Product, int> item in _items)
            {
                item.Key.PrintInfo(item.Value);
            }
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public void PrintInfo(int count)
        {
            Console.WriteLine($"{Name} по цене {Price} | в наличии: {count}");
        }
    }
}
