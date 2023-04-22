using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Aquarium
    {
        static void Main(string[] args)
        {
            int maxFishCount = 22;

            FishTank fishTank = new FishTank(maxFishCount);

            fishTank.Simulate();
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

        public void Simulate()
        {
            const string AddCommand = "1";
            const string RemoveCommand = "2";
            const string ExitCommand = "0";

            bool isSimulating = true;

            while (isSimulating)
            {
                Console.WriteLine($"Рыбы в аквариуме: {_fishes.Count} / {_maxSpace}\n");

                ShowFishes();

                Console.Write("\nУправление аквариумом:\n" +
                    $"{AddCommand} - добавить рыбу в аквариум\n" +
                    $"{RemoveCommand} - достать рыбу из аквариума\n" +
                    $"any key - пропустить год\n" +
                    $"{ExitCommand} - закончить симуляцию\n\n" +
                    $"Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case AddCommand:
                        AddFish();
                        break;

                    case RemoveCommand:
                        RemoveFish();
                        break;

                    case ExitCommand:
                        isSimulating = false;
                        Console.WriteLine("Симуляция закончена.");
                        break;

                    default:
                        Console.WriteLine("Год жизни аквариума пропущен...");
                        break;
                }

                RecalculateLiveYear();

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddFish()
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

        private void RemoveFish()
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

        private void RecalculateLiveYear()
        {
            List<Fish> diedFishes = new List<Fish>();

            foreach (Fish fish in _fishes)
            {
                fish.MakeOlder();

                if (fish.IsAlive() == false)
                {
                    diedFishes.Add(fish);
                }
            }

            Die(diedFishes);
        }

        private void Die(List<Fish> fishes)
        {
            foreach (Fish fish in fishes)
            {
                if (fish.IsAlive() == false)
                {
                    _fishes.Remove(fish);
                }
            }
        }

        private Fish CreateFish()
        {
            bool isReceived = false;
            int fishAge = 0;
            int fishMaxAge = 0;

            while (isReceived == false)
            {
                Console.Write("Напишите текущий возраст рыбы: ");
                string inputAge = Console.ReadLine();

                Console.Write("Напишите максимальный возраст рыбы: ");
                string inputMaxAge = Console.ReadLine();

                if (Int32.TryParse(inputAge, out fishAge) && Int32.TryParse(inputMaxAge, out fishMaxAge) && fishAge < fishMaxAge)
                {
                    isReceived = true;
                }
                else
                {
                    Console.WriteLine("Возраст рыбы введен не верно.\n");
                }
            }

            Fish fish = new Fish(fishAge, fishMaxAge);

            return fish;
        }

        private Fish GetFish()
        {
            ShowFishes();

            bool isReceived = false;
            int fishIndex = 0;

            while (isReceived == false)
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

            Fish foundFish = _fishes[fishIndex - 1];

            return foundFish;
        }

        private void ShowFishes()
        {
            if (_fishes.Count == 0)
            {
                Console.WriteLine("Рыб в аквариуме нет.");
                return;
            }

            int fishCount = 1;

            foreach (Fish fish in _fishes)
            {
                fish.PrintInfo(fishCount);
                fishCount++;
            }
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

        public void MakeOlder()
        {
            _age++;
        }

        public bool IsAlive()
        {
            return _age < _maxAge;
        }

        public void PrintInfo(int fishCount)
        {
            Console.WriteLine($"Рыба№{fishCount} - возраст: {_age} / {_maxAge}");
        }
    }
}
