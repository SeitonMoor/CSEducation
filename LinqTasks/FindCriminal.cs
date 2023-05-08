using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class FindCriminal
    {
        static void Main(string[] args)
        {
            Interpol interpol = new Interpol();
            interpol.Work();
        }
    }

    enum SurnameCriminal
    {
        Smith,
        Brown,
        Roy,
        Wilson,
        Petrov
    }

    enum NameCriminal
    {
        William,
        Ivan,
        John,
        Robert,
        Henry,
        Thomas,
        Petr,
        David,
        Alex
    }

    enum PatronymicCriminal
    {
        Adamson,
        Dixon,
        Wilson,
        Thompson,
        Ivanov,
        Petrov,
        Gibson,
        Emberson
    }

    enum Nation
    {
        British,
        American,
        Russian,
        Australian,
        Canadian,
        German,
        Italian
    }

    class Interpol
    {
        private List<Criminal> _criminals = new List<Criminal>();
        private readonly int _databaseSize = 1500;

        public Interpol()
        {
            Console.WriteLine("Подгрузка базы данных преступников... Может занять некоторое время.");
            FillCriminals(_databaseSize);
        }

        public void Work()
        {
            const string ExitCommand = "0";

            bool isWorking = true;

            while(isWorking)
            {
                Console.Clear();
                Console.WriteLine("Поиск преступников");

                var foundCriminals = FindCriminals();

                ShowCriminals(foundCriminals);

                Console.WriteLine("\nAny key - ввести другие данные" +
                    $"\n{ExitCommand} - закончить работу.");

                if(Console.ReadLine() == ExitCommand)
                {
                    isWorking = false;
                    Console.WriteLine("Выключение программы...");
                    Console.ReadKey();
                }
            }
        }
        
        private IEnumerable<Criminal> FindCriminals()
        {
            string heightMessage = "\nУкажите рост престуника: ";
            string weightMessage = "\nУкажите вес преступника: ";

            Nation nation = GetNation();

            int height = GetPositiveNumber(heightMessage);
            int weight = GetPositiveNumber(weightMessage);

            var foundCriminals = from Criminal criminal in _criminals
                                 where criminal.IsMatched(nation, height, weight)
                                 select criminal;

            return foundCriminals;
        }

        private Nation GetNation()
        {
            Array nations = Enum.GetValues(typeof(Nation));
            Nation nation = new Nation();
            bool isReceived = false;

            while (isReceived == false)
            {
                ShowNations(nations);

                Console.Write("\nВаш выбор: ");

                if (Int32.TryParse(Console.ReadLine(), out int nationNumber) == false || IsValidNumber(nations.Length, nationNumber) == false)
                {
                    Console.WriteLine("\nДанная команда неизвестна");
                    continue;
                }

                int nationId = nationNumber - 1;
                nation = (Nation)nationId;

                isReceived = true;
            }

            return nation;
        }

        private int GetPositiveNumber(string message)
        {
            int number = 0;
            bool isReceived = false;

            while (isReceived == false)
            {
                Console.Write(message);

                Int32.TryParse(Console.ReadLine(), out number);

                if (number > 0)
                {
                    isReceived = true;
                    continue;
                }

                Console.WriteLine("Число указано не верно.");
            }

            return number;
        }

        private bool IsValidNumber(int arrayLength, int number)
        {
            return number > 0 && number <= arrayLength;
        }

        private void ShowCriminals(IEnumerable<Criminal> foundCriminals)
        {
            Console.WriteLine($"\nНайдено: {foundCriminals.Count()}");

            int count = 0;

            foreach (Criminal criminal in foundCriminals)
            {
                if (criminal.IsPrisoner)
                {
                    continue;
                }

                Console.WriteLine(criminal.FullName);
                count++;
            }

            int prisonerCriminals = foundCriminals.Count<Criminal>() - count;

            if (prisonerCriminals > 0)
            {
                Console.WriteLine($"Остальные {prisonerCriminals} в заключении");
            }
        }

        private void ShowNations(Array nations)
        {
            int count = 1;
            Console.WriteLine("\nВыберите национальность:");

            foreach (Nation nation in nations)
            {
                Console.WriteLine($"{count} - выбрать национальность - {nation}");
                count++;
            }
        }

        private void FillCriminals(int criminalsCount)
        {
            for (int i = 0; i < criminalsCount; i++)
            {
                _criminals.Add(new Criminal());
                Thread.Sleep(20);
            }
        }
    }

    class Criminal
    {
        private Random _random = new Random();

        public Criminal()
        {
            FillInformation();
        }

        public string FullName { get; private set; }
        public Nation Nation { get; private set; }
        public bool IsPrisoner { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }

        public bool IsMatched(Nation nation, int height, int weight)
        {
            if (Nation != nation || Height != height || Weight != weight)
            {
                return false;
            }

            return true;
        }

        private void FillInformation()
        {
            int minId = 1;
            int minHeight = 170;
            int maxHeight = 180;
            int minWeight = 70;
            int maxWeight = 80;

            FullName = GetRandomFullName(minId);
            Nation = GetRandomNation(minId);
            IsPrisoner = GetRandomBoolean();
            Height = _random.Next(minHeight, maxHeight);
            Weight = _random.Next(minWeight, maxWeight);
        }

        private string GetRandomFullName(int minId)
        {
            Array surnames = Enum.GetValues(typeof(SurnameCriminal));
            Array names = Enum.GetValues(typeof(NameCriminal));
            Array patronymics = Enum.GetValues(typeof(PatronymicCriminal));

            int surnameId = GetRandomId(surnames, minId);
            int nameId = GetRandomId(names, minId);
            int patronymicId = GetRandomId(patronymics, minId);

            string fullName = $"{(SurnameCriminal)surnameId} {(NameCriminal)nameId} {(PatronymicCriminal)patronymicId}";

            return fullName;
        }

        private Nation GetRandomNation(int minId)
        {
            Array nations = Enum.GetValues(typeof(Nation));

            int nationId = GetRandomId(nations, minId);

            return (Nation)nationId;
        }

        private bool GetRandomBoolean()
        {
            int halfMaxValue = Int32.MaxValue / 2;

            return _random.Next() > halfMaxValue;
        }

        private int GetRandomId(Array array, int minId) => _random.Next(minId, array.Length) - 1;
    }
}
