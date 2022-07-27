using System;

namespace CSEducation
{
    internal class CristalsShop
    {
        static void Main(string[] args)
        {
            int userGold;
            int userCrystals;
            int purchaseRequest;
            bool isValidInput;
            int crystalPrice = 100;

            Console.Write("Какое у вас количество золота: ");
            isValidInput = int.TryParse(Console.ReadLine(), out userGold);

            if (!isValidInput)
            {
                Console.WriteLine("Необходимо ввести количество золота - числом.");
            }
            else
            {
                Console.WriteLine("Добро пожаловать в магазин кристаллов!");
                Console.WriteLine($"Какое количество кристалов вы хотите приобрести? Цена 1 кристалла: {crystalPrice}");

                Console.Write("Ваш ответ: ");
                isValidInput = int.TryParse(Console.ReadLine(), out purchaseRequest);

                if (!isValidInput)
                {
                    Console.WriteLine("Необходимо ввести количество кристаллов - числом.");
                }
                else
                {
                    userGold -= (purchaseRequest * crystalPrice);
                    userCrystals = purchaseRequest;

                    Console.WriteLine("Поздравляю с покупкой!");
                    Console.WriteLine($"Теперь у вас: {userGold} золота и {userCrystals} кристаллов");
                }
            }
        }
    }
}
