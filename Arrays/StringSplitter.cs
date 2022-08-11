using System;

namespace Arrays
{
    internal class StringSplitter
    {
        void Splitter()
        {
            Console.Write("Напишите текст: ");
            string inputText = Console.ReadLine();

            string[] wordsArray = inputText.Split(' ');

            foreach (string word in wordsArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}
