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
            }

            public void SellTickets()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("Направление еще не было создано.");
                }
                else
                {
                    int purchasedTickets = random.Next(1, 836);

                    Direction direction = GetDirection();

                    direction.SetTicketsCount(purchasedTickets);
                }
            }

            public void FormTrain()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("Направление еще не было создано.");
                }
                else
                {
                    Direction direction = GetDirection();

                    Train train = new Train(direction.GetTicketsCount());
                }
            }

            public void SendTrain()
            {
                if (_directions.Count == 0)
                {
                    Console.WriteLine("Направление еще не было создано.");
                }
                else
                {
                    Direction direction = GetDirection();

                    Console.WriteLine($"Рейс: из {direction.GetStartStation()} до {direction.GetEndStation()}" +
                        $" с количеством пассажиров: {direction.GetTicketsCount()} - отправлен.");

                    _directions.Clear();
                }
            }

            public void ShowDirectionInfo()
            {
                Direction direction = GetDirection();

                if (direction != null)
                {
                    Console.WriteLine($"\nТекущий рейс: из {direction.GetStartStation()} до {direction.GetEndStation()}" +
                    $"\nКоличество пассажиров: {direction.GetTicketsCount()}" +
                    $"\nКоличество вагонов: __");
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

            public Train(int passengers)
            {
                while (passengers > 0)
                {
                    Carriage carriage = new Carriage();

                    passengers -= carriage.GetMaxPassengers();

                    _carriages.Add(carriage);
                }
            }
        }
        
        class Carriage
        {
            private int _maxPassengers = 68;

            public int GetMaxPassengers()
            {
                return _maxPassengers;
            }
        }

        class Direction
        {
            private string _startStation;
            private string _endStation;
            private int _purchasedTickets;

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
        }
    }
}
