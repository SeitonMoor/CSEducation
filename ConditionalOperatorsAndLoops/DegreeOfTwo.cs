using System;

namespace ConditionalOperatorsAndLoops
{
    internal class DegreeOfTwo
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            uint number = 2;
            int minDegree = 0;
            int setNumber = random.Next();

            uint numberInDegree = number;
            while (setNumber >= numberInDegree)
            {
                numberInDegree *= number;
                minDegree++;
            } 

            Console.WriteLine($"Число { setNumber }, { minDegree } степень и число { number } в найденной степени: { numberInDegree }.");
        }
    }
}
