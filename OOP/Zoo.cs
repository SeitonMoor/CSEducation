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
