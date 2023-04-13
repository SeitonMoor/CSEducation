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

        class Market
        {
            public void Work(Seller seller, Buyer buyer)
            {
                const string SeeCommand = "see";
                const string BuyCommand = "buy";
                const string ViewCommand = "view";
                const string ExitCommand = "exit";

                bool isWorking = true;

                while (isWorking)
                {
                    Console.WriteLine("Магазин");
                    Console.Write("\nВы можете:" +
                        $"\n\n{SeeCommand} - посмотреть список товаров." +
                        $"\n{BuyCommand} - купить товар." +
                        $"\n{ViewCommand} - посмотреть купленные товары." +
                        $"\n{ExitCommand}- закончить покупку." +
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

            public void Trade(Seller seller, Buyer buyer)
            {
                Product product = seller.FindProduct();

                if (product != null)
                {
                    bool isSold = false;

                    while (isSold == false)
                    {
                        Console.Write($"Напишите количество {product.Name} для покупки: ");

                        if (Int32.TryParse(Console.ReadLine(), out int count))
                        {
                            if(product.CheckAvailability(count))
                            {
                                if (product.Count < count)
                                {
                                    Console.WriteLine($"Данного количества товара нет в наличии, максимально возможное - {product.Count}.\n");
                                }
                                else if (product.Count == count)
                                {
                                    buyer.TakeItem(product, count);

                                    seller.SellAllCount(product);

                                    Console.WriteLine($"\nВы совершили покупку {product.Name} в количестве {count}");
                                    isSold = true;
                                }
                                else
                                {
                                    product.ReduceCount();

                                    Product buyerProduct = new Product(product.Name, product.Price, count);

                                    buyer.TakeItem(buyerProduct, count);

                                    Console.WriteLine($"\nВы совершили покупку {product.Name} в количестве {count}");
                                    isSold = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Количество указано не верно.\n");
                        }
                    }
                }
            }
        }

        class Person
        {
            protected List<Product> _items = new List<Product>();

            public void ViewInventory()
            {
                if (_items.Count == 0)
                {
                    Console.WriteLine("Инвентарь пуст.");
                }
                else
                {
                    foreach (Product item in _items)
                    {
                        item.PrintInfo();
                    }
                }
            }
        }

        class Buyer : Person
        {
            public void TakeItem(Product product, int count)
            {
                bool isFound = false;

                foreach (Product item in _items)
                {
                    if (product.Name == item.Name)
                    {
                        item.CheckAvailability(count);
                        item.AddCount();

                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    _items.Add(product);
                }
            }
        }

        class Seller : Person
        {
            public Seller()
            {
                FillProducts();
            }

            public void SellAllCount(Product product)
            {
                _items.Remove(product);
            }

            public Product FindProduct()
            {
                const string EndFind = "end";

                Product foundProduct = null;

                if (_items.Count == 0)
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
                        foreach (Product product in _items)
                        {
                            if (product.Name == name)
                            {
                                foundProduct = product;
                                isFound = true;
                            }
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
                _items.Add(new Product("Арбуз", 120, 11));
                _items.Add(new Product("Апельсин", 60, 99));
                _items.Add(new Product("Яблоко", 150, 210));
                _items.Add(new Product("Виноград", 50, 45));
                _items.Add(new Product("Кофе", 340, 6));
                _items.Add(new Product("Миндаль", 330, 12));
            }
        }

        class Product
        {
            private int _countToChange;

            public Product(string name, int price, int count)
            {
                Name = name;
                Price = price;
                Count = count;
            }

            public string Name { get; private set; }
            public int Price { get; private set; }
            public int Count { get; private set; }

            public bool CheckAvailability(int count)
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

            public void AddCount()
            {
                Count += _countToChange;
            }

            public void ReduceCount()
            {
                Count -= _countToChange;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"{Name} по цене {Price}, в наличии: {Count}");
            }
        }
    }
}
