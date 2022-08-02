using System;

namespace ConditionalOperatorsAndLoops
{
    internal class MultiplesNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRandomValue = 28;
            int minNaturalNumber = 100;
            int maxNaturalNumber = 999;
            int count = 0;
            int n = random.Next(maxRandomValue);

            for (int i = minNaturalNumber; i <= maxNaturalNumber; i++)
            {
                int multipleNumber = i;
                while (multipleNumber > 0)
                {
                    multipleNumber -= n;
                }

                if (multipleNumber == 0)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
