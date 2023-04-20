using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP
{
    internal class GladiatorFights
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Work();
        }
    }

    class Arena
    {
        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Гладиаторские бои");

                Fighter fighter1 = ChooseFighter();
                Fighter fighter2 = ChooseFighter();

                Console.Clear();

                Battle(fighter1, fighter2);

                isWork = DoNewBattle();

                Console.ReadKey();
                Console.Clear();
            }
        }

        private bool DoNewBattle()
        {
            const string NewBattle = "1";

            Console.Write($"\nЖелаете провести еще одну битву? ({NewBattle} - Да | Любая клавиша - Нет): ");

            switch (Console.ReadLine())
            {
                case NewBattle:
                    Console.WriteLine("\nДа начнется новый бой!");
                    return true;

                default:
                    Console.WriteLine("\nАрена на сегодня закрывается.");
                    return false;
            }
        }

        private Fighter ChooseFighter()
        {
            Fighter chosenFighter = null;
            bool isChosen = false;

            while (isChosen == false)
            {
                chosenFighter = TryGetFighter();

                if (chosenFighter != null)
                {
                    isChosen = true;
                }
            }

            Console.WriteLine($"\nВы выбрали: {chosenFighter.Name}");
            return chosenFighter;
        }

        private Fighter TryGetFighter()
        {
            List<Fighter> fighters = InitializeFighters();

            int count = 1;
            Console.WriteLine("\nВыберите бойца:");

            foreach (Fighter fighter in fighters)
            {
                Console.WriteLine($"{count} - выбрать бойца - {fighter.Name}");
                count++;
            }

            Console.Write("\nВаш выбор: ");
            if(Int32.TryParse(Console.ReadLine(), out int fighterNumber) == false || IsValidNumber(fighters, fighterNumber) == false)
            {
                Console.WriteLine("\nДанная команда неизвестна");
                return null;
            }

            int fighterId = fighterNumber - 1;

            return fighters[fighterId];
        }

        private bool IsValidNumber(List<Fighter> fighters, int fighterNumber)
        {
            if (fighterNumber > 0 && fighterNumber <= fighters.Count)
            {
                return true;
            }

            return false;
        }

        private List<Fighter> InitializeFighters()
        {
            List<Fighter> fighters = new List<Fighter>
            {
                new Warrior(),
                new Wizard(),
                new Hunter(),
                new Paladin(),
                new Druid()
            };

            return fighters;
        }

        private void Battle(Fighter fighter1, Fighter fighter2)
        {
            Console.WriteLine("Битва начинается...");

            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                Fight(fighter1, fighter2);
                Thread.Sleep(500);
                Fight(fighter2, fighter1);

                Console.WriteLine($"{fighter1.Name} №1 - {fighter1.Health} хп VS {fighter2.Name} №2 - {fighter2.Health} хп");
            }

            ShowWinner(fighter1, fighter2);
        }

        private void Fight(Fighter fighter1, Fighter fighter2)
        {
            fighter1.Attack(fighter2);
        }

        private void ShowWinner(Fighter fighter1, Fighter fighter2)
        {
            if (fighter1.Health > 0)
            {
                Console.WriteLine($"\n{fighter1.Name} №1 выходит победителем из этой схватки.");
            }
            else if (fighter2.Health > 0)
            {
                Console.WriteLine($"\n{fighter2.Name} №2 выходит победителем из этой схватки.");
            }
            else
            {
                Console.WriteLine($"\n{fighter1.Name} и {fighter2.Name} - оба погибли на арене.");
            }
        }
    }

    abstract class Fighter
    {
        protected int Damage;
        protected int Armour;

        public string Name { get; protected set; }
        public int Health { get; protected set; }

        public void Attack(Fighter fighter)
        {
            int damage = DealDamage();

            fighter.TakeDamage(damage);
        }

        protected virtual int DealDamage()
        {
            return Damage;
        }

        protected virtual void TakeDamage(int damage)
        {
            damage -= Armour;
            if (damage < 0)
            {
                damage = 1;
            }

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

    class Warrior : Fighter
    {
        private readonly int _meleeDamage = 9;
        private readonly int _armourLevel = 7;
        private readonly int _maxHealth = 150;

        public Warrior()
        {
            Name = nameof(Warrior);
            Damage = _meleeDamage;
            Armour = _armourLevel;
            Health = _maxHealth;
        }

        protected override void TakeDamage(int damage)
        {
            Random random = new Random();

            damage -= random.Next(Armour);

            base.TakeDamage(damage);
        }
    }

    class Wizard : Fighter
    {
        private readonly int _meleeDamage = 3;
        private readonly int _armourLevel = 2;
        private readonly int _maxHealth = 80;
        private readonly int _maxMana = 100;

        private int _mana;

        public Wizard()
        {
            Name = nameof(Wizard);
            Damage = _meleeDamage;
            Armour = _armourLevel;
            Health = _maxHealth;
            _mana = _maxMana;
        }

        protected override int DealDamage()
        {
            if (_mana > 0)
            {
                return CastSpell();
            }
            else
            {
                RefillMana();
                return base.DealDamage();
            }
        }

        private int CastSpell()
        {
            Random random = new Random();

            int minDamage = 5;
            int maxDamage = 35;

            int damage = random.Next(minDamage, maxDamage);

            if (_mana - damage < 0)
            {
                damage = _mana;
                _mana = 0;

                return damage;
            }
            else
            {
                _mana -= damage;

                return damage;
            }
        }

        private void RefillMana()
        {
            Random random = new Random();

            int minRefill = 10;
            int maxRefill = 25;

            _mana += random.Next(minRefill, maxRefill);
        }
    }

    class Hunter : Fighter
    {
        private readonly int _meleeDamage = 7;
        private readonly int _armourLevel = 3;
        private readonly int _maxHealth = 100;
        private readonly int _maxAmmo = 20;

        private int _ammunition;

        public Hunter()
        {
            Name = nameof(Hunter);
            Damage = _meleeDamage + _meleeDamage;
            Armour = _armourLevel;
            Health = _maxHealth;
            _ammunition = _maxAmmo;
        }

        protected override int DealDamage()
        {
            if (_ammunition > 0)
            {
                _ammunition--;
                return base.DealDamage() + base.DealDamage();
            }
            else
            {
                return _meleeDamage;
            }
        }
    }

    class Paladin : Fighter
    {
        private readonly int _meleeDamage = 12;
        private readonly int _armourLevel = 4;
        private readonly int _maxHealth = 120;
        private readonly int _maxMana = 60;

        private int _mana;

        public Paladin()
        {
            Name = nameof(Paladin);
            Damage = _meleeDamage;
            Armour = _armourLevel;
            Health = _maxHealth;
            _mana = _maxMana;
        }

        protected override void TakeDamage(int damage)
        {
            int halfHealth = _maxHealth / 2;

            base.TakeDamage(damage);

            if (Health < halfHealth)
            {
                Heal();
            }
        }

        private void Heal()
        {
            int manaForHeal = 20;

            if (_mana >= manaForHeal)
            {
                Random random = new Random();

                int minHeal = 5;
                int maxHeal = 20;

                _mana -= manaForHeal;
                Health += random.Next(minHeal, maxHeal);
            }
        }
    }

    class Druid : Fighter
    {
        private readonly int _meleeDamage = 5;
        private readonly int _armourLevel = 8;
        private readonly int _maxHealth = 200;
        private readonly int _powerForSummon = 80;

        private int _naturalPower = 0;

        public Druid()
        {
            Name = nameof(Druid);
            Damage = _meleeDamage;
            Armour = _armourLevel;
            Health = _maxHealth;
        }

        protected override int DealDamage()
        {
            if (_naturalPower >= _powerForSummon)
            {
                List<Ent> ents = SummonEnts();

                int damage = AttackByEnts(ents);

                return damage;
            }
            else
            {
                return base.DealDamage();
            }
        }

        protected override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            _naturalPower += damage;
        }

        private List<Ent> SummonEnts()
        {
            Random random = new Random();
            List<Ent> ents = new List<Ent>();

            int minEnts = 2;
            int maxEnts = 8;

            int entsCount = random.Next(minEnts, maxEnts);

            for (int i = 0; i < entsCount; i++)
            {
                ents.Add(new Ent());
            }

            return ents;
        }

        private int AttackByEnts(List<Ent> ents)
        {
            int entsDamage = 0;
            foreach (Ent ent in ents)
            {
                entsDamage += ent.DealDamage();
            }

            _naturalPower = 0;

            return entsDamage;
        }
    }

    class Ent
    {
        private readonly int _damage = 6;

        public int DealDamage()
        {
            return _damage;
        }
    }
}
