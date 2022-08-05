using System;

namespace ConditionalOperatorsAndLoops
{
    internal class SumOfNumbers
    {
        void SumCalculating()
        {
            Random random = new Random();

            int sumOfNumbers = 0;
            int divisibleNumber1 = 3;
            int divisibleNumber2 = 5;
            int minValue = 0;
            int maxValue = 100;

            int number = random.Next(minValue, maxValue);

            for (int i = 1; i <= number; i++)
            {
                bool divisibleByNumber1 = (i % divisibleNumber1 == 0);
                bool divisibleByNumber2 = (i % divisibleNumber2 == 0);

                if (divisibleByNumber1 || divisibleByNumber2)
                    sumOfNumbers += i;
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}
