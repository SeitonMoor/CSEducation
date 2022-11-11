using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Supermarket
    {

        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Администрирование супермаркетом");

            Queue<Client> clientsQueue = new Queue<Client>();
            int clientNumbers = 5;

            for (int i = 0; i < clientNumbers; i++)
            {
                Client client = new Client(random.Next(100,10000));

                client.TakeItem(new Product("Кофе", 620));
                client.TakeItem(new Product("Яблоко", 140));
                client.TakeItem(new Product("Конфеты", 370));
                client.TakeItem(new Product("Мясо", 1700));

                clientsQueue.Enqueue(client);
            }

            while (clientsQueue.Count == 0)
            {
                Client client = clientsQueue.Dequeue();
            }
        }

        class Client
        {
            private List<Product> _items = new List<Product>();
            private int _money;

            public Client(int money)
            {
                _money = money;
            }

            public void TakeItem(Product product)
            {
                _items.Add(product);
            }

            public int GetMoney()
            {
                return _money;
            }

            public bool TryToBuy()
            {
                int bill = 0;

                foreach (Product product in _items)
                {
                    bill += product.GetPrice();
                }

                if (_money - bill < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        class Product
        {
            private string _name;
            private int _price;

            public Product(string name, int price)
            {
                _name = name;
                _price = price;
            }

            public string GetName()
            {
                return _name;
            }

            public int GetPrice()
            {
                return _price;
            }
        }
    }
}
