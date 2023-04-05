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
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void Work()
        {
            const string AddCommand = "add";
            const string BanCommand = "ban";
            const string UnbanCommand = "unban";
            const string DeleteCommand = "delete";
            const string ViewAllCommand = "viewAll";
            const string ExitCommand = "exit";

            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("База данных игроков");
                Console.Write("\nМеню команд:" +
                    $"\n\n{AddCommand} - добавить игрока." +
                    $"\n{BanCommand} - забанить игрока." +
                    $"\n{UnbanCommand} - разбанить игрока." +
                    $"\n{DeleteCommand} - удалить игрока." +
                    $"\n{ViewAllCommand} - посмотреть список игроков." +
                    $"\n{ExitCommand} - выйти из программы." +
                    "\n\nВведите команду: ");

                switch (Console.ReadLine())
                {
                    case AddCommand:
                        AddPlayer();
                        break;

                    case BanCommand:
                        BanPlayer();
                        break;

                    case UnbanCommand:
                        UnbanPlayer();
                        break;

                    case DeleteCommand:
                        DeletePlayer();
                        break;

                    case ViewAllCommand:
                        PrintAllPlayers();
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
            Player player = FillPlayerInformation();

            _players.Add(player.Id, player);
            Console.WriteLine("Игрок добавлен в базу данных");
        }

        private void BanPlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
            }
            else
            {
                int id = GetNumber("Напишите ид игрока: ");
                Player player = GetPlayer(id);

                player.Ban();
                Console.WriteLine("Игрок забанен");
            }
        }

        private void UnbanPlayer()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
            }
            else
            {
                int id = GetNumber("Напишите ид игрока: ");
                Player player = GetPlayer(id);

                player.Unban();
                Console.WriteLine("Игрок разбанен");
            }
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
                    id = GetNumber("Напишите ид игрока: ");

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

        private void PrintAllPlayers()
        {
            foreach (Player player in _players.Values)
            {
                Console.WriteLine($"{player.Nickname} - Уровень: {player.Level} | Статус бана: {player.IsBanned}");
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
                    id = GetNumber("Напишите ид игрока: ");
                }
            }

            return player;
        }

        private Player FillPlayerInformation()
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

        public Player(int level, string nickname, bool isBanned = false)
        {
            Id = ++_ids;
            Level = level;
            Nickname = nickname;
            IsBanned = isBanned;
        }

        public int Level { get; private set; }
        public string Nickname { get; private set; }
        public bool IsBanned { get; private set; }

        public int Id { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}
