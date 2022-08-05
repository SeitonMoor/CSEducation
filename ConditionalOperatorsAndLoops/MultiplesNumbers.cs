using System;

namespace ConditionalOperatorsAndLoops
{
    internal class MultiplesNumbers
    {
        void MultiplesSearcher()
        {
            Random random = new Random();

            int minValue = 1;
            int maxValue = 28;
            int maxNaturalNumber = 999;
            int count = 0;
            int randomNumber = random.Next(minValue, maxValue);

            for (int i = 0; i <= maxNaturalNumber; i += randomNumber)
            {
                if (i >= 100) count++;
            }

            Console.WriteLine(count);
        }
    }
}
