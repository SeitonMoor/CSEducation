using System;

namespace Arrays
{
    internal class SortingNumbers
    {
        void BubbleSort()
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];
            int minValue = 1;
            int maxValue = 100;
            int checkDistance = 1;
            bool isChanged = true;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            while (isChanged)
            {
                isChanged = false;

                for (int i = 0; i < array.Length - checkDistance; i++)
                {
                    if (array[i] > array[i + checkDistance])
                    {
                        array[i] += array[i + checkDistance];
                        array[i + checkDistance] = array[i] - array[i + checkDistance];
                        array[i] -= array[i + checkDistance];
                        isChanged = true;
                    }
                }
            }

            Console.WriteLine("\nОтсортированный массив:");
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
