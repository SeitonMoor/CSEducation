using System;
using System.Collections.Generic;

namespace OOP
{
    internal class PlayerDatabase
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Database database = new Database();

            Player som = new Player(0, 2, "som");
            Player trex = new Player(1, 13, "trexxx");
            Player klr = new Player(2, 78, "klr");

            while (isWorking)
            {
                Console.Write("Введите команду: ");

                switch(Console.ReadLine())
                {
                    case "add":
                        database.Add(som);
                        database.Add(trex);
                        database.Add(klr);
                        break;

                    case "ban":
                        database.Ban(trex);
                        database.Ban(klr);
                        break;

                    case "unban":
                        database.Unban(klr);
                        break;

                    case "delete":
                        database.Delete(trex);
                        break;

                    default:
                        break;
                }
            }
        }

        class Database
        {
            private List<Player> _playerDb = new List<Player>();

            public void Add(Player player)
            {
                _playerDb.Add(player);
            }

            public void Ban(Player player)
            {
                player.SetIsBanned(true);
            }

            public void Unban(Player player)
            {
                player.SetIsBanned(false);
            }

            public void Delete(Player player)
            {
                _playerDb.Remove(player);
            }
        }

        class Player
        {
            private int _id;
            private int _level;
            private string _nickname;
            private bool _isBanned;

            public Player(int id, int level, string nickname, bool isBanned = false)
            {
                this._id = id;
                this._level = level;
                this._nickname = nickname;
                this._isBanned = isBanned;
            }

            public void SetIsBanned(bool isBanned)
            {
                this._isBanned = isBanned;
            }
        }
    }
}
