using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Zoo
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Зоопарк");
                Console.Write("\nВы можете:" +
                        "\n\n1 - подойти к вальеру №1." +
                        "\n2 - подойти к вальеру №2." +
                        "\n3 - подойти к вальеру №3." +
                        "\n4- подойти к вальеру №4." +
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

                    default:
                        break;
                }

                Console.Clear();
            }
        }

        class Cage
        {
            private string _name;
            private int _animalCount;
            private List<Animal> _animals = new List<Animal>();

            public Cage(string name, int animalCount, List<Animal> animals)
            {
                _name = name;
                _animalCount = animalCount;
                _animals = animals;
            }
        }

        class Animal
        {
            private string _name;
            private string _sound;
            private string _gender;

            public Animal(string name, string sound, string gender)
            {
                _name = name;
                _sound = sound;
                _gender = gender;
            }
        }
    }
}
