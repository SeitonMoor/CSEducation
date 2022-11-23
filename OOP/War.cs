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
                
            while (faction1.GetTroop().GetSoldiersCount() > 0 || faction2.GetTroop().GetSoldiersCount() > 0)
            {
                faction1.Attack(faction2);
                faction2.Attack(faction1);
            }
        }

        class Soldier
        {
            private int _health;
            private int _maxHealth;
            private int _damage;
            private int _force;

            public Soldier(int maxHealth, int damage)
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

            public void Attack(Soldier soldier)
            {
                soldier.TakeDamage(_damage);
            }

            public bool IsAlive()
            {
                if (_health > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class Troop
        {
            private List<Soldier> _soldiers = new List<Soldier>();
            Random random = new Random();

            public void AddSoldier(Soldier soldier)
            {
                _soldiers.Add(soldier);
            }

            public List<Soldier> GetSoldiers()
            {
                return _soldiers;
            }

            public int GetSoldiersCount()
            {
                return _soldiers.Count;
            }

            public Soldier GetRandomSoldier()
            {
                int index = random.Next(_soldiers.Count);
                Soldier randomSoldier = _soldiers[index];
                return randomSoldier;
            }

            public void DeleteSoldier(Soldier soldier)
            {
                _soldiers.Remove(soldier);
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
                foreach (Soldier soldier in _troop.GetSoldiers())
                {
                    Soldier randomSoldier = faction.GetTroop().GetRandomSoldier();

                    soldier.Attack(randomSoldier);

                    if (randomSoldier.IsAlive() == false)
                    {
                        faction.GetTroop().DeleteSoldier(randomSoldier);
                    }
                }
            }
        }
    }
}
