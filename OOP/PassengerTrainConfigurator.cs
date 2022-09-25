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
                    "\nend - закончить работу." +
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

                    case "end":
                        isWorking = false;
                        break;

                    default:
                        break;
                }

                Console.Clear();
            }
        }

        class Station
        {
            public void CreateDirection()
            {

            }

            public int SellTickets()
            {
                int purchasedTickets = 0;

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
        }

        class Passenger
        {

        }
    }
}
