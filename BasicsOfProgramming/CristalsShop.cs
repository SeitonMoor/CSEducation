﻿using System;

namespace CSEducation
{
    internal class CristalsShop
    {
        public void BuyCristals()
        {
            int crystalPrice = 100;

            Console.Write("Какое у вас количество золота: ");
            int userGold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Добро пожаловать в магазин кристаллов!");
            Console.WriteLine($"Какое количество кристалов вы хотите приобрести? Цена 1 кристалла: {crystalPrice}");

            Console.Write("Ваш ответ: ");
            int purchaseRequest = Convert.ToInt32(Console.ReadLine());

            userGold -= (purchaseRequest * crystalPrice);
            int userCrystals = purchaseRequest;

            Console.WriteLine("Поздравляю с покупкой!");
            Console.WriteLine($"Теперь у вас: {userGold} золота и {userCrystals} кристаллов");
        }
    }
}
