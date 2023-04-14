using System;
using System.Collections.Generic;

namespace OOP
{
    internal class PassengerTrainConfigurator
    {
        static void Main(string[] args)
        {
            RailwaySystem system = new RailwaySystem();

            system.Work();
        }

        class RailwaySystem
        {
            private List<Direction> _directions = new List<Direction>(1);

            public void Work()
            {
                const string CreateCommand = "create";
                const string SellCommand = "sell";
                const string FormCommand = "form";
                const string SendCommand = "send";
                const string ExitCommand = "exit";

                bool isWorking = true;

                while (isWorking)
                {
                    Console.WriteLine("Конфигуратор пассажирских поездов");

                    ShowDirectionInfo();

                    Console.Write("\nВы можете:" +
                        $"\n\n{CreateCommand} - создать направление." +
                        $"\n{SellCommand} - продать билеты." +
                        $"\n{FormCommand} - сформировать поезд." +
                        $"\n{SendCommand} - отправить поезд." +
                        $"\n{ExitCommand} - закончить работу." +
                        "\n\nВаш выбор: ");

                    switch (Console.ReadLine())
                    {
                        case CreateCommand:
                            CreateDirection();
                            break;

                        case SellCommand:
                            SellTickets();
                            break;

                        case FormCommand:
                            FormTrain();
                            break;

                        case SendCommand:
                            SendTrain();
                            break;

                        case ExitCommand:
                            isWorking = false;
                            Console.WriteLine("\nЗавершение программы!");
                            break;

                        default:
                            Console.WriteLine("\nДанная команда неизвестна");
                            break;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }

            public void CreateDirection()
            {
                if (_directions.Count > 0)
                {
                    Console.WriteLine("\nНаправление уже создано.");
                }
                else
                {
                    Console.Write("\nНапишите станцию отправления: ");
                    string startStation = Console.ReadLine();

                    Console.Write("Напишите станцию прибытия: ");
                    string endStation = Console.ReadLine();

                    Direction direction = new Direction(startStation, endStation);

                    _directions.Add(direction);

                    Console.WriteLine($"\nРейс по направлению: {startStation} - {endStation} - успешно создано");
                }
            }

            public void SellTickets()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("\nНаправление еще не было создано.");
                }
                else if (GetDirection().PurchasedTickets > 0)
                {
                    Console.WriteLine("\nБилеты по данному направлению уже были проданы.");
                }
                else
                {
                    Direction direction = GetDirection();

                    direction.SellTickets();

                    Console.WriteLine($"\nНа текущий рейс продано - {direction.PurchasedTickets} билетов");
                }
            }

            public void FormTrain()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("\nНаправление еще не было создано.");
                }
                else if (GetDirection().GetCarriagesCount() > 0)
                {
                    Console.WriteLine("\nПоезд по данному направлению уже сформирован и готов к отправке.");
                }
                else
                {
                    Direction direction = GetDirection();

                    if (direction.PurchasedTickets <= 0)
                    {
                        Console.WriteLine("\nБилеты на рейс еще не проданы.");
                    }
                    else
                    {
                        int passengers = direction.PurchasedTickets;
                        int carriageCount = 1;

                        while (passengers > 0)
                        {
                            int maxPassengers;
                            bool isReceived = false;

                            do
                            {
                                Console.Write($"\nУкажите максимальное количество посадочных мест в вагоне №{carriageCount}: ");

                                Int32.TryParse(Console.ReadLine(), out maxPassengers);

                                if (maxPassengers > 0)
                                {
                                    isReceived = true;
                                }
                                else
                                {
                                    Console.WriteLine("Число мест указано не верно.");
                                }
                            }
                            while (isReceived == false);

                            Carriage carriage = new Carriage(maxPassengers);

                            if (passengers - maxPassengers < 0)
                            {
                                passengers = 0;
                            }
                            else
                            {
                                passengers -= maxPassengers;
                            }

                            direction.AddCarriage(carriage);
                            Console.WriteLine($"\nВагон №{carriageCount} добавлен к поезду. Пассажиров осталось к размещению: {passengers}");
                            carriageCount++;
                        }

                        Console.WriteLine($"\nПоезд сформирован и готов к отправке, количество вагонов - {direction.GetCarriagesCount()}");
                    }
                }
            }

            public void SendTrain()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("\nНаправление еще не было создано.");
                }
                else
                {
                    Direction direction = GetDirection();

                    if (direction.PurchasedTickets <= 0)
                    {
                        Console.WriteLine("\nБилеты на рейс еще не проданы.");
                    }
                    else if (direction.GetCarriagesCount() <= 0)
                    {
                        Console.WriteLine("\nПоезд еще не сформирован.");
                    }
                    else
                    {
                        direction.PrintDepartInfo();

                        _directions.Clear();
                    }
                }
            }

            public void ShowDirectionInfo()
            {
                Direction direction = GetDirection();

                if (direction != null)
                {
                    direction.PrintMainInfo();
                }
                else
                {
                    Console.WriteLine("\nРейс не создан.");
                }
            }

            private Direction GetDirection()
            {
                Direction foundDirection = null;

                foreach (Direction direction in _directions)
                {
                    foundDirection = direction;
                }

                return foundDirection;
            }
        }

        class Train
        {
            private List<Carriage> _carriages = new List<Carriage>();

            public void AddCarriage(Carriage carriage)
            {
                _carriages.Add(carriage);
            }

            public int GetCarriagesCount()
            {
                return _carriages.Count;
            }
        }
        
        class Carriage
        {
            private int _maxPassengers;

            public Carriage(int maxPassengers)
            {
                _maxPassengers = maxPassengers;
            }
        }

        class Direction
        {
            private Train _train = new Train();

            public Direction(string startStation, string endStation)
            {
                StartStation = startStation;
                EndStation = endStation;
            }

            public string StartStation { get; private set; }
            public string EndStation { get; private set; }
            public int PurchasedTickets { get; private set; }

            public void SellTickets()
            {
                Random random = new Random();

                int purchasedTickets = random.Next(1, 836);

                PurchasedTickets = purchasedTickets;
            }

            public void AddCarriage(Carriage carriage)
            {
                _train.AddCarriage(carriage);
            }

            public int GetCarriagesCount()
            {
                if (_train == null)
                {
                    return 0;
                }
                else
                {
                    return _train.GetCarriagesCount();
                }
            }

            public void PrintMainInfo()
            {
                Console.WriteLine($"\nТекущий рейс: из {StartStation} до {EndStation}" +
                    $"\nКоличество пассажиров: {PurchasedTickets}" +
                    $"\nКоличество вагонов: {GetCarriagesCount()}");
            }

            public void PrintDepartInfo()
            {
                Console.WriteLine($"\nРейс: из {StartStation} до {EndStation}" +
                        $" с количеством пассажиров: {PurchasedTickets} - отправлен.");
            }
        }
    }
}
