﻿using System;

namespace ConditionalOperatorsAndLoops
{
    internal class ConsoleMenu
    {
        void Menu()
        {
            string userInput;
            string userName = "";
            string userSurname = "";
            byte userAge = 0;
            string userJob = "";
            string password = "123456";
            bool isWorking = true;
            bool isAuthorized = false;

            while (isWorking)
            {
                if (isAuthorized)
                {
                    Console.Write("Доступные команды: fillProfile | printProfile | changePassword | logout | exit" +
                        "\nВведите команду: ");
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.Write("Доступные команды: login | exit" +
                        "\nВведите команду: ");
                    userInput = Console.ReadLine();
                }

                switch (userInput)
                {
                    case "login":
                        if (isAuthorized)
                        {
                            Console.WriteLine("\nНеизвестная команда\n");
                        }
                        else
                        {
                            Console.WriteLine("\nАвторизация.");
                            int tryCount = 3;

                            for (int i = 1; i <= tryCount; i++)
                            {
                                Console.Write("Введите пароль: ");
                                userInput = Console.ReadLine();

                                if (password == userInput)
                                {
                                    Console.WriteLine("\nДобро пожаловать в приложение!\n");
                                    isAuthorized = true;
                                    isWorking = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"У вас осталось попыток: {tryCount - i}");
                                    isWorking = false;
                                }
                            }
                        }
                        break;

                    case "fillProfile":
                        if (isAuthorized)
                        {
                            Console.Write("\nЗаполнение профиля." +
                            "\nВведите ваше имя: ");
                            userName = Console.ReadLine();

                            Console.Write("Введите вашу фамилию: ");
                            userSurname = Console.ReadLine();

                            Console.Write("Введите ваш возраст: ");
                            userAge = Convert.ToByte(Console.ReadLine());

                            Console.Write("Введите вашу должность на работе: ");
                            userJob = Console.ReadLine();

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("\nНеизвестная команда\n");
                        }
                        break;

                    case "printProfile":
                        if (isAuthorized)
                        {
                            Console.WriteLine($"\nИнформация о профиле." +
                            $"\n{userName} {userSurname}" +
                            $"\nВозраст: {userAge}" +
                            $"\nДолжность: {userJob}\n");
                        }
                        else
                        {
                            Console.WriteLine("\nНеизвестная команда\n");
                        }
                        break;

                    case "changePassword":
                        if (isAuthorized)
                        {
                            Console.WriteLine("\nВы активировали смену пароля.");

                            string userPassword = "";
                            bool haveMistake = false;

                            while (userInput != userPassword)
                            {
                                if (haveMistake)
                                    Console.WriteLine("Пароли не совпадают, попробуйте еще раз:");
                                Console.Write("Введите новый пароль: ");
                                userInput = Console.ReadLine();

                                Console.Write("Введите новый пароль еще раз: ");
                                userPassword = Console.ReadLine();

                                haveMistake = true;
                            }

                            password = userPassword;

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("\nНеизвестная команда\n");
                        }
                        break;

                    case "logout":
                        if (isAuthorized)
                        {
                            Console.WriteLine("\nВы вышли из профиля.\n");
                            isAuthorized = false;
                        }
                        else
                        {
                            Console.WriteLine("\nНеизвестная команда\n");
                        }
                        break;

                    case "exit":
                        Console.WriteLine("\nВы вышли из приложения. Всего доброго!");
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("\nНеизвестная команда\n");
                        break;
                }
            }
        }
    }
}
