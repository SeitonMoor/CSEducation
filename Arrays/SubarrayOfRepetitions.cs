using System;

namespace Arrays
{
    internal class SubarrayOfRepetitions
    {
        void SearchRepetitions()
        {
            Random random = new Random();

            Console.Write("Задайте размер одномерного массива: ");
            int inputSize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[inputSize];
            int foundNumber = 0;
            int foundQuantity = 0;
            int minValue = 1;
            int maxValue = 10;

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
            }

            foreach (int checkNumber in array)
            {
                int count = 0;
                bool isInSequence = false;
                foreach (int number in array)
                {
                    if (isInSequence && number == checkNumber)
                    {
                        count++;
                    }
                    else if (isInSequence)
                    {
                        isInSequence = false;
                        count = 0;
                    }
                    else if (number == checkNumber)
                    {
                        isInSequence = true;
                        count++;
                    }

                    if (foundQuantity < count)
                    {
                        foundNumber = checkNumber;
                        foundQuantity = count;
                    }
                }
            }

            Console.WriteLine($"\nЧисло {foundNumber} повторяется {foundQuantity} раз подряд");
        }*/
    }
}
