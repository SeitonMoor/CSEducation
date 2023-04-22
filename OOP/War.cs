using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    internal class War
    {
        static void Main(string[] args)
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

            Faction faction1 = new Faction(factionName1);
            Faction faction2 = new Faction(factionName2);

            Console.WriteLine($"{faction1.Name} vs {faction2.Name}\n");

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

        private void Fight(Faction faction1, Faction faction2)
        {
            faction1.Attack(faction2);
        }

        private void PrintWinning(Faction winningFaction, Faction losingFaction)
        {
            Console.WriteLine($"{winningFaction.Name} одержала полную победу над {losingFaction.Name}" +
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

        public bool IsAlive()
        {
            if (Health > 0)
            {
                return true;
            }

            return false;
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
            if (_shield == 0)
            {
                base.TakeDamage(damage);
                return;
            }

            ProtectByShield(damage);
        }

        private void ProtectByShield(int damage)
        {
            if (damage < 0)
            {
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
            Random random = new Random();

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
        private List<Soldier> _soldiers = new List<Soldier>();

        public void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public int GetSoldiersCount()
        {
            return _soldiers.Count;
        }

        public Soldier GetRandomSoldier()
        {
            Random random = new Random();

            int index = random.Next(_soldiers.Count);

            return _soldiers[index];
        }

        public void Attack(Faction faction)
        {
            foreach (Soldier soldier in _soldiers)
            {
                if (faction.HaveSoldiers() == false)
                {
                    return;
                }

                Soldier randomSoldier = faction.GetRandomSoldier();

                soldier.Attack(randomSoldier);

                faction.VerifyHealth(randomSoldier);
                Thread.Sleep(50);
            }
        }

        public void VerifyHealth(Soldier soldier)
        {
            if (soldier.IsAlive() == false)
            {
                RemoveSoldier(soldier);
            }
        }
    }

    class Faction
    {
        private Troop _troop = new Troop();

        public Faction(string name)
        {
            Name = name;
            FormTroop();
        }

        public string Name { get; private set; }

        public void Attack(Faction faction)
        {
            _troop.Attack(faction);
        }

        public bool HaveSoldiers()
        {
            if (_troop.GetSoldiersCount() == 0)
            {
                return false;
            }

            return true;
        }

        public Soldier GetRandomSoldier()
        {
            return _troop.GetRandomSoldier();
        }

        public void VerifyHealth(Soldier soldier)
        {
            _troop.VerifyHealth(soldier);
        }

        public int GetSoldiersCount()
        {
            return _troop.GetSoldiersCount();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} - количество бойцов: {_troop.GetSoldiersCount()}");
        }

        private void FormTroop()
        {
            _troop.AddSoldier(new MachineGunner(120, 10, 80));
            _troop.AddSoldier(new Sniper(30, 50, 15));
            _troop.AddSoldier(new Soldier(140, 14));
            _troop.AddSoldier(new Soldier(190, 5));
            _troop.AddSoldier(new Soldier(160, 11));
        }
    }
}
