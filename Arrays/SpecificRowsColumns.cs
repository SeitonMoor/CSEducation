using System;

namespace Arrays
{
    internal class SpecificRowsColumns
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int specifiedRow = 1;
            int specifiedColumn = 0;
            int minValue = 1;
            int maxValue = 10;
            int sumOfRowValues = 0;
            int productOfColumnValues = 1;

            Console.Write("Задайте количество строк: ");
            int inputRows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Задайте количество столбцов: ");
            int inputColumns = Convert.ToInt32(Console.ReadLine());

            int[,] array = new int[inputRows, inputColumns];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minValue, maxValue);
                    Console.Write(array[i, j] + " | ");
                }

                Console.WriteLine();
            }

            for (int j = 0; j < array.GetLength(1); j++)
                sumOfRowValues += array[specifiedRow, j];

            for (int i = 0; i < array.GetLength(0); i++)
                productOfColumnValues *= array[i, specifiedColumn];

            Console.WriteLine($"Сумма значений {specifiedRow} строки: {sumOfRowValues}");
            Console.WriteLine($"Произведение значений {specifiedColumn} столбца: {productOfColumnValues}");
        }
    }
}
