using System;

namespace ConditionalOperatorsAndLoops
{
    internal class NameOutput
    {
        static void Main(string[] args)
        {
            int borderWidth = 1;
            int topLineIndex = 0;
            int nameLineIndex = 1;
            int bottomLineIndex = 2;

            Console.Write("Введите имя: ");
            string userName = Console.ReadLine();

            Console.Write("Введите символ для рамки: ");
            char userChar = Convert.ToChar(Console.ReadLine());

            Console.Clear();

            for (int i = 0 - borderWidth; i < userName.Length + borderWidth; i++)
            {
                Console.SetCursorPosition(i + borderWidth, topLineIndex);
                Console.WriteLine(userChar);

                Console.SetCursorPosition(i + borderWidth, nameLineIndex);
                if (i >= 0 && i < userName.Length)
                {
                    Console.WriteLine(userName[i]);
                }
                else
                {
                    Console.WriteLine(userChar);
                }

                Console.SetCursorPosition(i + borderWidth, bottomLineIndex);
                Console.WriteLine(userChar);
            }
        }
    }
}
