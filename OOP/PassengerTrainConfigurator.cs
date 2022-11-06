using System;
using System.Collections.Generic;

namespace OOP
{
    internal class PassengerTrainConfigurator
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Конфигуратор пассажирских поездов");

                station.ShowDirectionInfo();

                Console.Write("\nВы можете:" +
                    "\n\ncreate - создать направление." +
                    "\nsell - продать билеты." +
                    "\nform - сформировать поезд." +
                    "\nsend- отправить поезд." +
                    "\nexit - закончить работу." +
                    "\n\nВаш выбор: ");

                switch (Console.ReadLine())
                {
                    case "create":
                        station.CreateDirection();
                        break;

                    case "sell":
                        station.SellTickets();
                        break;

                    case "form":
                        station.FormTrain();
                        break;

                    case "send":
                        station.SendTrain();
                        break;

                    case "exit":
                        isWorking = false;
                        Console.WriteLine("\nЗавершение программы!");
                        break;

                    default:
                        Console.WriteLine("Данная команда неизвестна");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        class Station
        {
            private List<Direction> _directions = new List<Direction>(1);
            Random random = new Random();

            public void CreateDirection()
            {
                Console.Write("Напишите станцию отправления: ");
                string startStation = Console.ReadLine();

                Console.Write("Напишите станцию прибытия: ");
                string endStation = Console.ReadLine();

                Direction direction = new Direction(startStation, endStation);

                _directions.Add(direction);

                Console.WriteLine($"\nРейс по направлению: {startStation} - {endStation} - успешно создано");
            }

            public void SellTickets()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("\nНаправление еще не было создано.");
                }
                else
                {
                    int purchasedTickets = random.Next(1, 836);

                    Direction direction = GetDirection();

                    direction.SetTicketsCount(purchasedTickets);

                    Console.WriteLine($"\nНа текущий рейс продано - {purchasedTickets} билетов");
                }
            }

            public void FormTrain()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("\nНаправление еще не было создано.");
                }
                else
                {
                    Direction direction = GetDirection();

                    if (direction.GetTicketsCount() <= 0)
                    {
                        Console.WriteLine("\nБилеты на рейс еще не проданы.");
                    }
                    else
                    {
                        Train train = new Train();
                        int passengers = direction.GetTicketsCount();
                        int carriageCount = 1;

                        while (passengers > 0)
                        {
                            int maxPassengers;
                            bool isReceived = false;

                            do
                            {
                                Console.Write($"\nУкажите максимальное количество посадочных мест в вагоне №{carriageCount}: ");

                                if (Int32.TryParse(Console.ReadLine(), out maxPassengers))
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

                            train.AddCarriage(carriage);
                            Console.WriteLine($"Вагон №{carriageCount} добавлен к поезду. Пассажиров осталось к размещению: {passengers}");
                            carriageCount++;
                        }

                        direction.SetTrain(train);

                        Console.WriteLine($"\nПоезд сформирован и готов к отправке, количество вагонов - {train.GetCarriages().Count}");
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

                    if (direction.GetTicketsCount() <= 0)
                    {
                        Console.WriteLine("\nБилеты на рейс еще не проданы.");
                    }
                    else if (direction.GetCarriagesCount() <= 0)
                    {
                        Console.WriteLine("\nПоезд еще не сформирован.");
                    }
                    else
                    {
                        Console.WriteLine($"\nРейс: из {direction.GetStartStation()} до {direction.GetEndStation()}" +
                        $" с количеством пассажиров: {direction.GetTicketsCount()} - отправлен.");

                        _directions.Clear();
                    }
                }
            }

            public void ShowDirectionInfo()
            {
                Direction direction = GetDirection();

                if (direction != null)
                {
                    Console.WriteLine($"\nТекущий рейс: из {direction.GetStartStation()} до {direction.GetEndStation()}" +
                    $"\nКоличество пассажиров: {direction.GetTicketsCount()}" +
                    $"\nКоличество вагонов: {direction.GetCarriagesCount()}");
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

            public List<Carriage> GetCarriages()
            {
                return _carriages;
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
            private string _startStation;
            private string _endStation;
            private int _purchasedTickets;
            private Train _train;

            public Direction(string startStation, string endStation)
            {
                _startStation = startStation;
                _endStation = endStation;
            }

            public string GetStartStation()
            {
                return _startStation;
            }

            public string GetEndStation()
            {
                return _endStation;
            }

            public void SetTicketsCount(int purchasedTickets)
            {
                _purchasedTickets = purchasedTickets;
            }

            public int GetTicketsCount()
            {
                return _purchasedTickets;
            }

            public void SetTrain(Train train)
            {
                _train = train;
            }

            public int GetCarriagesCount()
            {
                if (_train == null)
                {
                    return 0;
                }
                else
                {
                    List<Carriage> carriages = _train.GetCarriages();

                    return carriages.Count;
                }
            }
        }
    }
}
