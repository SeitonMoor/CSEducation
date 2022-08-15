using System;

namespace Functions
{
    internal class ReadTryParseInt
    {
        static void Main(string[] args)
        {
            GetNumber(out int inputNumber);

            Console.WriteLine($"Вы ввели число: {inputNumber}");
        }

        static int GetNumber(out int inputNumber)
        {
            bool beParsed = false;
            inputNumber = 0;

            while (beParsed == false)
            {
                Console.Write("Введите число: ");
                beParsed = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            return inputNumber;
        }
    }
}
