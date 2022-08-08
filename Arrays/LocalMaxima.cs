using System;

namespace Arrays
{
    internal class LocalMaxima
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];
            int minValue = 1;
            int maxValue = 100;
            int checkDistance = 1;
            int startArrayIndex = 0;
            int lastArrayIndex = array.Length - checkDistance;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nВсе локальные максимумы:");
            if (array[startArrayIndex] > array[startArrayIndex + checkDistance])
                Console.Write(array[startArrayIndex] + " ");

            for (int i = 1; i < array.Length - checkDistance; i++)
                if (array[i - checkDistance] < array[i] && array[i + checkDistance] < array[i])
                        Console.Write(array[i] + " ");

            if (array[lastArrayIndex] > array[lastArrayIndex - checkDistance])
                    Console.Write(array[lastArrayIndex]);

            Console.WriteLine();
        }
    }
}
