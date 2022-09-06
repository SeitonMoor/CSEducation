using System;
using System.Collections.Generic;

namespace OOP
{
    internal class PlayerDatabase
    {
        /*static void Main(string[] args)
        {
            Database database = new Database();
            Player som = new Player(0, 2, "som");
            Player trex = new Player(1, 13, "trexxx");
            Player klr = new Player(2, 78, "klr");

            database.Add(som);
            database.Add(trex);
            database.Add(klr);

            database.Ban(trex);
            database.Ban(klr);

            database.Unban(klr);

            database.Delete(trex);
        }*/

        class Database
        {
            List<Player> playerDb = new List<Player>();

            public void Add(Player player)
            {
                playerDb.Add(player);
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
                playerDb.Remove(player);
            }
        }

        class Player
        {
            int id;
            int level;
            string nickname;
            bool isBanned;

            public Player(int id, int level, string nickname, bool isBanned = false)
            {
                this.id = id;
                this.level = level;
                this.nickname = nickname;
                this.isBanned = isBanned;
            }

            public void SetIsBanned(bool isBanned)
            {
                this.isBanned = isBanned;
            }
        }
    }
}
