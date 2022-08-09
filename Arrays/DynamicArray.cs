using System;

namespace Arrays
{
    internal class DynamicArray
    {
        static void Main(string[] args)
        {
            int[] numbersArray = new int[0];
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write("Перечень команд:" +
                    "\nsum - вывод суммы всех введенных чисел." +
                    "\nexit - выход из программы" +
                    "\nЛибо введите число для добавления в массив." +
                    "\nВаше действие: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        int sum = 0;

                        for (int i = 0; i < numbersArray.Length; i++)
                            sum += numbersArray[i];

                        Console.WriteLine($"\nСумма введеных чисел: {sum}\n");
                        break;

                    case "exit":
                        isWorking = false;
                        break;

                    default:
                        int inputNumber = Convert.ToInt32(userInput);
                        int newArrayLength = numbersArray.Length + 1;
                        int lastArrayIndex = newArrayLength - 1;

                        int[] tempNumbersArray = new int[newArrayLength];
                        for (int i = 0; i < numbersArray.Length; i++)
                        {
                            tempNumbersArray[i] = numbersArray[i];
                        }

                        tempNumbersArray[lastArrayIndex] = inputNumber;

                        numbersArray = tempNumbersArray;
                        Console.WriteLine($"\nЧисло {inputNumber} было добавлено в массив.\n");
                        break;
                }
            }
        }
    }
}
