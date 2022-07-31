using System;

namespace ConditionalOperatorsAndLoops
{
    internal class MasteringСycles
    {
        void Mastering()
        {
            Console.Write("Укажите сообщение для программы: ");
            var userInput = Console.ReadLine();

            Console.Write("Какое количество раз вывести сообщение: ");
            int repeatCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repeatCount; i++)
            {
                Console.WriteLine(userInput);
            }
        }
    }
}
