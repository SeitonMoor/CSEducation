using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqTasks
{
    internal class WeaponsReport
    {
        void Generate()
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();

            militaryUnit.FormReport();
        }
    }

    enum SoldierName
    {
        William,
        Ivan,
        John,
        Robert,
        Henry,
        Thomas,
        Petr,
        David,
        Alex
    }

    enum Rank
    {
        Private,
        Corporal,
        Sergeant,
        WarrantOfficer,
        Lieutenant,
        Captain,
        Major,
        LieutenantColonel,
        Colonel,
        General
    }

    enum Weapon
    {
        AK47,
        M16,
        M4,
        Glock17,
        M249SAW,
        AUG
    }

    class MilitaryUnit
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private readonly int _soldiersCount = 10;

        public MilitaryUnit()
        {
            FillSoldiers(_soldiersCount);
        }

        public void FormReport()
        {
            var report = _soldiers.Select(soldier => new { soldier.Name, soldier.Rank });

            if (report.Count() == 0)
            {
                Console.WriteLine("Список солдат пуст.");
                return;
            }

            Console.WriteLine("Имена и звания солдат:");

            foreach (var soldier in report)
            {
                Console.WriteLine($"{soldier.Name} | Звание: {soldier.Rank}");
            }
        }

        private void FillSoldiers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _soldiers.Add(new Soldier());
                Thread.Sleep(25);
            }
        }
    }

    class Soldier
    {
        private readonly Random _random = new Random();

        public Soldier()
        {
            FillInformation();
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public Rank Rank { get; private set; }
        public int ServicePeriod { get; private set; }

        private void FillInformation()
        {
            int minId = 1;
            int minInt = 1;
            int maxInt = 300;

            Name = GetRandomName(minId);
            Weapon = GetRandomWeapon(minInt);
            Rank = GetRandomRank(minInt);
            ServicePeriod = _random.Next(minInt, maxInt);
        }

        private string GetRandomName(int minId)
        {
            Array names = Enum.GetValues(typeof(SoldierName));

            int nameId = GetRandomId(minId, names.Length);
            SoldierName name = (SoldierName)nameId;

            return name.ToString();
        }

        private string GetRandomWeapon(int minId)
        {
            Array weapons = Enum.GetValues(typeof(Weapon));

            int weaponId = GetRandomId(minId, weapons.Length);
            Weapon weapon = (Weapon)weaponId;

            return weapon.ToString();
        }

        private Rank GetRandomRank(int minId)
        {
            Array ranks = Enum.GetValues(typeof(Rank));

            int rankId = GetRandomId(minId, ranks.Length);

            return (Rank)rankId;
        }

        private int GetRandomId(int minId, int arrayLength) => _random.Next(minId, arrayLength) - 1;
    }
}
