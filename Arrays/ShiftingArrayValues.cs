using System;

namespace Arrays
{
    internal class ShiftingArrayValues
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Задайте значение для сдвига массива влево: ");
            int shiftingNumber = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];
            int minValue = 1;
            int maxValue = 100;
            int stepDistance = 1;
            int startArrayIndex = 0;
            int lastArrayIndex = array.Length - 1;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < shiftingNumber; i++)
            {
                int firstNumber = array[startArrayIndex];
                for (int j = 0; j < lastArrayIndex; j++)
                {
                    array[j] = array[j + stepDistance];
                }

                array[lastArrayIndex] = firstNumber;
            }

            Console.WriteLine($"\nМассив после сдвига влево {shiftingNumber} раз:");
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
