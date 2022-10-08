using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Supermarket
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Администрирование супермаркетом");

            Queue<Client> clientsQueue = new Queue<Client>();

            while (clientsQueue.Count == 0)
            {
            }
        }

        class Client
        {
            private List<Product> _items = new List<Product>();
            private int _money;
        }

        class Product
        {

        }
    }
}
