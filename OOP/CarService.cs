using System;
using System.Collections.Generic;

namespace OOP
{
    internal class CarService
    {
        static void Main(string[] args)
        {
        }

        class Service
        {
            private List<Detail> _details = new List<Detail>();
            private int _balance;
        }

        class Detail
        {
            private string _name;
            private int _price;

            public Detail(string name, int price)
            {
                _name = name;
                _price = price;
            }
        }

        class Car
        {
            private string _name;
            private string _damage;

            public Car(string name, string damage)
            {
                _name = name;
                _damage = damage;
            }
        }
    }
}
