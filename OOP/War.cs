﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    internal class War
    {
        void SimulateBattle()
        {
            Battlefield battlefield = new Battlefield();

            string name1 = "Фракция №1";
            string name2 = "Фракция №2";

            battlefield.SimulateBattle(name1, name2);
        }
    }

    class Battlefield
    {
        public void SimulateBattle(string factionName1, string factionName2)
        {
            Console.WriteLine("Моделирование боя");

            Troop faction1 = new Troop(factionName1);
            Troop faction2 = new Troop(factionName2);

            Console.WriteLine($"{faction1.FractionName} vs {faction2.FractionName}\n");

            while (faction1.HaveSoldiers() && faction2.HaveSoldiers())
            {
                faction1.PrintInfo();
                faction2.PrintInfo();

                Fight(faction1, faction2);
                Fight(faction2, faction1);

                Console.WriteLine();
            }

            if (faction1.HaveSoldiers())
            {
                PrintWinning(faction1, faction2);
            }
            else if (faction2.HaveSoldiers())
            {
                PrintWinning(faction2, faction1);
            }
        }

        private void Fight(Troop faction1, Troop faction2)
        {
            faction1.Attack(faction2);
        }

        private void PrintWinning(Troop winningFaction, Troop losingFaction)
        {
            Console.WriteLine($"{winningFaction.FractionName} одержала полную победу над {losingFaction.FractionName}" +
                        $"\nКоличество оставшихся бойцов: {winningFaction.GetSoldiersCount()}");
        }
    }

    class Soldier
    {
        protected int Health;
        protected int Damage;

        public Soldier(int maxHealth, int damage)
        {
            Health = maxHealth;
            Damage = damage;
        }

        public bool IsAlive() => Health > 0;

        public virtual void Attack(Soldier soldier)
        {
            soldier.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int damage)
        {
            if (Health - damage < 0)
            {
                Health = 0;
            }
            else if (damage > 0)
            {
                Health -= damage;
            }
        }
    }

    class MachineGunner : Soldier
    {
        private int _shield;

        public MachineGunner(int maxHealth, int damage, int shield) : base(maxHealth, damage)
        {
            _shield = shield;
        }

        public override void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            if (_shield == 0)
            {
                base.TakeDamage(damage);
                return;
            }

            if (_shield - damage > 0)
            {
                _shield -= damage;
                return;
            }

            damage -= _shield;
            _shield = 0;

            base.TakeDamage(damage);
        }
    }

    class Sniper : Soldier
    {
        private readonly Random random = new Random();
        private readonly int _maxHitValue = 101;
        private readonly int _accuracy;
        private readonly int _hitValue;

        public Sniper(int maxHealth, int damage, int accuracy) : base(maxHealth, damage)
        {
            _accuracy = accuracy;
            _hitValue = _maxHitValue - _accuracy;
        }

        public override void Attack(Soldier soldier)
        {
            if (IsShotHit())
            {
                base.Attack(soldier);
            }
        }

        private bool IsShotHit()
        {
            int shot = random.Next(_maxHitValue);

            if (shot >= _hitValue)
            {
                return true;
            }

            return false;
        }
    }

    class Troop
    {
        private readonly Random random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        public Troop(string name)
        {
            FractionName = name;
            AddSoldiers();
        }

        public string FractionName { get; private set; }

        public int GetSoldiersCount() => _soldiers.Count;

        public bool HaveSoldiers() => _soldiers.Count > 0;

        public Soldier GetRandomSoldier()
        {
            int index = random.Next(_soldiers.Count);

            return _soldiers[index];
        }

        public void Attack(Troop faction)
        {
            foreach (Soldier soldier in _soldiers)
            {
                if (faction.HaveSoldiers() == false)
                {
                    return;
                }

                Soldier randomSoldier = faction.GetRandomSoldier();

                soldier.Attack(randomSoldier);

                faction.RemoveDied(randomSoldier);
                Thread.Sleep(50);
            }
        }

        public void RemoveDied(Soldier soldier)
        {
            if (soldier.IsAlive() == false)
            {
                _soldiers.Remove(soldier);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{FractionName} - количество бойцов: {_soldiers.Count}");
        }

        private void AddSoldiers()
        {
            _soldiers.Add(new MachineGunner(120, 10, 80));
            _soldiers.Add(new Sniper(30, 50, 15));
            _soldiers.Add(new Soldier(140, 14));
            _soldiers.Add(new Soldier(190, 5));
            _soldiers.Add(new Soldier(160, 11));
        }
    }
}
