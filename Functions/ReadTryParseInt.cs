using System;

namespace Functions
{
    internal class ReadTryParseInt
    {
        void Function()
        {
            int inputNumber = GetNumber();

            Console.WriteLine($"Вы ввели число: {inputNumber}");
        }

        static int GetNumber()
        {
            bool beParsed = false;
            int inputNumber = 0;

            while (beParsed == false)
            {
                Console.Write("Введите число: ");
                beParsed = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            return inputNumber;
        }
    }
}
