using System;

namespace ConditionalOperatorsAndLoops
{
    internal class BracketsExpression
    {
        static void Main(string[] args)
        {
            int maxBracketsDepth = 0;
            int foundDepth = 0;
            int openedBrackets = 0;
            bool isCorrect = true;
            bool haveClosedBracket = false;

            Console.Write("Введите скобочное выражение: ");
            string inputBrackets = Console.ReadLine();

            foreach (var symbol in inputBrackets)
            {
                if (symbol == '(')
                {
                    if (haveClosedBracket && foundDepth > 0) foundDepth--;
                    openedBrackets++;
                }
                else if (symbol == ')')
                {
                    foundDepth++;
                    openedBrackets--;
                    haveClosedBracket = true;
                }
                
                if (openedBrackets < 0) isCorrect = false;

                if (openedBrackets == 0 && maxBracketsDepth < foundDepth)
                {
                    maxBracketsDepth = foundDepth;
                    foundDepth = 0;
                }
            }

            if (openedBrackets == 0 && isCorrect)
            {
                Console.WriteLine($"“{ inputBrackets }” - строка корректная и максимум глубины равняется { maxBracketsDepth }.");
            }
            else
            {
                Console.WriteLine($"“{ inputBrackets }” - строка некорректная.");
            }
        }
    }
}
