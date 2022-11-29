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

            faction1.GetTroop().AddSoldier(new Soldier(100, 19));
            faction1.GetTroop().AddSoldier(new Soldier(30, 50));
            faction1.GetTroop().AddSoldier(new Soldier(140, 14));
            faction1.GetTroop().AddSoldier(new Soldier(190, 5));
            faction1.GetTroop().AddSoldier(new Soldier(160, 11));

            faction2.GetTroop().AddSoldier(new Soldier(100, 21));
            faction2.GetTroop().AddSoldier(new Soldier(200, 3));
            faction2.GetTroop().AddSoldier(new Soldier(120, 24));
            faction2.GetTroop().AddSoldier(new Soldier(150, 25));
            faction2.GetTroop().AddSoldier(new Soldier(50, 32));

            Console.WriteLine($"{faction1.GetName()} vs {faction2.GetName()}\n");

            while (faction1.GetTroop().GetSoldiersCount() > 0 && faction2.GetTroop().GetSoldiersCount() > 0)
            {
                Console.WriteLine($"{faction1.GetName()} количество бойцов: {faction1.GetTroop().GetSoldiersCount()}" +
                    $"\n{faction2.GetName()} количество бойцов: {faction2.GetTroop().GetSoldiersCount()}\n");

                faction1.Attack(faction2);
                faction2.Attack(faction1);
            }

            if (faction1.GetTroop().GetSoldiersCount() > 0)
            {
                PrintWinningFaction(faction1, faction2);
            }
            else if (faction2.GetTroop().GetSoldiersCount() > 0)
            {
                PrintWinningFaction(faction2, faction1);
            }

            void PrintWinningFaction(Faction winningFaction, Faction losingFaction) => 
                Console.WriteLine($"{winningFaction.GetName()} одержала полную победу над {losingFaction.GetName()}" +
                        $"\nКоличество оставшихся бойцов: {winningFaction.GetTroop().GetSoldiersCount()}");
        }

        class Soldier
        {
            private int _health;
            private int _damage;
            private int _force;

            public Soldier(int maxHealth, int damage)
            {
                _health = maxHealth;
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
                _name = name;
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
                    if (faction.GetTroop().GetSoldiersCount() > 0)
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
}
