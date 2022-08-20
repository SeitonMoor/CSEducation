using System;
using System.Collections.Generic;

namespace Collections
{
    internal class QueueAtTheStore
    {
        static void Main(string[] args)
        {
            Queue<int> purchasesAmount = InitializeQueue();

            int amount = 0;

            while (purchasesAmount.Count > 0)
            {
                MakeSale(ref amount, purchasesAmount);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static Queue<int> InitializeQueue()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(259);
            queue.Enqueue(1923);
            queue.Enqueue(43);
            queue.Enqueue(4200);
            queue.Enqueue(10);
            queue.Enqueue(450);
            queue.Enqueue(338);
            queue.Enqueue(290);

            return queue;
        }

        static void MakeSale(ref int amount, Queue<int> purchasesAmount)
        {
            int purchase = purchasesAmount.Dequeue();
            amount += purchase;

            Console.WriteLine($"Совершена покупка на {purchase}, баланс на счёте магазина составляет: {amount}");
        }
    }
}
