using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Zoo
    {
        void Work()
        {
            ZooTerritory zoo = new ZooTerritory();

            zoo.Work();
        }
    }

    class ZooTerritory
    {
        private List<Cage> _cages = new List<Cage>();

        public ZooTerritory()
        {
            FillCages();
        }

        public void Work()
        {
            const string EndCommand = "0";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Зоопарк");

                Cage cage = ChooseCage();
                cage.PrintInfo();

                Console.WriteLine("\nany key - посмотреть еще волеры." +
                    $"\n{EndCommand} - закончить прогулку по зоопарку.");

                if (Console.ReadLine() == EndCommand)
                {
                    isWorking = false;
                }

                Console.Clear();
            }

            Console.WriteLine($"Всего доброго! Возвращайтесь в наш зоопарк.");
        }

        private Cage ChooseCage()
        {
            Cage chosenCage = null;

            while (chosenCage == null)
            {
                chosenCage = TryGetCage();
            }

            int cageNumber = _cages.IndexOf(chosenCage) + 1;
            Console.WriteLine($"\nВы выбрали вольер №{cageNumber}");

            return chosenCage;
        }

        private Cage TryGetCage()
        {
            int count = 1;
            Console.WriteLine("\nВыберите вольер:");

            foreach (Cage cage in _cages)
            {
                Console.WriteLine($"{count} - подойти к вольеру №{count}");
                count++;
            }

            Console.Write("\nВаш выбор: ");
            if (Int32.TryParse(Console.ReadLine(), out int cageNumber) == false || IsValidNumber(cageNumber) == false)
            {
                Console.WriteLine("\nДанная команда неизвестна");
                return null;
            }

            int cageId = cageNumber - 1;

            return _cages[cageId];
        }

        private bool IsValidNumber(int cageNumber)
        {
            return cageNumber > 0 && cageNumber <= _cages.Count;
        }

        private void FillCages()
        {
            List<Cage> cages = InitializeCages();

            foreach (Cage cage in cages)
            {
                _cages.Add(cage);
            }
        }

        private List<Cage> InitializeCages()
        {
            List<Cage> cages = new List<Cage>()
            {
                new Cage(new List<Animal>(){ new Tiger("мужской"), new Tiger("мужской"), new Tiger("мужской")}),
                new Cage(new List<Animal>(){ new Snake("женский")}),
                new Cage(new List<Animal>(){ new Owl("женский"), new Owl("мужской"), new Owl("женский"), new Owl("мужской")}),
                new Cage(new List<Animal>(){ new Goat("мужской"), new Goat("женский") }),
                new Cage(new List<Animal>(){ new Pig("женский"), new Pig("мужской"), new Pig("мужской")})
            };

            return cages;
        }
    }

    class Cage
    {
        private List<Animal> _animals = new List<Animal>();

        public Cage(List<Animal> animals)
        {
            _animals = animals;
        }

        public void PrintInfo()
        {
            if (_animals.Count == 0)
            {
                Console.WriteLine("\nДанный вольер пуст.");
                return;
            }

            ShowStatus();

            foreach (Animal animal in _animals)
            {
                animal.PrintInfo();
            }
        }

        private void ShowStatus()
        {
            Animal animal = _animals[0];

            Console.WriteLine($"\nЭто вольер с {animal.Name}. В данном вольере {_animals.Count} животных.");
        }
    }

    abstract class Animal
    {
        public Animal(string gender)
        {
            Gender = gender;
        }

        public string Name { get; protected set; }
        public string Gender { get; protected set; }
        public string Sound { get; protected set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Особь {Name} - пол {Gender}. Издает звук: {Sound}");
        }
    }

    class Tiger : Animal
    {
        public Tiger(string gender) : base(gender)
        {
            Name = nameof(Tiger);
            Sound = "р-р-р-р";
        }
    }

    class Snake : Animal
    {
        public Snake(string gender) : base(gender)
        {
            Name = nameof(Snake);
            Sound = "ш-ш-ш-ш";
        }
    }

    class Owl : Animal
    {
        public Owl(string gender) : base(gender)
        {
            Name = nameof(Owl);
            Sound = "ух-ух-ух";
        }
    }

    class Goat : Animal
    {
        public Goat(string gender) : base(gender)
        {
            Name = nameof(Goat);
            Sound = "ме-е-е";
        }
    }

    class Pig : Animal
    {
        public Pig(string gender) : base(gender)
        {
            Name = nameof(Pig);
            Sound = "хрю-хрю";
        }
    }
}
