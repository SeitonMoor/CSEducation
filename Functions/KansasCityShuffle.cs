using System;

namespace Functions
{
    internal class KansasCityShuffle
    {
        void ShuffleApplication()
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];

            FillArrayValues(array, random);
            PrintArray(array, "Массив изначальный: ");

            ShuffleArrayValues(array, random);
            PrintArray(array, "Массив после перемешивания: ");
        }

        static void ShuffleArrayValues(int[] array, Random random)
        {
            int shuffleSteps = array.Length + 100;
            int minIndex = 0;
            int maxIndex = array.Length;
            int startIndex = minIndex;
            int newIndex = minIndex;

            for (int i = 0; i < shuffleSteps; i++)
            {
                while (startIndex == newIndex)
                {
                    newIndex = random.Next(minIndex, maxIndex);
                }

                array[startIndex] += array[newIndex];
                array[newIndex] = array[startIndex] - array[newIndex];
                array[startIndex] -= array[newIndex];

                startIndex = newIndex;
            }
        }

        static void FillArrayValues(int[] array, Random random)
        {
            int minValue = 0;
            int maxValue = 100;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
        }

        static void PrintArray(int[] array, string text)
        {
            Console.WriteLine(text);
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
