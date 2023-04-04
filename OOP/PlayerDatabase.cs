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
        }

        private void BanPlayer()
        {
            bool isBanned = true;

            ChangePlayerStatus(isBanned);
        }

        private void UnbanPlayer()
        {
            bool isBanned = false;

            ChangePlayerStatus(isBanned);
        }

        private void ChangePlayerStatus(bool isBanned)
        {
            bool isChanged = false;

            while (isChanged == false)
            {
                int id = GetPlayerId();
                Player player = GetPlayer(id);

                isChanged = player.CheckIdRequest(id, isBanned);

                if (isChanged == false)
                {
                    Console.WriteLine("Ид введен не верно.\n");
                }
            }
        }

        private void DeletePlayer()
        {
            int id;

            do
            {
                id = GetPlayerId();
            }
            while (_players.ContainsKey(id) == false);

            _players.Remove(id);
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
                    Console.WriteLine("Пользователя с таким ид не существует.\n");
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

        public bool CheckIdRequest(int id, bool isBanned)
        {
            if (Id == id)
            {
                if (isBanned)
                {
                    SetBan();
                }
                else
                {
                    SetUnban();
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetBan()
        {
            _isBanned = true;
        }

        private void SetUnban()
        {
            _isBanned = false;
        }
    }
}
