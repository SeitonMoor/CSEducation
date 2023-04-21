using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    internal class Supermarket
    {
        static void Main(string[] args)
        {
            Superstore superstore = new Superstore();

            superstore.Work();
        }
    }

    class Superstore
    {
        private readonly Warehouse _warehouse = new Warehouse();
        private int _money = 0;

        public Superstore()
        {
            FillItems();
        }

        public void Work()
        {
            Console.WriteLine("Администрирование супермаркетом" +
                "\nОжидаем, когда клиенты наберут продуктов...\n");

            _warehouse.ShowItems();

            Queue<Client> clientsQueue = GetClients();

            int count = 1;
            while (clientsQueue.Count != 0)
            {
                Console.WriteLine($"\nДенег в кассе магазина: {_money}");
                
                Serve(clientsQueue.Dequeue(), count);

                count++;

                Console.WriteLine("\nНажмите любую клавишу, чтобы пригласить следующего клиента...");
                Console.ReadKey();
            }
        }

        private Queue<Client> GetClients()
        {
            Queue<Client> clientsQueue = new Queue<Client>();

            int clientNumbers = 5;

            for (int i = 0; i < clientNumbers; i++)
            {
                Client client = new Client();

                client.FillBasket(_warehouse);

                clientsQueue.Enqueue(client);
                Thread.Sleep(50);
            }

            return clientsQueue;
        }

        private void Serve(Client client, int count)
        {
            Console.WriteLine($"\nОбслуживание клиента №{count}:");

            bool isServed = false;

            while (isServed == false)
            {
                Basket clientBasket = client.GetBasket();

                if (clientBasket.GetItemsCount() == 0)
                {
                    Console.WriteLine($"Клиент выложил все имеющиеся в корзине продукты и решил вернуться к покупкам позже.");
                    isServed = true;

                    continue;
                }

                int bill = FormBill(clientBasket);

                if(client.CheckSolvency(bill) == false)
                {
                    client.RemoveItem();

                    continue;
                }

                TakeMoney(client.ToPay());
                Console.WriteLine($"Клиент совершил покупку {clientBasket.GetItemsCount()} продуктов на сумму {bill}.");

                isServed = true;
            }
        }

        private int FormBill(Basket basket)
        {
            return basket.GetPricesAmount();
        }

        private void TakeMoney(int money)
        {
            if (_money >= 0)
            {
                _money += money;
            }
        }

        private void FillItems()
        {
            List<Item> items = InitializeItems();

            foreach (Item item in items)
            {
                _warehouse.Add(item);
            }
        }

        private List<Item> InitializeItems()
        {
            List<Item> items = new List<Item>()
            {
                new Item("Кофе", 420),
                new Item("Яблоко", 140),
                new Item("Конфеты", 370),
                new Item("Мясо", 1700),
                new Item("Арбуз", 120),
                new Item("Апельсин", 60),
                new Item("Виноград", 50),
                new Item("Миндаль", 330),
                new Item("Пекан", 820)
            };

            return items;
        }
    }

    abstract class ItemStorage
    {
        protected List<Item> Items = new List<Item>();

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

        public int GetItemsCount()
        {
            return Items.Count;
        }

        public Item SelectRandomItem()
        {
            Random random = new Random();

            int id = random.Next(Items.Count);

            return Items[id];
        }
    }

    class Warehouse : ItemStorage
    {
        public void ShowItems()
        {
            foreach (Item item in Items)
            {
                Console.WriteLine($"{item.Name} - по цене: {item.Price}");
            }
        }
    }

    class Basket : ItemStorage
    {
        public int GetPricesAmount()
        {
            int amount = 0;
            foreach (Item item in Items)
            {
                amount += item.Price;
            }

            return amount;
        }
    }


    class Client
    {
        private readonly Basket _basket = new Basket();
        private int _money;
        private int _moneyToPay;

        public Client()
        {
            _money = FillMoney();
        }

        public void TakeItem(Item item)
        {
            _basket.Add(item);
        }

        public Basket GetBasket()
        {
            return _basket;
        }

        public bool CheckSolvency(int bill)
        {
            _moneyToPay = bill;

            if (_money >= _moneyToPay)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                Console.WriteLine("Недостаточно средств.");

                return false;
            }
        }

        public int ToPay()
        {
            _money -= _moneyToPay;

            return _moneyToPay;
        }

        public void RemoveItem()
        {
            Item randomItem = _basket.SelectRandomItem();

            _basket.Remove(randomItem);

            Console.WriteLine($"{randomItem.Name} - убран из корзины.");
        }

        public void FillBasket(Warehouse warehouse)
        {
            Random random = new Random();

            int minItems = 2;
            int maxItems = 20;

            int itemsCount = random.Next(minItems, maxItems);
            for (int i = 0; i < itemsCount; i++)
            {
                TakeItem(warehouse.SelectRandomItem());
                Thread.Sleep(50);
            }
        }

        private int FillMoney()
        {
            Random random = new Random();

            int minMoneyValue = 100;
            int maxMoneyValue = 10000;

            int money = random.Next(minMoneyValue, maxMoneyValue);

            return money;
        }
    }

    class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get;  private set; }
    }
}
