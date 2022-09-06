using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Store
    {
        /*static void Main(string[] args)
        {
            Player player = new Player();
            Seller seller = new Seller();

            seller.ShowProducts();
        }*/

        class Player
        {
            List<Product> items = new List<Product>();

            public void ViewInventory()
            {
                foreach (Product item in items)
                {
                    Console.Write($"");
                }
            }
        }

        class Seller
        {
            List<Product> products = new List<Product>();

            public Seller()
            {
                products.Add(new Product("Арбуз", 120, 11));
                products.Add(new Product("Апельсин", 60, 99));
                products.Add(new Product("Яблоко", 150, 210));
                products.Add(new Product("Виноград", 50, 45));
                products.Add(new Product("Кофе", 340, 6));
                products.Add(new Product("Миндаль", 330, 12));
            }

            public void ShowProducts()
            {
                foreach (Product product in products)
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
            string name;
            int price;
            int count;

            public Product(string name, int price, int count)
            {
                this.name = name;
                this.price = price;
                this.count = count;
            }

            public string GetName()
            {
                return name;
            }

            public int GetPrice()
            {
                return price;
            }

            public int GetCout()
            {
                return count;
            }
        }
    }
}
