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
                    "\ndelete - удалить досье." +
                    "\nfind - поиск по фамилии." +
                    "\nexit - выход из программы." +
                    "\n\nВаше действие: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        AddProfile(ref fullNames, ref positions);
                        break;

                    case "printAll":
                        Print(fullNames, positions, separateSymbol);
                        break;

                    case "delete":
                        DeleteProfile(ref fullNames, ref positions);
                        break;

                    case "find":
                        FindProfile(fullNames, positions, separateSymbol);
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
            int resizeValue = 1;

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            fullNames = ResizeArray(fullNames, resizeValue, fullName);
            positions = ResizeArray(positions, resizeValue, position);
        }

        static void Print(string[] fullNames, string[] positions, char symbol, int index = -1)
        {
            int ordinalNumber;
            int firstOrdinal = 1;
            string separateSymbol = Convert.ToString(symbol);

            if (index >= 0)
            {
                ordinalNumber = firstOrdinal + index;
                Console.WriteLine(ordinalNumber + separateSymbol + fullNames[index] + separateSymbol + positions[index]);
            }
            else
            {
                for (int i = 0; i < fullNames.Length; i++)
                {
                    ordinalNumber = firstOrdinal + i;
                    Console.WriteLine(ordinalNumber + separateSymbol + fullNames[i] + separateSymbol + positions[i]);
                }
            }
        }

        static void DeleteProfile(ref string[] fullNames, ref string[] positions)
        {
            int resizeValue = -1;

            fullNames = ResizeArray(fullNames, resizeValue);
            positions = ResizeArray(positions, resizeValue);
        }

        static void FindProfile(string[] fullNames, string[] positions, char symbol)
        {
            int ordinalNumber;
            int firstOrdinal = 1;
            int surnameIndex = 0;
            string separateSymbol = Convert.ToString(symbol);

            Console.Write("Введите фамилию для поиска: ");
            string inputSurname = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string surname = fullNames[i].Split(' ')[surnameIndex];

                if (inputSurname == surname)
                {
                    ordinalNumber = firstOrdinal + i;
                    Console.WriteLine(ordinalNumber + separateSymbol + fullNames[i] + separateSymbol + positions[i]);
                }
            }
        }

        static string[] ResizeArray(string[] array, int resizeValue, string inputValue = null)
        {
            int newArrayLength = array.Length + resizeValue;
            int maxLength;
            if (resizeValue > 0) { maxLength = array.Length; }
            else { maxLength = newArrayLength; }

            string[] tempArray = new string[newArrayLength];
            for (int i = 0; i < maxLength; i++)
            {
                tempArray[i] = array[i];
            }

            if (inputValue != null)
            {
                int lastArrayIndex = newArrayLength - 1;
                tempArray[lastArrayIndex] = inputValue;
            }

            array = tempArray;
            return array;
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
