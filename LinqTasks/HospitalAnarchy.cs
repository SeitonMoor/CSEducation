using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class HospitalAnarchy
    {
        void Work()
        {
            Hospital hospital = new Hospital();

            hospital.Work();
        }
    }

    enum PatientSurname
    {
        Smith,
        Brown,
        Roy,
        Wilson,
        Petrov
    }

    enum PatientName
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

    enum PatientPatronymic
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

    enum Disease
    {
        Flu,
        Malaria,
        Cancer,
        HeartDisease,
        Diabetes
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();
        private readonly int _patientsCount = 30;

        public Hospital()
        {
            FillPatients(_patientsCount);
        }

        public void Work()
        {
            const string SortByFullName = "1";
            const string SortByAge = "2";
            const string GetPatientsWithDisease = "3";
            const string ExitCommand = "0";

            bool isWorking = true;

            while (isWorking)
            {
                List<Patient> patients = new List<Patient>();

                Console.Write("Меню больницы:" +
                    $"\n{SortByFullName} - отсортировать всех больных по фио." +
                    $"\n{SortByAge} - отсортировать всех больных по возрасту." +
                    $"\n{GetPatientsWithDisease} - вывести больных с определенным заболеванием." +
                    $"\n{ExitCommand} - выйти из программы." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case SortByFullName:
                        patients = SortPatientsByFullName();
                        break;

                    case SortByAge:
                        patients = SortPatientsByAge();
                        break;

                    case GetPatientsWithDisease:
                        string disease = GetDisease();
                        patients = this.GetPatientsWithDisease(disease);
                        break;

                    case ExitCommand:
                        isWorking = false;
                        Console.WriteLine("\nЗавершение программы!");
                        break;

                    default:
                        Console.WriteLine("\nДанная команда не известна.");
                        break;
                }

                if (isWorking)
                {
                    Print(patients);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private List<Patient> SortPatientsByFullName() => _patients.OrderBy(patient => patient.FullName).ToList();

        private List<Patient> SortPatientsByAge() => _patients.OrderBy(patient => patient.Age).ToList();

        private List<Patient> GetPatientsWithDisease(string disease) => _patients.Where(patient => patient.Disease == disease).ToList();

        private string GetDisease()
        {
            Console.Write("\nЧтобы вывести список больных с конкретным заболеванием, укажите заболевание: ");

            string disease = Console.ReadLine();

            return disease;
        }

        private void Print(List<Patient> patients)
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("Больные с указанными вводными не найдены.");
                return;
            }

            Console.WriteLine();

            foreach (Patient patient in patients)
            {
                Console.WriteLine($"{patient.FullName} | Возраст: {patient.Age} | Заболевание: {patient.Disease}");
            }
        }

        private void FillPatients(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _patients.Add(new Patient());
                Thread.Sleep(25);
            }
        }
    }

    class Patient
    {
        private readonly Random _random = new Random();

        public Patient()
        {
            FillInformation();
        }

        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        private void FillInformation()
        {
            int minId = 1;
            int minAge = 18;
            int maxAge = 100;

            FullName = GetRandomFullName(minId);
            Age = _random.Next(minAge, maxAge);
            Disease = GetRandomDisease(minId);
        }

        private string GetRandomFullName(int minId)
        {
            Array surnames = Enum.GetValues(typeof(PatientSurname));
            Array names = Enum.GetValues(typeof(PatientName));
            Array patronymics = Enum.GetValues(typeof(PatientPatronymic));

            int surnameId = GetRandomId(minId, surnames.Length);
            int nameId = GetRandomId(minId, names.Length);
            int patronymicId = GetRandomId(minId, patronymics.Length);

            string fullName = $"{(PatientSurname)surnameId} {(PatientName)nameId} {(PatientPatronymic)patronymicId}";

            return fullName;
        }

        private string GetRandomDisease(int minId)
        {
            Array diseases = Enum.GetValues(typeof(Disease));

            int diseaseId = GetRandomId(minId, diseases.Length);

            Disease disease = (Disease)diseaseId;

            return disease.ToString();
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
