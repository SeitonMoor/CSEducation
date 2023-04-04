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
    }

    class Database
    {
        private const string AddCommand = "add";
        private const string BanCommand = "ban";
        private const string UnbanCommand = "unban";
        private const string DeleteCommand = "delete";
        private const string ExitCommand = "exit";

        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void Work()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("База данных игроков");
                Console.Write("\nМеню команд:" +
                    $"\n\n{AddCommand} - добавить игрока." +
                    $"\n{BanCommand} - забанить игрока." +
                    $"\n{UnbanCommand} - разбанить игрока." +
                    $"\n{DeleteCommand} - удалить игрока." +
                    $"\n{ExitCommand} - выйти из программы." +
                    "\n\nВведите команду: ");

                switch (Console.ReadLine())
                {
                    case AddCommand:
                        AddPlayer();
                        break;

                    case BanCommand:
                        PrepareBanUnban(BanCommand);
                        break;

                    case UnbanCommand:
                        PrepareBanUnban(UnbanCommand);
                        break;

                    case DeleteCommand:
                        DeletePlayer();
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Данная команда не известна.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddPlayer()
        {
            Player player = CreatePlayer();

            _players.Add(player.Id, player);
            Console.WriteLine("Игрок добавлен в базу данных");
        }

        private void PrepareBanUnban(string command)
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
            }
            else
            {
                int id = GetPlayerId();
                Player player = GetPlayer(id);

                if (command == BanCommand)
                {
                    BanPlayer(player);
                }
                else if (command == UnbanCommand)
                {
                    UnbanPlayer(player);
                }
            }
        }

        private void BanPlayer(Player player)
        {
            player.GetBan();
            Console.WriteLine("Игрок забанен");
        }

        private void UnbanPlayer(Player player)
        {
            player.GetUnban();
            Console.WriteLine("Игрок разбанен");
        }

        private void DeletePlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
            }
            else
            {
                int id;

                do
                {
                    id = GetPlayerId();

                    if (_players.ContainsKey(id) == false)
                    {
                        Console.WriteLine("Игрок с таким ид не существует.\n");
                    }
                }
                while (_players.ContainsKey(id) == false);

                Console.WriteLine("Игрок удален.");
                _players.Remove(id);
            }
        }

        private Player GetPlayer(int id)
        {
            bool isReceived = false;
            Player player = null;

            while (isReceived == false)
            {
                if (_players.TryGetValue(id, out player))
                {
                    isReceived = true;
                }
                else
                {
                    Console.WriteLine("Игрок с таким ид не существует.\n");
                    id = GetPlayerId();
                }
            }

            return player;
        }

        private int GetPlayerId()
        {
            int id = GetNumber("Напишите ид игрока: ");

            return id;
        }

        private Player CreatePlayer()
        {
            int level = GetNumber("Напишите уровень игрока: ");

            Console.Write("Напишите имя игрока: ");
            string name = Console.ReadLine();

            Player player = new Player(level, name);

            return player;
        }

        private int GetNumber(string request)
        {
            int number = 0;
            bool isReceived = false;

            while (isReceived == false)
            {
                Console.Write(request);

                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    isReceived = true;
                }
                else
                {
                    Console.WriteLine("Число введено не верно.\n");
                }
            }

            return number;
        }
    }

    class Player
    {
        private static int _ids;
        private int _level;
        private string _nickname;
        private bool _isBanned;

        public Player(int level, string nickname, bool isBanned = false)
        {
            Id = ++_ids;
            _level = level;
            _nickname = nickname;
            _isBanned = isBanned;
        }

        public int Id { get; private set; }

        public void GetBan()
        {
            _isBanned = true;
        }

        public void GetUnban()
        {
            _isBanned = false;
        }
    }
}
