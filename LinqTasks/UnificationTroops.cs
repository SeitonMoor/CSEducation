using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class UnificationTroops
    {
        static void Main(string[] args)
        {
            Fraction fraction = new Fraction();
            fraction.RegroupWarriors();
        }
    }

    enum WarriorName
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

    enum WarriorSurname
    {
        Smith,
        Brown,
        Roy,
        Baker,
        Petrov
    }

    class Fraction
    {
        private List<Warrior> _squad1 = new List<Warrior>();
        private List<Warrior> _squad2 = new List<Warrior>();
        private readonly int _warriorsCount = 10;

        public Fraction()
        {
            FillWarriors(_squad1, _warriorsCount);
            FillWarriors(_squad2, _warriorsCount);
            PrintAllSquads();
        }

        public void RegroupWarriors()
        {
            string surnameSymbol = "B";

            List<Warrior> warriorsToMove = GetWarriorsBySurname(surnameSymbol);

            _squad2 = _squad2.Union(warriorsToMove).ToList();
            _squad1 = _squad1.Where(warrior => warriorsToMove.Contains(warrior) == false).ToList();

            Console.WriteLine("\nОтряды после перегруппировки:");
            PrintAllSquads();
        }

        private List<Warrior> GetWarriorsBySurname(string symbol) => _squad1.Where(warrior => warrior.Surname.StartsWith(symbol)).ToList();

        private void PrintAllSquads()
        {
            string squad1Message = $"Отряд №1 - в количестве {_squad1.Count}: ";
            string squad2Message = $"\nОтряд №2 - в количестве {_squad2.Count}: ";

            Print(_squad1, squad1Message);
            Print(_squad2, squad2Message);
        }

        private void Print(List<Warrior> squad, string message)
        {
            if (squad.Count() == 0)
            {
                Console.WriteLine("Список бойцов пуст.");
                return;
            }

            Console.WriteLine(message);

            foreach (Warrior warrior in squad)
            {
                warrior.PrintInformation();
            }
        }

        private void FillWarriors(List<Warrior> squad, int count)
        {
            for (int i = 0; i < count; i++)
            {
                squad.Add(new Warrior());
                Thread.Sleep(25);
            }
        }
    }

    class Warrior
    {
        private readonly Random _random = new Random();

        public Warrior()
        {
            FillInformation();
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public void PrintInformation()
        {
            Console.WriteLine($"{Name} {Surname}");
        }

        private void FillInformation()
        {
            int minId = 1;

            Name = GetRandomName(minId);
            Surname = GetRandomSurname(minId);
        }

        private string GetRandomName(int minId)
        {
            Array names = Enum.GetValues(typeof(WarriorName));

            int nameId = GetRandomId(minId, names.Length);
            WarriorName name = (WarriorName)nameId;

            return name.ToString();
        }

        private string GetRandomSurname(int minId)
        {
            Array surnames = Enum.GetValues(typeof(WarriorSurname));

            int surnameId = GetRandomId(minId, surnames.Length);
            WarriorSurname surname = (WarriorSurname)surnameId;

            return surname.ToString();
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
