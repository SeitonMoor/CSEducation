﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEducation
{
    internal class SwappingValues
    {
        public void Swapping()
        {
            int userAge = 1922;
            int userBirthYear = 100;
            string userName = "Петров";
            string userSurname = "Ваня";

            Console.WriteLine($"{userName} {userSurname} здравствуйте, " +
                $"ваш возраст: {userAge}, ваш год рождения: {userBirthYear}.");

            userAge += userBirthYear;
            userBirthYear = userAge - userBirthYear;
            userAge -= userBirthYear;

            userName += userSurname;
            userSurname = userName.Substring(0, userName.Length - userSurname.Length);
            userName = userName.Substring(userSurname.Length);

            Console.WriteLine($"{userName} {userSurname} здравствуйте, " +
                $"ваш возраст: {userAge}, ваш год рождения: {userBirthYear}.");
        }
    }
}
