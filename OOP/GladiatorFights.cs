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
                chosenFighter = CreateFighter();

                if (chosenFighter != null)
                {
                    isChosen = true;
                }
            }

            Console.WriteLine($"\nВы выбрали: {chosenFighter.Name}");
            return chosenFighter;
        }

        private Fighter CreateFighter()
        {
            const string Warrior = "1";
            const string WarriorName = "Воин";
            const string Wizard = "2";
            const string WizardName = "Маг";
            const string Shooter = "3";
            const string ShooterName = "Стрелок";
            const string Paladin = "4";
            const string PaladinName = "Паладин";
            const string Druid = "5";
            const string DruidName = "Друид";

            Console.Write($"\nВыберите бойца:" +
                        $"\n\n{Warrior} - выбрать бойца - {WarriorName}." +
                        $"\n{Wizard} - выбрать бойца - {WizardName}." +
                        $"\n{Shooter} - выбрать бойца - {ShooterName}." +
                        $"\n{Paladin} - выбрать бойца - {PaladinName}." +
                        $"\n{Druid} - выбрать бойца - {DruidName}." +
                        $"\n\nВаш выбор: ");

            switch (Console.ReadLine())
            {
                case Warrior:
                    return new Warrior(WarriorName);

                case Wizard:
                    return new Wizard(WizardName);

                case Shooter:
                    return new Shooter(ShooterName);

                case Paladin:
                    return new Paladin(PaladinName);

                case Druid:
                    return new Druid(DruidName);

                default:
                    Console.WriteLine("\nДанная команда неизвестна");
                    return null;
            }
        }

        private void Battle(Fighter fighter1, Fighter fighter2)
        {
            Console.WriteLine("Битва начинается...");

            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                Fight(fighter1, fighter2);
                Thread.Sleep(1000);
                Fight(fighter2, fighter1);

                Console.WriteLine($"{fighter1.Name} №1 - {fighter1.Health} хп VS {fighter2.Name} №2 - {fighter2.Health} хп");
            }

            ShowWinner(fighter1, fighter2);
        }

        private void Fight(Fighter fighter1, Fighter fighter2)
        {
            fighter1.TakeDamage(fighter2.DealDamage());
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

        public virtual int DealDamage()
        {
            return Damage;
        }

        public virtual void TakeDamage(int damage)
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
        private const int MeleeDamage = 9;
        private const int ArmourLevel = 7;
        private const int MaxHealth = 150;

        public Warrior(string name)
        {
            Name = name;
            Damage = MeleeDamage;
            Armour = ArmourLevel;
            Health = MaxHealth;
        }

        public override void TakeDamage(int damage)
        {
            Random random = new Random();

            damage -= random.Next(Armour);

            base.TakeDamage(damage);
        }
    }

    class Wizard : Fighter
    {
        private const int MeleeDamage = 3;
        private const int ArmourLevel = 2;
        private const int MaxHealth = 80;
        private const int MaxMana = 100;

        private int _mana;

        public Wizard(string name)
        {
            Name = name;
            Damage = MeleeDamage;
            Armour = ArmourLevel;
            Health = MaxHealth;
            _mana = MaxMana;
        }

        public override int DealDamage()
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

    class Shooter : Fighter
    {
        private const int MeleeDamage = 7;
        private const int ArmourLevel = 3;
        private const int MaxHealth = 100;
        private const int MaxAmmo = 20;

        private int _ammunition;

        public Shooter(string name)
        {
            Name = name;
            Damage = MeleeDamage + MeleeDamage;
            Armour = ArmourLevel;
            Health = MaxHealth;
            _ammunition = MaxAmmo;
        }

        public override int DealDamage()
        {
            if (_ammunition > 0)
            {
                _ammunition--;
                return base.DealDamage() + base.DealDamage();
            }
            else
            {
                return MeleeDamage;
            }
        }
    }

    class Paladin : Fighter
    {
        private const int MeleeDamage = 12;
        private const int ArmourLevel = 4;
        private const int MaxHealth = 120;
        private const int MaxMana = 60;

        private int _mana;

        public Paladin(string name)
        {
            Name = name;
            Damage = MeleeDamage;
            Armour = ArmourLevel;
            Health = MaxHealth;
            _mana = MaxMana;
        }

        public override void TakeDamage(int damage)
        {
            int halfHealth = MaxHealth / 2;

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
        private const int MeleeDamage = 5;
        private const int ArmourLevel = 8;
        private const int MaxHealth = 200;
        private const int NaturalPower = 0;

        private int _powerForSummon = 80;
        private int _naturalPower;

        public Druid(string name)
        {
            Name = name;
            Damage = MeleeDamage;
            Armour = ArmourLevel;
            Health = MaxHealth;
            _naturalPower = NaturalPower;
        }

        public override int DealDamage()
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

        public override void TakeDamage(int damage)
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
        private int _damage = 6;

        public int DealDamage()
        {
            return _damage;
        }
    }
}
