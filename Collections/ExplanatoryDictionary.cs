using System;
using System.Collections.Generic;

namespace Collections
{
    internal class ExplanatoryDictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = InitializeDictionary();

            bool isWorking = true;

            while (isWorking)
            {
                string inputWord = SelectWord();

                FindWordMeaning(ref isWorking, inputWord, dictionary);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static Dictionary<string, string> InitializeDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Программирование", "написание инструкций, которые выполняет компьютер.");
            dictionary.Add("Индекс", "число, представляющее позицию элемента в итерируемом объекте.");
            dictionary.Add("Список", "контейнер, хранящий объекты в определенном порядке.");
            dictionary.Add("Словарь", "встроенный контейнер для хранения объектов. Связывает один объект ключом, с другим объектом - значением.");
            dictionary.Add("Цикл", "фрагмент кода, непрерывно выполняющий инструкции, пока удовлетворено определенное в коде условие.");

            return dictionary;
        }

        static string SelectWord()
        {
            Console.WriteLine("Толковый словарь\n");
            Console.Write("Введите слово, значение которого хотите узнать: ");
            string word = Console.ReadLine();

            return word;
        }

        static void FindWordMeaning(ref bool isWorking, string word, Dictionary<string, string> dictionary)
        {
            if (dictionary.ContainsKey(word))
            {
                WriteMessage($"Значение {word} - {dictionary[word]}", ConsoleColor.Green);
                isWorking = false;
            }
            else
            {
                WriteMessage($"В нашем словаре нет толкования слова: {word}");
            }
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
