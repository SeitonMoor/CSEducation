using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Aquarium
    {
        static void Main(string[] args)
        {
            int maxFishCount = 22;
            bool isWorking = true;
            FishTank fishTank = new FishTank(maxFishCount);

            while (isWorking)
            {
                Console.WriteLine($"Рыбы в аквариуме: {fishTank.GetFishes().Count} / {fishTank.GetMaxSpace()}\n");
                int fishCount = 1;
                foreach (Fish fish in fishTank.GetFishes())
                {
                    Console.WriteLine($"Рыба№{fishCount} - возраст: {fish.GetAge()} / {fish.GetMaxAge()}");
                    fishCount++;
                }

                Console.Write("\nУправление аквариумом:\n" +
                    "add - добавить рыбу в аквариум\n" +
                    "remove - достать рыбу из аквариума\n" +
                    "skip or any key - пропустить год\n" +
                    "exit - закончить симуляцию\n\n" +
                    "Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        fishTank.AddFish();
                        break;

                    case "remove":
                        fishTank.RemoveFish();
                        break;

                    case "exit":
                        isWorking = false;
                        break;

                    default:
                        break;
                }

                fishTank.RecalculateLiveYear();

                Console.ReadKey();
                Console.Clear();
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

            public int GetMaxSpace()
            {
                return _maxSpace;
            }

            public void AddFish()
            {
                if (_fishes.Count >= _maxSpace)
                {
                    Console.WriteLine("\nАквариум переполнен.");
                }
                else
                {
                    Fish fish = CreateFish();

                    Console.WriteLine("\nРыба добавлена.");

                    _fishes.Add(fish);
                }
            }

            public void RemoveFish()
            {
                if (_fishes.Count <= 0)
                {
                    Console.WriteLine("\nАквариум пуст.");
                }
                else
                {
                    Fish fish = GetFish();

                    Console.WriteLine("\nВы достали рыбу.");

                    _fishes.Remove(fish);
                }
            }

            public void RecalculateLiveYear()
            {
                foreach (Fish fish in _fishes)
                {
                    fish.MakeOlder();
                }
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

                    Console.Write("Напишите максимальный возраст рыбы: ");
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

                    if (Int32.TryParse(Console.ReadLine(), out fishIndex) && 0 < fishIndex && fishIndex <= _fishes.Count)
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

            public void MakeOlder()
            {
                _age += 1;
            }
        }
    }
}
