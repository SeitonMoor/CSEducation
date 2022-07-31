using System;

namespace ConditionalOperatorsAndLoops
{
    internal class ExitControl
    {
        static void Main(string[] args)
        {
            string userInput;
            bool canExit = false;
            string exitCommand = "exit";

            while (canExit == false)
            {
                Console.WriteLine("Какое действие хотите совершить: create | update | delete | exit");
                userInput = Console.ReadLine();

                if (userInput == exitCommand)
                {
                    canExit = true;
                }
                else
                {
                    Console.WriteLine("Выполнение программы...");
                }
            }
        }
    }
}
