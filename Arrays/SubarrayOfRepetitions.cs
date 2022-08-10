using System;

namespace Arrays
{
    internal class SubarrayOfRepetitions
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];
            int foundNumber = 0;
            int foundQuantity = 0;
            int minValue = 1;
            int maxValue = 100;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            foreach (int checkNumber in array)
            {
                int count = 0;
                foreach (int number in array)
                {
                    if (number == checkNumber)
                    {
                        count++;
                    }
                }

                if (foundQuantity < count)
                {
                    foundNumber = checkNumber;
                    foundQuantity = count;
                }
            }

            Console.WriteLine($"\nЧисло {foundNumber} повторяется чаще всего, а именно {foundQuantity} раз подряд");
        }
    }
}
