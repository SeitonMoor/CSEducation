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
            private int _id;
            private int _level;
            private string _nickname;

            public Player(int id, int level, string nickname)
            {
                this._id = id;
                this._level = level;
                this._nickname = nickname;
            }

            public void PrintInformation()
            {
                Console.WriteLine($"Игрок_{_id} с ником {_nickname} имеет {_level} уровень.");
            }
        }
    }
}
