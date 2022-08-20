using System;

namespace Collections
{
    internal class PersonnelAccountingAdvanced
    {
        static void Main(string[] args)
        {
            string[] fullNames = new string[0];
            string[] positions = new string[0];
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
                        PrepareToPrint(fullNames, positions);
                        break;

                    case "delete":
                        DeleteProfile(ref fullNames, ref positions);
                        break;

                    case "find":
                        FindProfile(fullNames, positions);
                        break;

                    case "exit":
                        isWorking = false;
                        WriteMessage("Завершение программы!");
                        break;

                    default:
                        WriteMessage("Данная команда неизвестна");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddProfile(ref string[] fullNames, ref string[] positions)
        {
            int resizeValue = 1;
            ConsoleColor addColor = ConsoleColor.Green;

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            fullNames = ResizeArray(fullNames, resizeValue, fullName);
            positions = ResizeArray(positions, resizeValue, position);

            WriteMessage($"{fullName} успешно добавлен.", addColor);
        }

        static void PrepareToPrint(string[] fullNames, string[] positions, int index = -1)
        {
            if (fullNames.Length == 0)
            {
                WriteMessage("Список досье пуст.");
            }
            else
            {
                string separateSymbol = "-";

                if (index >= 0)
                {
                    PrintProfile(fullNames, positions, separateSymbol, index);
                }
                else
                {
                    for (int i = 0; i < fullNames.Length; i++)
                    {
                        PrintProfile(fullNames, positions, separateSymbol, i);
                    }
                }
            }
        }

        static void DeleteProfile(ref string[] fullNames, ref string[] positions)
        {
            if (fullNames.Length == 0)
            {
                WriteMessage("Удаление невозможно! Список досье пуст.");
            }
            else
            {
                int resizeValue = -1;
                int lastIndex = fullNames.Length - 1;
                string fullName = fullNames[lastIndex];
                ConsoleColor deleteColor = ConsoleColor.DarkYellow;

                fullNames = ResizeArray(fullNames, resizeValue);
                positions = ResizeArray(positions, resizeValue);

                WriteMessage($"{fullName} успешно удален.", deleteColor);
            }
        }

        static void FindProfile(string[] fullNames, string[] positions)
        {
            int surnameIndex = 0;
            bool isFound = false;

            Console.Write("Введите фамилию для поиска: ");
            string inputSurname = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string surname = fullNames[i].Split(' ')[surnameIndex];

                if (inputSurname == surname)
                {
                    PrepareToPrint(fullNames, positions, i);
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                WriteMessage($"Досье с фамилией '{inputSurname}' не найдено.");
            }
        }

        static void PrintProfile(string[] fullNames, string[] positions, string separateSymbol, int index)
        {
            int firstOrdinal = 1;
            int ordinalNumber = firstOrdinal + index;
            Console.WriteLine(ordinalNumber + separateSymbol + fullNames[index] + separateSymbol + positions[index]);
        }

        static string[] ResizeArray(string[] array, int resizeValue, string inputValue = null)
        {
            int newArrayLength = array.Length + resizeValue;
            int maxLength;
            if (resizeValue > 0)
            {
                maxLength = array.Length;
            }
            else
            {
                maxLength = newArrayLength;
            }

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

        static void WriteMessage(string text, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}
