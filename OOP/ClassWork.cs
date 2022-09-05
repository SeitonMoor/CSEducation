using System;

namespace OOP
{
    internal class ClassWork
    {
        static void Main(string[] args)
        {
            Player player = new Player(0, 21, "StPe");
            player.PrintInformation();
        }

        class Player
        {
            int id;
            int level;
            string nickname;

            public Player(int id, int level, string nickname)
            {
                this.id = id;
                this.level = level;
                this.nickname = nickname;
            }

            public void PrintInformation()
            {
                Console.WriteLine($"Игрок{id} с ником {nickname} имеет {level} уровень.");
            }
        }
    }
}
