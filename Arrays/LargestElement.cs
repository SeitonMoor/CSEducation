using System;

namespace Arrays
{
    internal class LargestElement
    {
        void FindLargest()
        {
            Random random = new Random();

            int setNumber = 0;
            int maxFoundElement = 0;
            int minTwoDigitsNumber = 10;
            int minValue = 1;
            int maxValue = 100;

            Console.Write("Задайте количество строк: ");
            int inputRows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Задайте количество столбцов: ");
            int inputColumns = Convert.ToInt32(Console.ReadLine());

            int[,] array = new int[inputRows, inputColumns];

            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minValue, maxValue);

                    if (maxFoundElement < array[i, j])
                        maxFoundElement = array[i, j];

                    if (array[i, j] >= minTwoDigitsNumber)
                        Console.Write(array[i, j] + " | ");
                    else
                        Console.Write(array[i, j] + "  | ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nНаибольший элемент матрицы: {maxFoundElement}\n");

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (maxFoundElement == array[i, j])
                        array[i, j] = setNumber;

                    if (array[i, j] >= minTwoDigitsNumber)
                        Console.Write(array[i, j] + " | ");
                    else
                        Console.Write(array[i, j] + "  | ");
                }

                Console.WriteLine();
            }
        }
    }
}
