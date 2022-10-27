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

                Console.Clear();
            }
        }

        class Station
        {
            private List<Direction> _directions;
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

            public int SellTickets()
            {
                int purchasedTickets = random.Next(1, 836);

                return purchasedTickets;
            }

            public void FormTrain()
            {

            }

            public void SendTrain()
            {

            }

            public void ShowDirectionInfo()
            {

            }
        }

        class Train
        {
            
        }

        class Direction
        {
            private string _startStation;
            private string _endStation;

            public Direction(string startStation, string endStation)
            {
                _startStation = startStation;
                _endStation = endStation;
            }
        }

        class Passenger
        {

        }
    }
}
