﻿using System;

namespace ConditionalOperatorsAndLoops
{
    internal class CurrencyConverter
    {
        static void Main(string[] args)
        {
            double rubToUsd = 0.016, rubToJpy = 2.13, 
                usdToRub = 62, usdToJpy = 131.97,
                jpyToRub = 0.47, jpyToUsd = 0.0076;
            double rub, usd, jpy;
            double currencyCount;
            string userInput;
            bool canExit = false;

            Console.WriteLine("Добро пожаловать в обменник валют. У нас вы можете обменять свои рубли, доллары и иены.");

            Console.Write("Введите баланс рублей: ");
            rub = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите баланс долларов: ");
            usd = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите баланс иен: ");
            jpy = Convert.ToDouble(Console.ReadLine());

            while (canExit == false)
            {
                Console.WriteLine($"\nВаш баланс {rub} рублей | {usd} долларов | {jpy} иен");

                Console.Write("\n1 - обменять рубли на доллары" +
                    "\n2 - обменять рубли на иены" +
                    "\n3 - обменять доллары на рубли" +
                    "\n4 - обменять доллары на иены" +
                    "\n5 - обменять иены на рубли" +
                    "\n6 - обменять иены на доллары" +
                    "\nexit - закончить операции по обмену" +
                    "\nПерейти к операции: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\nОбмен рублей на доллары");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            usd += currencyCount * rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество рублей.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nОбмен рублей на иены");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            jpy += currencyCount * rubToJpy;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество рублей.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nОбмен долларов на рубли");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество долларов.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nОбмен долларов на иены");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            jpy += currencyCount * usdToJpy;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество долларов.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nОбмен иенов на рубли");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            rub += currencyCount * jpyToRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество иен.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nОбмен иенов на доллары");
                        Console.Write("Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToDouble(Console.ReadLine());

                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            usd += currencyCount * jpyToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое количество иен.");
                        }
                        break;

                    case "exit":
                        canExit = true;
                        break;
                }
            }
        }
    }
}