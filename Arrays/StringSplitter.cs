using System;

namespace Arrays
{
    internal class StringSplitter
    {
        static void Main(string[] args)
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
