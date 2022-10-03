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
                Console.WriteLine("База данных игроков");
                Console.Write("\nМеню команд:" +
                    "\n\nadd - добавить игрока." +
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
            private Dictionary<int, Player> _playerDb = new Dictionary<int, Player>();

            public void Add()
            {
                int id = _playerDb.Count;
                Player player = CreatePlayer(id);

                _playerDb.Add(id, player);
            }

            public void Ban()
            {
                int id = GetPlayerId();
                Player player = GetPlayer(id);

                player.SetIsBanned(true);
            }

            public void Unban()
            {
                int id = GetPlayerId();
                Player player = GetPlayer(id);

                player.SetIsBanned(false);
            }

            public void Delete()
            {
                int id = GetPlayerId();

                _playerDb.Remove(id);
            }

            private Player GetPlayer(int id)
            {
                bool isReceived = false;
                Player player;

                do
                {
                    if (_playerDb.TryGetValue(id, out player))
                    {
                        isReceived = true;
                    }
                    else
                    {
                        id = GetPlayerId();
                    }
                }
                while (isReceived == false);

                return player;
            }

            private int GetPlayerId()
            {
                bool isReceived = false;
                int id;

                do
                {
                    Console.Write("Напишите ид игрока: ");

                    if (Int32.TryParse(Console.ReadLine(), out id))
                    {
                        isReceived = true;
                    }
                    else
                    {
                        Console.WriteLine("Ид введен не верно.\n");
                    }
                }
                while (isReceived == false);

                return id;
            }

            private Player CreatePlayer(int id)
            {
                Console.Write("Напишите уровень игрока: ");
                Int32.TryParse(Console.ReadLine(), out int level);

                Console.Write("Напишите имя игрока: ");
                string name = Console.ReadLine();

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
