using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    internal class CarService
    {
        static void Main(string[] args)
        {
            Service carService = new Service();

            carService.Work();
        }
    }

    enum CarDetail
    {
        Engine,
        Wheel,
        Headlight,
        Door,
        Bumper,
        ExhaustPipe
    }

    class Service
    {
        private StorageFacility _storageFacility = new StorageFacility();
        private readonly int _workPrice = 150;
        private readonly int _fineCost = 300;
        private int _balance;

        public Service()
        {
            _balance = 0;
        }

        public void Work()
        {
            Queue<Car> carsQueue = GetCars();

            int carNumber = 1;
            while (carsQueue.Count != 0)
            {
                Console.WriteLine("Автосервис");

                ShowStorage();

                Console.WriteLine($"\nДенег на балансе автосервиса: {_balance}");

                DoService(carsQueue.Dequeue(), carNumber);

                carNumber++;

                Console.WriteLine("\nНажмите любую клавишу, чтобы загнать в автосервис следующую машину...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DoService(Car car, int carNumber)
        {
            const string RepairCommand = "1";
            const string CancelCommand = "2";

            Console.WriteLine($"\nОбслуживание машины №{carNumber}.");

            int bill = FormBill(car.Problem);
            bool isServed = false;

            while (isServed == false)
            {
                Console.Write($"У автомобиля проблема с {car.Problem}, цена починки: {bill}" +
                            "\nВы можете:" +
                            $"\n\n{RepairCommand} - произвести починку." +
                            $"\n{CancelCommand} - отказать клиенту." +
                            "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case RepairCommand:
                        isServed = CanRepair(car, bill);
                        break;

                    case CancelCommand:
                        CancelRepair();
                        isServed = true;
                        break;

                    default:
                        Console.WriteLine("Данная команда не известна.");
                        break;
                }
            }
        }

        private void CancelRepair()
        {
            Console.WriteLine("Вы отказываете клиенту и вам придется выплатить штраф.");
            _balance -= _fineCost;
        }

        private bool CanRepair(Car car, int bill)
        {
            Detail chosenDetail = ChooseDetail();
            Detail detailToRepair = _storageFacility.TryGetDetail(car.Problem.ToString());
            int countToChange = 1;

            if (chosenDetail == null || detailToRepair == null || _storageFacility.TryGetCount(chosenDetail) == 0)
            {
                Console.WriteLine("На складе автосервиса закончились такие детали.");
                return false;
            }

            if (_storageFacility.HaveAvailability(countToChange) == false)
            {
                return false;
            }

            _storageFacility.ReduceCount(chosenDetail);

            if (chosenDetail.Name != detailToRepair.Name)
            {
                Console.WriteLine("Когда вы совершили замену детали, было обнаруженно, что проблема была в другом." +
                    "\nПриходится возместить ущерб клиенту.");
                _balance -= bill;
                return true;
            }

            Console.WriteLine("Вы успешно провели ремонт машины.");
            TakeMoney(bill);
            return true;
        }

        private Detail ChooseDetail()
        {
            Detail chosenDetail = null;
            bool isChosen = false;

            while (isChosen == false)
            {
                chosenDetail = TryGetDetail();

                if (chosenDetail != null)
                {
                    isChosen = true;
                }
            }

            Console.WriteLine($"\nВы выбрали: {chosenDetail.Name}");
            return chosenDetail;
        }

        private Detail TryGetDetail()
        {
            ShowDetails();

            Console.Write("\nВаш выбор: ");
            if (Int32.TryParse(Console.ReadLine(), out int detailNumber) == false || IsValidNumber(detailNumber) == false)
            {
                Console.WriteLine("\nДанная команда неизвестна");
                return null;
            }

            int detailId = detailNumber - 1;
            string detailName = ((CarDetail)detailId).ToString();

            return _storageFacility.TryGetDetail(detailName);
        }

        private bool IsValidNumber(int detailNumber)
        {
            return detailNumber > 0 && detailNumber <= _storageFacility.GetDetailsCount();
        }

        private int FormBill(CarDetail carProblem)
        {
            Detail detail = _storageFacility.TryGetDetail(carProblem.ToString());

            if (detail == null)
            {
                return 0;
            }

            int bill = detail.Price + _workPrice;

            return bill;
        }

        private Queue<Car> GetCars()
        {
            Queue<Car> carsQueue = new Queue<Car>();

            int carsNumbers = 10;

            for (int i = 0; i < carsNumbers; i++)
            {
                Car car = new Car();

                carsQueue.Enqueue(car);
                Thread.Sleep(50);
            }

            return carsQueue;
        }

        private void TakeMoney(int money)
        {
            if (money >= 0)
            {
                _balance += money;
            }
        }

        private void ShowDetails()
        {
            Array details = Enum.GetValues(typeof(CarDetail));

            int count = 1;
            Console.WriteLine("\nВыберите деталь:");

            foreach (CarDetail detail in details)
            {
                Console.WriteLine($"{count} - выбрать деталь - {detail}");
                count++;
            }
        }

        private void ShowStorage()
        {
            _storageFacility.PrintDetailsInfo();
        }
    }

    class StorageFacility
    {
        private Dictionary<Detail, int> _details = new Dictionary<Detail, int>();
        private int _countToChange;

        public StorageFacility()
        {
            FillDetails();
        }

        public int GetDetailsCount()
        {
            return _details.Count;
        }

        public bool HaveAvailability(int count)
        {
            _countToChange = 0;

            if (count <= 0)
            {
                Console.WriteLine("Отрицательное количество, минимально возможное - 1.\n");
                return false;
            }
            else
            {
                _countToChange = count;
                return true;
            }
        }

        public void ReduceCount(Detail detail)
        {
            Detail foundDetail = TryGetDetail(detail.Name);

            _details[foundDetail] -= _countToChange;
        }

        public Detail TryGetDetail(string name)
        {
            Detail foundDetail = null;

            foreach (KeyValuePair<Detail, int> detail in _details)
            {
                if (detail.Key.Name == name)
                {
                    foundDetail = detail.Key;
                }
            }

            return foundDetail;
        }

        public int TryGetCount(Detail detailToRepair)
        {
            int foundCount = 0;

            foreach (KeyValuePair<Detail, int> detail in _details)
            {
                if (detail.Key.Name == detailToRepair.Name)
                {
                    foundCount = detail.Value;
                }
            }

            return foundCount;
        }

        public void PrintDetailsInfo()
        {
            if (_details.Count == 0)
            {
                Console.WriteLine("\nВсе детали на складе закончились.");
                return;
            }

            Console.WriteLine("\nДетали на складе:");
            foreach (KeyValuePair<Detail, int> detail in _details)
            {
                detail.Key.PrintInfo(detail.Value);
            }
        }

        private void Add(Detail detail, int count)
        {
            _details.Add(detail, count);
        }

        private void FillDetails()
        {
            Add(new Engine(1200), 2);
            Add(new Wheel(500), 6);
            Add(new Headlight(100), 8);
            Add(new Door(750), 5);
            Add(new Bumper(330), 3);
            Add(new ExhaustPipe(460), 3);
        }
    }

    class Car
    {
        public Car()
        {
            Problem = GetRandomProblem();
        }

        public CarDetail Problem { get; private set; }

        private CarDetail GetRandomProblem()
        {
            Random random = new Random();

            int minNumber = 1;
            Array detailValues = Enum.GetValues(typeof(CarDetail));

            int randomNumber = random.Next(minNumber, detailValues.Length);
            int detailId = randomNumber - 1;

            return (CarDetail)detailId;
        }
    }

    abstract class Detail
    {
        public Detail(int price)
        {
            Price = price;
        }

        public string Name { get; protected set; }
        public int Price { get; protected set; }

        public void PrintInfo(int count)
        {
            Console.WriteLine($"{Name} по цене {Price} | в наличии: {count}");
        }
    }

    class Engine : Detail
    {
        public Engine(int price) : base(price)
        {
            Name = nameof(Engine);
        }
    }

    class Wheel : Detail
    {
        public Wheel(int price) : base(price)
        {
            Name = nameof(Wheel);
        }
    }

    class Headlight : Detail
    {
        public Headlight(int price) : base(price)
        {
            Name = nameof(Headlight);
        }
    }

    class Door : Detail
    {
        public Door(int price) : base(price)
        {
            Name = nameof(Door);
        }
    }

    class Bumper : Detail
    {
        public Bumper(int price) : base(price)
        {
            Name = nameof(Bumper);
        }
    }

    class ExhaustPipe : Detail
    {
        public ExhaustPipe(int price) : base(price)
        {
            Name = nameof(ExhaustPipe);
        }
    }
}
