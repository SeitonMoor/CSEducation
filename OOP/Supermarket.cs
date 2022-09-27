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
            bool isWorking = true;

            while (isWorking)
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
