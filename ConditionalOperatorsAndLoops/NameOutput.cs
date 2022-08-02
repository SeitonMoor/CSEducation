using System;

namespace ConditionalOperatorsAndLoops
{
    internal class NameOutput
    {
        static void Main(string[] args)
        {
            int borderWidth = 1;
            string borderLine = "";
            string nameLine = "";

            Console.Write("Введите имя: ");
            string userName = Console.ReadLine();

            Console.Write("Введите символ для рамки: ");
            char userChar = Convert.ToChar(Console.ReadLine());

            nameLine = userChar + userName + userChar;

            for (int i = 0; i <= userName.Length + borderWidth; i++)
            {
                borderLine += userChar;
            }

            Console.WriteLine(borderLine);
            Console.WriteLine(nameLine);
            Console.WriteLine(borderLine);
        }
    }
}
