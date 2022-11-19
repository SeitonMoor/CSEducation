using System;
using System.Collections.Generic;

namespace OOP
{
    internal class War
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Моделирование боя");

            Faction faction1 = new Faction("Фракция №1");
            Faction faction2 = new Faction("Фракция №2");

            while (faction1.GetSoldersCount() > 0 || faction2.GetSoldersCount() > 0)
            {
            }
        }

        class Solder
        {
            private int _health;
            private int _maxHealth;
            private int _damage;
            private int _force;

            public Solder(int maxHealth, int damage)
            {
                _health = maxHealth;
                _maxHealth = maxHealth;
                _damage = damage;
            }

            public void TakeDamage(int damage)
            {
                _health -= damage;
            }

            public int GetDamage()
            {
                return _damage;
            }
        }

        class Troop
        {
            private List<Solder> _solders = new List<Solder>();

            public void AddSolder(Solder solder)
            {
                _solders.Add(solder);
            }

            public int GetSoldersCount()
            {
                return _solders.Count;
            }
        }

        class Faction
        {
            private string _name;
            private Troop _troop = new Troop();

            public Faction (string name)
            {
                this._name = name;
            }

            public string GetName()
            {
                return _name;
            }

            public void AddSolder(Solder solder)
            {
                _troop.AddSolder(solder);
            }

            public int GetSoldersCount()
            {
                return _troop.GetSoldersCount();
            }
        }
    }
}
