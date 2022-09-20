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

            while (isWorking)
            {
                Console.WriteLine("База данных игроков\n");
                Console.Write("Меню команд:\n" +
                    "\nadd - добавить игрока." +
                    "\nban - забанить игрока." +
                    "\nunban - разбанить игрока." +
                    "\ndelete - удалить игрока." +
                    "\n\nВведите команду: ");

                switch(Console.ReadLine())
                {
                    case "add":
                        database.Add();
                        break;

                    case "ban":
                        database.Ban();
                        break;

                    case "unban":
                        database.Unban();
                        break;

                    case "delete":
                        database.Delete();
                        break;

                    default:
                        break;
                }
            }
        }

        class Database
        {
            private Dictionary<string, Player> _playerDb = new Dictionary<string, Player>();

            public void Add()
            {
                string name = GetPlayerName();
                Player player = CreatePlayer(name);

                _playerDb.Add(name, player);
            }

            public void Ban()
            {
                string name = GetPlayerName();
                _playerDb.TryGetValue(name, out Player player);

                player.SetIsBanned(true);
            }

            public void Unban()
            {
                string name = GetPlayerName();
                _playerDb.TryGetValue(name, out Player player);

                player.SetIsBanned(false);
            }

            public void Delete()
            {
                string name = GetPlayerName();

                _playerDb.Remove(name);
            }

            private string GetPlayerName()
            {
                Console.Write("Напишите имя игрока: ");
                string name = Console.ReadLine();

                return name;
            }

            private Player CreatePlayer(string name)
            {
                int id = _playerDb.Count;

                Console.Write("Напишите уровень игрока: ");
                Int32.TryParse(Console.ReadLine(), out int level);

                Player player = new Player(id, level, name);

                return player;
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
