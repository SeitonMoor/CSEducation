using System;
using System.Collections.Generic;

namespace Collections
{
    internal class DynamicArrayAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isWorking = true;

            while (isWorking)
            {
                SelectCommand(ref isWorking, numbers);

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void SelectCommand(ref bool isWorking, List<int> numbers)
        {
            Console.Write("Перечень команд:" +
                    "\nsum - вывод суммы всех введенных чисел." +
                    "\nexit - выход из программы" +
                    "\nЛибо введите число для добавления." +
                    "\nВаше действие: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "sum":
                    GetAmount(numbers);
                    break;

                case "exit":
                    isWorking = false;
                    Console.WriteLine("\nВыход из программы...");
                    break;

                default:
                    if (IsNumber(userInput, out int inputNumber))
                    {
                        AddNumber(numbers, inputNumber);
                    }
                    else
                    {
                        Console.WriteLine($"\n{userInput} - неизвестная команда и не является числом.");
                    }
                    break;
            }
        }

        static void GetAmount(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"\nСумма введеных чисел: {sum}");
        }

        static bool IsNumber(string userInput, out int inputNumber)
        {
            if (int.TryParse(userInput, out inputNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void AddNumber(List<int> numbers, int inputNumber)
        {
            numbers.Add(inputNumber);

            Console.WriteLine($"\nЧисло {inputNumber} было добавлено.");
        }
    }
}
