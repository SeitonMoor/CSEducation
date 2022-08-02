using System;

namespace ConditionalOperatorsAndLoops
{
    internal class ProtectedProgram
    {
        static void Main(string[] args)
        {
            string password = "t0pSecret";
            int tryCount = 3;
            int tryRemain = 3;
            string userInput;

            for (int i = 1; i <= tryCount; i++)
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (password == userInput)
                {
                    Console.WriteLine("\nДоступ к тайному сообщению получен!\n");
                    Console.WriteLine("Тайное сообщение ...");
                    i = tryCount;
                }
                else
                {
                    tryRemain--;
                    Console.WriteLine($"У вас осталось попыток: { tryRemain }");
                }
            }
        }
    }
}
