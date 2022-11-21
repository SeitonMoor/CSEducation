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
                
            while (faction1.GetTroop().GetSoldersCount() > 0 || faction2.GetTroop().GetSoldersCount() > 0)
            {
                faction1.Attack(faction2);
                faction2.Attack(faction1);
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

            public void Attack(Solder solder)
            {
                solder.TakeDamage(_damage);
            }
        }

        class Troop
        {
            private List<Solder> _solders = new List<Solder>();
            Random random = new Random();

            public void AddSolder(Solder solder)
            {
                _solders.Add(solder);
            }

            public List<Solder> GetSolders()
            {
                return _solders;
            }

            public int GetSoldersCount()
            {
                return _solders.Count;
            }

            public Solder GetRandomSolder()
            {
                int index = random.Next(_solders.Count);
                Solder randomSolder = _solders[index];
                return randomSolder;
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

            public Troop GetTroop()
            {
                return _troop;
            }

            public void Attack(Faction faction)
            {
                foreach (Solder solder in _troop.GetSolders())
                {
                    solder.Attack(faction.GetTroop().GetRandomSolder());
                }
            }
        }
    }
}
