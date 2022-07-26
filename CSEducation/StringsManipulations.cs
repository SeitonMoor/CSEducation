using System;

namespace CSEducation
{
    public class StringsManipulations
    {
        public void Manipulations()
        {
            Console.Write("Как вас зовут: ");
            string userName = Console.ReadLine();

            Console.Write("Сколько вам лет: ");
            byte.TryParse(Console.ReadLine(), out byte userAge);

            Console.Write("Какой ваш знак зодиака: ");
            string userZodiaс = Console.ReadLine();

            Console.Write("Место работы: ");
            string userJob = Console.ReadLine();

            Console.WriteLine($"Вас зовут {userName}, вам {userAge} год, вы {userZodiaс} и работаете на {userJob}.");
        }
    }
}