using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class Amnesty
    {
        void Agree()
        {
            Arstotzka arstotzka = new Arstotzka();

            arstotzka.Simulate();
        }
    }

    enum PrisonerSurname
    {
        Smith,
        Brown,
        Roy,
        Wilson,
        Petrov
    }

    enum PrisonerName
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

    enum PrisonerPatronymic
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

    enum Crime
    {
        Theft,
        Antigovernment,
        Fraud,
        Murder
    }

    class Arstotzka
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();
        private readonly int _prisonersCount = 30;

        public Arstotzka()
        {
            FillPrisoners(_prisonersCount);
        }

        public void Simulate()
        {
            PrintPrisoners();

            Console.WriteLine("\nВ нашей великой стране Арстоцка произошла амнистия!\n");
            Amnesty();

            PrintPrisoners();
        }

        private void Amnesty()
        {
            Crime amnestyCrime = Crime.Antigovernment;

            _prisoners = _prisoners.Where(prisoner => prisoner.Crime != amnestyCrime).ToList();
        }

        private void PrintPrisoners()
        {
            foreach (Prisoner prisoner in _prisoners)
            {
                Console.WriteLine($"{prisoner.FullName}: {prisoner.Crime}");
            }
        }

        private void FillPrisoners(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _prisoners.Add(new Prisoner());
                Thread.Sleep(25);
            }
        }
    }

    class Prisoner
    {
        private readonly Random _random = new Random();

        public Prisoner()
        {
            FillInformation();
        }

        public string FullName { get; private set; }
        public Crime Crime { get; private set; }

        private void FillInformation()
        {
            int minId = 1;

            FullName = GetRandomFullName(minId);
            Crime = GetRandomCrime(minId);
        }

        private string GetRandomFullName(int minId)
        {
            Array surnames = Enum.GetValues(typeof(PrisonerSurname));
            Array names = Enum.GetValues(typeof(PrisonerName));
            Array patronymics = Enum.GetValues(typeof(PrisonerPatronymic));

            int surnameId = GetRandomId(minId, surnames.Length);
            int nameId = GetRandomId(minId, names.Length);
            int patronymicId = GetRandomId(minId, patronymics.Length);

            string fullName = $"{(PrisonerSurname)surnameId} {(PrisonerName)nameId} {(PrisonerPatronymic)patronymicId}";

            return fullName;
        }

        private Crime GetRandomCrime(int minId)
        {
            Array crimes = Enum.GetValues(typeof(Crime));

            int crimeId = GetRandomId(minId, crimes.Length);

            return (Crime)crimeId;
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
