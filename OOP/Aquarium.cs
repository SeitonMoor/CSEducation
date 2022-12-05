using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    internal class Aquarium
    {
        static void Main(string[] args)
        {
            FishTank fishTank = new FishTank(22);

            while (true)
            {
                Console.Write("Управление аквариумом:\n" +
                    "add - добавить рыбу в аквариум\n" +
                    "remove - достать рыбу из аквариума\n\n" +
                    "Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        fishTank.AddFish();
                        break;

                    case "remove":
                        fishTank.RemoveFish();
                        break;

                    default:
                        Console.WriteLine("Данная команда неизвестна");
                        break;
                }

                Console.WriteLine("Рыбы в аквариуме:");
                int fishCount = 1;
                foreach (Fish fish in fishTank.GetFishes())
                {
                    Console.Write($"Рыба№{fishCount} - возраст: {fish.GetAge()} / {fish.GetMaxAge()}");
                    fishCount++;
                }

                Console.ReadKey();
            }
        }

        class FishTank
        {
            private List<Fish> _fishes = new List<Fish>();
            private int _maxSpace;

            public FishTank(int maxSpace)
            {
                _maxSpace = maxSpace;
            }

            public List<Fish> GetFishes()
            {
                return _fishes;
            }

            public void AddFish()
            {
                Fish fish = CreateFish();

                Console.WriteLine("\nРыба добавлена.");

                _fishes.Add(fish);
            }

            public void RemoveFish()
            {
                Fish fish = GetFish();

                Console.WriteLine("\nВы достали рыбу.");

                _fishes.Remove(fish);
            }

            private Fish CreateFish()
            {
                bool isReceived = false;
                int fishAge;
                int fishMaxAge = 0;

                do
                {
                    Console.Write("Напишите текущий возраст рыбы: ");
                    String inputAge = Console.ReadLine();

                    Console.Write("\nНапишите максимальный возраст рыбы: ");
                    String inputMaxAge = Console.ReadLine();

                    if (Int32.TryParse(inputAge, out fishAge) && Int32.TryParse(inputMaxAge, out fishMaxAge))
                    {
                        isReceived = true;
                    }
                    else
                    {
                        Console.WriteLine("Возраст рыбы введен не верно.\n");
                    }
                }
                while (isReceived == false);

                Fish fish = new Fish(fishAge, fishMaxAge);

                return fish;
            }

            private Fish GetFish()
            {
                int fishCount = 1;

                foreach (Fish fish in _fishes)
                {
                    Console.WriteLine($"Рыба№{fishCount} - возраст {fish.GetAge()} / {fish.GetMaxAge()}");
                }

                bool isReceived = false;
                int fishIndex;

                do
                {
                    Console.Write("\nНапишите номер рыбы: ");

                    if (Int32.TryParse(Console.ReadLine(), out fishIndex) && fishIndex <= _fishes.Count)
                    {
                        isReceived = true;
                    }
                    else
                    {
                        Console.WriteLine("Номер рыбы введен не верно.\n");
                    }
                }
                while (isReceived == false);

                Fish foundFish = _fishes[fishIndex - 1];

                return foundFish;
            }
        }

        class Fish
        {
            private int _age;
            private int _maxAge;

            public Fish(int age, int maxAge)
            {
                _age = age;
                _maxAge = maxAge;
            }

            public int GetAge()
            {
                return _age;
            }

            public int GetMaxAge()
            {
                return _maxAge;
            }
        }
    }
}
