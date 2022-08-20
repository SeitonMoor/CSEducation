using System;
using System.Collections.Generic;

namespace Collections
{
    internal class PersonnelAccountingAdvanced
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> employeesProfile = new Dictionary<string, string>();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Кадровый учет\n");
                Console.Write("Меню команд:\n" +
                    "\nadd - добавить досье." +
                    "\nprintAll - вывести все досье." +
                    "\ndelete - удалить досье." +
                    "\nexit - выход из программы." +
                    "\n\nВаше действие: ");

                switch (Console.ReadLine())
                {
                    case "add":
                        AddProfile(employeesProfile);
                        break;

                    case "printAll":
                        PrepareToPrint(employeesProfile);
                        break;

                    case "delete":
                        DeleteProfile(employeesProfile);
                        break;

                    case "exit":
                        EndProgram(ref isWorking);
                        break;

                    default:
                        WriteMessage("Данная команда неизвестна");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddProfile(Dictionary<string, string> employeesProfile)
        {
            ConsoleColor addColor = ConsoleColor.Green;

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            if (employeesProfile.ContainsKey(fullName))
            {
                WriteMessage($"Досье сотрудника: {fullName} - уже имеется в нашей базе");
            }
            else
            {
                employeesProfile.Add(fullName, position);

                WriteMessage($"{fullName} успешно добавлен.", addColor);
            }
        }

        static void PrepareToPrint(Dictionary<string, string> employeesProfile)
        {
            if (employeesProfile.Count == 0)
            {
                WriteMessage("Список досье пуст.");
            }
            else
            {
                string separateSymbol = "-";
                int index = 0;
                foreach (var profile in employeesProfile)
                {
                    PrintProfile(profile.Key, profile.Value, separateSymbol, index);
                    index++;
                }
            }
        }

        static void DeleteProfile(Dictionary<string, string> employeesProfile)
        {
            if (employeesProfile.Count == 0)
            {
                WriteMessage("Удаление невозможно! Список досье пуст.");
            }
            else
            {
                bool isDeleted = false;

                while (isDeleted == false)
                {
                    Console.Write("Введите ФИО: ");
                    string fullName = Console.ReadLine();
                    ConsoleColor deleteColor = ConsoleColor.DarkYellow;

                    if (employeesProfile.ContainsKey(fullName))
                    {
                        employeesProfile.Remove(fullName);

                        WriteMessage($"{fullName} успешно удален.", deleteColor);
                        isDeleted = true;
                    }
                    else
                    {
                        WriteMessage($"{fullName} такого досье нет.");
                    }
                }
            }
        }

        static void PrintProfile(string fullName, string position, string separateSymbol, int index)
        {
            int firstOrdinal = 1;
            int ordinalNumber = firstOrdinal + index;
            Console.WriteLine(ordinalNumber + separateSymbol + fullName + separateSymbol + position);
        }

        static void EndProgram(ref bool isWorking)
        {
            isWorking = false;
            WriteMessage("Завершение программы!");
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
