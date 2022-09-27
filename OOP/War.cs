using System;
using System.Collections.Generic;

namespace OOP
{
    internal class War
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моделирование боя");

            bool isWorking = true;

            while (isWorking)
            {
            }
        }

        class Solder
        {
            private int _health;
            private int _maxHealth;
            private int _damage;
            private int _force;

            public Solder(int health, int maxHealth, int damage)
            {
                _health = health;
                _maxHealth = maxHealth;
                _damage = damage;
            }
        }

        class Troop
        {
            private List<Solder> _solders = new List<Solder>();

            public Troop()
            {
            }
        }

        class Faction
        {
            private string _name;

            public Faction (string name)
            {
                this._name = name;
            }
        }
    }
}
