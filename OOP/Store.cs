using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Store
    {
        private const string SeeCommand = "see";
        private const string BuyCommand = "buy";
        private const string ViewCommand = "view";
        private const string ExitCommand = "exit";

        static void Main(string[] args)
        {
            Buyer buyer = new Buyer();
            Seller seller = new Seller();
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
                        seller.ShowProducts();
                        break;

                    case BuyCommand:
                        seller.SellProduct(buyer);
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

        class Buyer
        {
            private List<Product> _items = new List<Product>();

            public void ViewInventory()
            {
                if (_items.Count == 0)
                {
                    Console.WriteLine("Ваш инвентарь пуст.");
                }
                else
                {
                    foreach (Product item in _items)
                    {
                        Console.WriteLine($"{item.Name} по цене {item.Price}, в наличии: {item.Count}");
                    }
                }
            }

            public void TakeItem(Product product, int count)
            {
                bool isFound = false;

                foreach (Product item in _items)
                {
                    if (product.Name == item.Name)
                    {
                        item.AddCount(count);

                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    _items.Add(product);
                }
            }
        }

        class Seller
        {
            private List<Product> _products = new List<Product>();

            public Seller()
            {
                FillProducts();
            }

            public void ShowProducts()
            {
                foreach (Product product in _products)
                {
                    Console.WriteLine($"{product.Name} по цене {product.Price}, в наличии: {product.Count}");
                }
            }

            public void SellProduct(Buyer player)
            {
                Product product = GetProduct();
                bool isSold = false;

                while (isSold == false)
                {
                    Console.Write($"Напишите количество {product.Name} для покупки: ");

                    if (Int32.TryParse(Console.ReadLine(), out int count))
                    {
                        if (product.Count < count)
                        {
                            Console.WriteLine($"Данного количества товара нет в наличии, максимально возможное - {product.Count}.\n");
                        }
                        else if (product.Count == count)
                        {
                            player.TakeItem(product, count);

                            _products.Remove(product);

                            isSold = true;
                        }
                        else
                        {
                            product.ReduceCount(count);

                            Product playerProduct = new Product(product.Name, product.Price, count);

                            player.TakeItem(playerProduct, count);

                            isSold = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Количество указано не верно.\n");
                    }
                }
            }

            private Product GetProduct()
            {
                Product foundProduct = null;
                bool isFound = false;

                while (isFound == false)
                {
                    Console.Write("Выберите продукт для покупки: ");
                    string name = Console.ReadLine();

                    foreach (Product product in _products)
                    {
                        if (product.Name == name)
                        {
                            foundProduct = product;
                            isFound = true;
                        }
                    }
                }

                return foundProduct;
            }

            private void FillProducts()
            {
                _products.Add(new Product("Арбуз", 120, 11));
                _products.Add(new Product("Апельсин", 60, 99));
                _products.Add(new Product("Яблоко", 150, 210));
                _products.Add(new Product("Виноград", 50, 45));
                _products.Add(new Product("Кофе", 340, 6));
                _products.Add(new Product("Миндаль", 330, 12));
            }
        }

        class Product
        {
            public Product(string name, int price, int count)
            {
                Name = name;
                Price = price;
                Count = count;
            }

            public string Name { get; private set; }
            public int Price { get; private set; }
            public int Count { get; private set; }

            public void AddCount(int count)
            {
                Count += count;
            }

            public void ReduceCount(int count)
            {
                Count -= count;
            }
        }
    }
}
