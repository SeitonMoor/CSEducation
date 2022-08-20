using System;
using System.Collections.Generic;

namespace Collections
{
    internal class ExplanatoryDictionary
    {
        static void DictionaryOfWords()
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

            AddNewWord(dictionary, "Программирование", "написание инструкций, которые выполняет компьютер.");
            AddNewWord(dictionary, "Программирование", "сложная штука для избранных.");
            AddNewWord(dictionary, "Индекс", "число, представляющее позицию элемента в итерируемом объекте.");
            AddNewWord(dictionary, "Список", "контейнер, хранящий объекты в определенном порядке.");
            AddNewWord(dictionary, "Словарь", "встроенный контейнер для хранения объектов. Связывает один объект ключом, с другим объектом - значением.");
            AddNewWord(dictionary, "Цикл", "фрагмент кода, непрерывно выполняющий инструкции, пока удовлетворено определенное в коде условие.");

            return dictionary;
        }

        static void AddNewWord(Dictionary<string, string> dictionary, string word, string meaning)
        {
            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine($"Значение слова: {word} - уже имеется в нашем словаре");
            }
            else
            {
                dictionary.Add(word, meaning);
            }
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
