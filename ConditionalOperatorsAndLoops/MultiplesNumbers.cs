using System;

namespace ConditionalOperatorsAndLoops
{
    internal class MultiplesNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minRandomValue = 1;
            int maxRandomValue = 28;
            int maxNaturalNumber = 999;
            int count = 0;
            int setNumber = random.Next(minRandomValue, maxRandomValue);

            for (int i = 0; i <= maxNaturalNumber; i += setNumber)
            {
                if (i >= 100) count++;
            }

            Console.WriteLine(count);
        }
    }
}
