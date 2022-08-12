using System;

namespace Functions
{
    internal class PersonnelAccounting
    {
        static void Main(string[] args)
        {
            string errorMessage = "Данная команда неизвестна";
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            char separateSymbol = '-';
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Кадровый учет\n");
                Console.Write("Меню команд:\n" +
                    "\nadd - добавить досье." +
                    "\nprintAll - вывести все досье." +
                    "\ndeleate - удалить досье." +
                    "\nfind - поиск по фамилии." +
                    "\nexit - выход из программы." +
                    "\n\nВаше действие: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        AddProfile(ref fullNames, ref positions);
                        break;

                    case "printAll":
                        PrintAll(fullNames, positions, separateSymbol);
                        break;

                    case "deleate":
                        DeleteProfile(ref fullNames, ref positions);
                        break;

                    case "find":
                        FindProfile(fullNames, positions);
                        break;

                    case "exit":
                        isWorking = false;
                        break;

                    default:
                        WriteError(errorMessage);
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddProfile(ref string[] fullNames, ref string[] positions)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            fullNames = AddToArray(fullNames, fullName);
            positions = AddToArray(positions, position);
        }

        static string[] AddToArray(string[] array, string inputValue)
        {
            int newArrayLength = array.Length + 1;
            int lastArrayIndex = newArrayLength - 1;

            string[] tempArray = new string[newArrayLength];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[lastArrayIndex] = inputValue;
            array = tempArray;
            return array;
        }

        static void PrintAll(string[] fullNames, string[] positions, char symbol)
        {
            int ordinalNumber;
            int firstOrderNumber = 1;
            string separateSymbol = Convert.ToString(symbol);
            for (int i = 0; i < fullNames.Length; i++)
            {
                ordinalNumber = firstOrderNumber + i;
                Console.WriteLine(ordinalNumber + separateSymbol + fullNames[i] + separateSymbol + positions[i]);
            }
        }

        static void DeleteProfile(ref string[] fullNames, ref string[] positions)
        {

        }

        static void FindProfile(string[] fullNames, string[] positions)
        {

        }

        static void WriteError(string text, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}
