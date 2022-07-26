using System;

namespace CSEducation
{
    internal class CristalsShop
    {
        static void Main(string[] args)
        {
            int crystalPrice = 100;

            Console.Write("Какое у вас количество золота: ");
            int.TryParse(Console.ReadLine(), out int userGold);
            Console.WriteLine("Добро пожаловать в магазин кристаллов!");
            Console.WriteLine($"Какое количество кристалов вы хотите приобрести? Цена 1 кристалла: {crystalPrice}");
            Console.Write("Ваш ответ: ");
            int.TryParse(Console.ReadLine(), out int purchaseRequest);

            userGold -= (purchaseRequest * crystalPrice);
            int userCrystals = purchaseRequest;

            Console.WriteLine("Поздравляю с покупкой!");
            Console.WriteLine($"Теперь у вас: {userGold} золота и {userCrystals} кристаллов");
        }
    }
}
