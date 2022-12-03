using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Aquarium
    {
        static void Main(string[] args)
        {
            FishTank fishTank = new FishTank(22);

            while (true)
            {
                Console.WriteLine($"Рыбы в аквариуме:\n" +
                    $"add - добавить рыбу в аквариум\n" +
                    $"remove - достать рыбу из аквариума\n");

                switch (Console.ReadLine())
                {
                    case "add":
                        fishTank.AddFish(new Fish(2, 10));
                        break;

                    case "remove":
                        fishTank.RemoveFish(new Fish(2, 10));
                        break;

                    default:
                        Console.WriteLine("Данная команда неизвестна");
                        break;
                }

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

            public void AddFish(Fish fish)
            {
                _fishes.Add(fish);
            }

            public void RemoveFish(Fish fish)
            {
                _fishes.Remove(fish);
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
