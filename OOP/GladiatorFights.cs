using System;

namespace OOP
{
    internal class GladiatorFights
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Гладиаторские бои");
            Console.Write("\nВы можете:" +
                    "\n\n1 - выбрать бойца №1 - Воин." +
                    "\n2 - выбрать бойца №2 - Маг." +
                    "\n3 - выбрать бойца №3 - Стрелок." +
                    "\n4- выбрать бойца №4 - Паладин." +
                    "\n5 - выбрать бойца №5 - Друид." +
                    "\n\nВаш выбор: ");

            switch (Console.ReadLine())
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                default:
                    break;
            }

            Console.Clear();
        }

        class Fighter
        {
            private string _name;
            private int _health;
            private int _demage;
        }

        class Warrior : Fighter
        {
            public void Attack()
            {

            }
        }

        class Wizard : Fighter
        {
            public void Attack()
            {

            }
        }

        class Shooter : Fighter
        {
            public void Attack()
            {

            }
        }

        class Paladin : Fighter
        {
            public void Attack()
            {

            }
        }

        class Druid : Fighter
        {
            public void Attack()
            {

            }
        }
    }
}
