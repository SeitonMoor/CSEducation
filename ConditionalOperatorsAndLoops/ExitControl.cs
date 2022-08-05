using System;

namespace ConditionalOperatorsAndLoops
{
    internal class ExitControl
    {
        void Control()
        {
            string userInput;
            bool isWorking = true;
            string exitCommand = "exit";

            while (isWorking)
            {
                Console.WriteLine("Какое действие хотите совершить: create | update | delete | exit");
                userInput = Console.ReadLine();

                if (userInput == exitCommand)
                {
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Выполнение программы...");
                }
            }
        }
    }
}
