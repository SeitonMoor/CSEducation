using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class TopServerPlayers
    {
        void Work()
        {
            Server server = new Server();

            server.Work();
        }
    }

    enum PlayerName
    {
        William,
        Ivan,
        John,
        Robert,
        Henry,
        Thomas,
        Petr,
        David,
        Alex
    }

    class Server
    {
        private List<Player> _players = new List<Player>();
        private readonly int _playersCount = 20;

        public Server()
        {
            FillPlayers(_playersCount);
        }

        public void Work()
        {
            int topByLevelCount = 3;
            int topByPowerCount = 3;

            string topByLevelMessage = $"\nТоп {topByLevelCount} игроков по уровню:";
            string topByPowerMessage = $"\nТоп {topByPowerCount} игроков по силе:";

            Console.WriteLine("Выполняется запрос на составление топ игроков на сервере по уровню и силе.");

            List<Player> topLevelPlayers = SortPlayersByLevel(topByLevelCount);
            Print(topLevelPlayers, topByLevelMessage);

            List<Player> topPowerPlayers = SortPlayersByPower(topByPowerCount);
            Print(topPowerPlayers, topByPowerMessage);

            Console.ReadKey();
        }

        private List<Player> SortPlayersByLevel(int count) => _players.OrderByDescending(player => player.Level).Take(count).ToList();

        private List<Player> SortPlayersByPower(int count) => _players.OrderByDescending(player => player.Power).Take(count).ToList();

        private void Print(List<Player> players, string message)
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Список игроков пуст.");
                return;
            }

            Console.WriteLine(message);

            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name} | Уровень: {player.Level} | Сила: {player.Power}");
            }
        }

        private void FillPlayers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _players.Add(new Player());
                Thread.Sleep(25);
            }
        }
    }

    class Player
    {
        private readonly Random _random = new Random();

        public Player()
        {
            FillInformation();
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        private void FillInformation()
        {
            int minId = 1;
            int minInt = 1;
            int maxInt = 100;

            Name = GetRandomName(minId);
            Level = _random.Next(minInt, maxInt);
            Power = _random.Next(minInt, maxInt);
        }

        private string GetRandomName(int minId)
        {
            Array names = Enum.GetValues(typeof(PlayerName));

            int nameId = GetRandomId(minId, names.Length);
            PlayerName name = (PlayerName)nameId;

            return name.ToString();
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
