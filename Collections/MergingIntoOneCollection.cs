using System;
using System.Collections.Generic;

namespace Collections
{
    internal class MergingIntoOneCollection
    {
        static void Main(string[] args)
        {
            string[] array1 = { "1", "2", "1" };
            string[] array2 = { "1", "2", "3" };

            List<string> list = new List<string>();
            AddToList(array1, list);
            AddToList(array2, list);

            PrintList(list);
        }

        static void AddToList(string[] array, List<string> list)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (list.Contains(array[i]) == false)
                {
                    list.Add(array[i]);
                }
            }
        }

        static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
