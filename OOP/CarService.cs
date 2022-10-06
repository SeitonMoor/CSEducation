using System;
using System.Collections.Generic;

namespace OOP
{
    internal class CarService
    {
        static void Main(string[] args)
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Автосервис");
                Console.Write("\nПоломка автомобиля - поломка, цена починки: 0" +
                        "\nВы можете:" +
                        "\n\nrepair - произвести починку." +
                        "\ncancel - отказать клиенту." +
                        "\nexit - закончить работу." +
                        "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "repair":
                        break;

                    case "cancel":
                        break;

                    case "exit":
                        isWorking = false;
                        break;

                    default:
                        break;
                }

                Console.Clear();
            }
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
