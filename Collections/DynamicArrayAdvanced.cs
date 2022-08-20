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
                    PrintAmount(numbers);
                    break;

                case "exit":
                    EndProgram(ref isWorking);
                    break;

                default:
                    AddNumber(numbers, userInput);
                    break;
            }
        }

        static void PrintAmount(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"\nСумма введеных чисел: {sum}");
        }

        static void AddNumber(List<int> numbers, string userInput)
        {
            if (int.TryParse(userInput, out int inputNumber))
            {
                numbers.Add(inputNumber);

                Console.WriteLine($"\nЧисло {inputNumber} было добавлено.");
            }
            else
            {
                Console.WriteLine($"\n{userInput} - неизвестная команда и не является числом.");
            }
        }

        static void EndProgram(ref bool isWorking)
        {
            isWorking = false;
            Console.WriteLine("\nВыход из программы...");
        }
    }
}
