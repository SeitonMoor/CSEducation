using System;
using System.Collections.Generic;

namespace OOP
{
    internal class PlayerDatabase
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }

        class Database
        {
            private Dictionary<int, Player> _playerDb = new Dictionary<int, Player>();

            public void Work()
            {
                bool isWorking = true;
                while (isWorking)
                {
                    Console.WriteLine("База данных игроков");
                    Console.Write("\nМеню команд:" +
                        "\n\nadd - добавить игрока." +
                        "\nban - забанить игрока." +
                        "\nunban - разбанить игрока." +
                        "\ndelete - удалить игрока." +
                        "\nexit - выйти из программы." +
                        "\n\nВведите команду: ");

                    switch (Console.ReadLine())
                    {
                        case "add":
                            AddPlayer();
                            break;

                        case "ban":
                            BanPlayer();
                            break;

                        case "unban":
                            UnbanPlayer();
                            break;

                        case "delete":
                            DeletePlayer();
                            break;

                        case "exit":
                            isWorking = false;
                            break;

                        default:
                            break;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }
            }

            private void AddPlayer()
            {
                int id = _playerDb.Count;
                Player player = CreatePlayer(id);

                _playerDb.Add(id, player);
            }

            private void BanPlayer()
            {
                bool isBanned;

                do
                {
                    int id = GetPlayerId();
                    Player player = GetPlayer(id);

                    isBanned = player.CheckIdRequest(id, true);

                    if (isBanned == false)
                    {
                        Console.WriteLine("Ид введен не верно.\n");
                    }
                }
                while (isBanned);
            }

            private void UnbanPlayer()
            {
                bool isUnbanned;

                do
                {
                    int id = GetPlayerId();
                    Player player = GetPlayer(id);

                    isUnbanned = player.CheckIdRequest(id, false);

                    if (isUnbanned == false)
                    {
                        Console.WriteLine("Ид введен не верно.\n");
                    }
                }
                while (isUnbanned);
            }

            private void DeletePlayer()
            {
                int id;

                do
                {
                    id = GetPlayerId();
                }
                while (_playerDb.ContainsKey(id) == false);

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
                while (isReceived);

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
                while (isReceived);

                return id;
            }

            private Player CreatePlayer(int id)
            {
                bool isReceived = false;
                int level;

                do
                {
                    Console.Write("Напишите уровень игрока: ");

                    if (Int32.TryParse(Console.ReadLine(), out level))
                    {
                        isReceived = true;
                    }
                    else
                    {
                        Console.WriteLine("Уровень введен не верно.\n");
                    }
                }
                while (isReceived);

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
                _id = id;
                _level = level;
                _nickname = nickname;
                _isBanned = isBanned;
            }

            public bool CheckIdRequest(int id, bool isBanned)
            {
                if (_id == id)
                {
                    SetBannedStatus(isBanned);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private void SetBannedStatus(bool isBanned)
            {
                _isBanned = isBanned;
            }
        }
    }
}
