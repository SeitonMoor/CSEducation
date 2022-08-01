using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperatorsAndLoops
{
    internal class SumOfNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int sumOfNumbers = 0;

            int number = random.Next(0, 100);

            for (int i = 1; i <= number; i++)
            {
                bool divisibleBy3 = (i % 3 == 0);
                bool divisibleBy5 = (i % 5 == 0);

                if (divisibleBy3 || divisibleBy5)
                    sumOfNumbers += i;
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}
