using System;

namespace ConditionalOperatorsAndLoops
{
    internal class DegreeOfTwo
    {
        void DegreesSearcher()
        {
            Random random = new Random();

            uint number = 2;
            int minDegree = 0;
            int randomNumber = random.Next();

            uint numberInDegree = number;
            while (randomNumber >= numberInDegree)
            {
                numberInDegree *= number;
                minDegree++;
            } 

            Console.WriteLine($"Число { randomNumber }, { minDegree } степень и число { number } в найденной степени: { numberInDegree }.");
        }
    }
}
