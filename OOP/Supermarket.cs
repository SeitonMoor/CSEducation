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

            int count = 1;
            while (clientsQueue.Count != 0)
            {
                Client client = clientsQueue.Dequeue();

                Console.Write($"Клиент №{count} ");
                client.BuyProducts();

                count++;
            }
        }

        class Client
        {
            Random random = new Random();

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

            public void BuyProducts()
            {
                if (_items.Count == 0)
                {
                    Console.Write($"выложил все имеющиеся в корзине продукты и решил вернуться к покупкам позже. Его счет: {_money}\n");
                }
                else if (CanBuy())
                {
                    int bill = GetBill();

                    _money -= bill;

                    Console.Write($"совершил покупку {_items.Count} продуктов на сумму {bill}. Его остаток на счете: {_money}\n");

                    _items.Clear();
                }
                else
                {
                    RemoveProduct();
                    BuyProducts();
                }
            }

            private bool CanBuy()
            {
                int bill = GetBill();

                if (_money - bill < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            private int GetBill()
            {
                int bill = 0;

                foreach (Product product in _items)
                {
                    bill += product.GetPrice();
                }

                return bill;
            }

            private void RemoveProduct()
            {
                int count = _items.Count;
                int id = random.Next(count);

                _items.RemoveAt(id);
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
