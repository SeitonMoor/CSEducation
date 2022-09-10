using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OOP
{
    internal class Supermarket
    {

        static void Main(string[] args)
        {
            Queue<Client> clientsQueue = new Queue<Client>();
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
