using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Store
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Seller seller = new Seller();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Магазин");
                Console.Write("\nВы можете:" +
                    "\n\nsee - посмотреть список товаров." +
                    "\nbuy - купить товар." +
                    "\nview - посмотреть купленные товары." +
                    "\nexit - закончить покупку." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "see":
                        seller.ShowProducts();
                        break;

                    case "buy":
                        seller.SellProduct(player);
                        break;

                    case "view":
                        player.ViewInventory();
                        break;

                    case "exit":
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

        class Player
        {
            private List<Product> _items = new List<Product>();

            public void ViewInventory()
            {
                foreach (Product item in _items)
                {
                    Console.WriteLine($"{item.GetName()} по цене {item.GetPrice()}, в наличии: {item.GetCout()}");
                }
            }

            public void TakeItem(Product product)
            {
                _items.Add(product);
            }
        }

        class Seller
        {
            private List<Product> _products = new List<Product>();

            public Seller()
            {
                _products.Add(new Product("Арбуз", 120, 11));
                _products.Add(new Product("Апельсин", 60, 99));
                _products.Add(new Product("Яблоко", 150, 210));
                _products.Add(new Product("Виноград", 50, 45));
                _products.Add(new Product("Кофе", 340, 6));
                _products.Add(new Product("Миндаль", 330, 12));
            }

            public void ShowProducts()
            {
                foreach (Product product in _products)
                {
                    Console.WriteLine($"{product.GetName()} по цене {product.GetPrice()}, в наличии: {product.GetCout()}");
                }
            }

            public void SellProduct(Player player)
            {
                Product product = GetProduct();
                bool isSold = false;

                do
                {
                    Console.Write($"Напишите количество {product.GetName()} для покупки: ");

                    if (Int32.TryParse(Console.ReadLine(), out int count))
                    {
                        if (product.GetCout() < count)
                        {
                            Console.WriteLine($"Данного количества товара нет в наличии, максимально возможное - {product.GetCout()}.\n");
                        }
                        else if (product.GetCout() == count)
                        {
                            player.TakeItem(product);

                            _products.Remove(product);

                            isSold = true;
                        }
                        else
                        {
                            isSold = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Количество указано не верно.\n");
                    }
                }
                while (isSold == false);
            }

            private Product GetProduct()
            {
                Product foundProduct = null;
                bool isFound = false;

                do
                {
                    Console.Write("Выберите продукт для покупки: ");
                    string name = Console.ReadLine();

                    foreach (Product product in _products)
                    {
                        if (product.GetName() == name)
                        {
                            foundProduct = product;
                            isFound = true;
                        }
                    }
                }
                while (isFound == false);

                return foundProduct;
            }
        }

        class Product
        {
            private string _name;
            private int _price;
            private int _count;

            public Product(string name, int price, int count)
            {
                this._name = name;
                this._price = price;
                this._count = count;
            }

            public string GetName()
            {
                return _name;
            }

            public int GetPrice()
            {
                return _price;
            }

            public int GetCout()
            {
                return _count;
            }
        }
    }
}
