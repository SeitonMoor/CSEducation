using System;

namespace OOP
{
    internal class ClassWork
    {
        void Work()
        {
            User user = new User(0, 21, "StPe");
            user.PrintInformation();
        }
    }

    class User
    {
        private int _id;
        private int _level;
        private string _nickname;

        public User(int id, int level, string nickname)
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
