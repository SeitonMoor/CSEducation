﻿using System;

namespace ConditionalOperatorsAndLoops
{
    internal class Sequence
    {
        static void Main(string[] args)
        {
            int firstValue = 5;
            int lastValue = 96;
            int cycleStep = 7;

            for (int i = firstValue; i <= lastValue; i += cycleStep)
            {
                Console.Write(i + " ");
            }
        }
    }
}
