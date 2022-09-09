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

            seller.ShowProducts();
        }

        class Player
        {
            private List<Product> _items = new List<Product>();

            public void ViewInventory()
            {
                foreach (Product item in _items)
                {
                    Console.Write($"");
                }
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

            public void SellProduct(Player player, Product product)
            {

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
