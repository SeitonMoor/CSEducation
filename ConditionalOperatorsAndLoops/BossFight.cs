using System;

namespace ConditionalOperatorsAndLoops
{
    internal class BossFight
    {
        static void Main(string[] args)
        {
            int health = 100;
            int maxHealth = 100;
            int damage = 80;
            int dealDamage = 0;
            int extraDamage = 100;
            int herbalHeal = 25;
            byte damageReduction = 2;
            byte damageIncrease = 3;
            string userInput;
            bool feelWeakSpot = false;
            bool isDisappeared = false;

            int bossHealth = 1000;
            int bossDamage = 10;
            int bossDealDamage = 0;
            byte bossAttackCounter = 0;
            byte bossComboSkill = 3;
            byte bossIncreaseDamage = 6;
            byte bossWaitingCounter = 0;
            byte bossLethalSkill = 2;

            Console.WriteLine("Вы – следопыт и у вас в арсенале есть несколько умений, которые вы можете использовать против Босса." +
                "\nВы должны уничтожить очередное порождение тьмы и только после этого будет вам покой.");

            while (health > 0 && bossHealth > 0)
            {
                Console.WriteLine($"\nВаше здоровье: { health } | Здоровье босса: { bossHealth } ");

                Console.Write("\nПеречень умений:" +
                    "\n1 - СТРЕЛЬБА - Атакуете дальнобойным оружием." +
                    "\n2 - СРАЖЕНИЕ ДВУМЯ МЕЧАМИ - Атакуете двумя оружиями и наносите дополнительный урон при второй атаке." +
                    "\n3 - ОХОТНИЧЬИ ЧУВСТВА - Вы получаете способность оценить существо и определить, как лучше всего навредить ему." +
                    "\n4 - ИСЧЕЗНОВЕНИЕ - Вы не можете быть выслежены немагическими способом и пользуясь этим временем находите травы, чтобы залечить раны." +
                    "\nВы совершаете умение под номером: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        if (feelWeakSpot)
                        {
                            Console.WriteLine("\nЗная слабу точку босса, вы совершаете точный выстрел.");
                            dealDamage = damage * damageIncrease;
                        }
                        else
                        {
                            Console.WriteLine("\nДержась на растоянии вы выстреливаете по боссу.");
                            dealDamage = damage;
                        }

                        bossHealth -= dealDamage;
                        Console.WriteLine($"Вам удалось нанести: { dealDamage } урона");
                        break;

                    case "2":
                        if (feelWeakSpot)
                        {
                            Console.WriteLine("\nЗная слабу точку босса, у вас не удается добраться до нее используя мечи.");
                            dealDamage -= dealDamage;
                        }
                        else
                        {
                            Console.WriteLine("\nДостав два меча из-за спины и совершая быстрый кувырок вперед, наносите две атаки.");
                            dealDamage = (damage / damageReduction) + ((damage + extraDamage) / damageReduction);
                        }

                        bossHealth -= dealDamage;
                        Console.WriteLine($"Вам удалось нанести: {dealDamage} урона");
                        break;

                    case "3":
                        Console.WriteLine("\nПрименяя свое охотничье чувство вы находите слабую точку врага.");

                        feelWeakSpot = true;
                        break;

                    case "4":
                        Console.WriteLine("\nИсчузнув, вы находите лечебные травы с целью залечить свои раны.");
                        isDisappeared = true;

                        int curedHealth = health;
                        if (health + herbalHeal >= maxHealth)
                            health = maxHealth;
                        else
                            health += herbalHeal;

                        curedHealth = health - curedHealth;
                        Console.WriteLine($"Вам удалось восстановить здоровье: { curedHealth } хп");
                        break;

                    default:
                        Console.WriteLine("\nОт переполяющего волнения, вы запутались в своем вооружении и не успели ничего сделать.");
                        break;
                }

                if (bossHealth <= 0)
                {
                    Console.WriteLine("\nБосс взвыл от боли!");
                    bossDealDamage -= bossDealDamage;
                }
                else if (isDisappeared)
                {
                    if (bossWaitingCounter == bossLethalSkill)
                    {
                        Console.WriteLine("\nПорождение тьмы используя магию развеивания обнаруживает вас и совершает сокрушительный удар!");
                        bossDealDamage = health;
                    }    
                    else
                    {
                        Console.WriteLine("\nБосс в замешательстве оглядывается по сторонам.");
                        bossDealDamage -= bossDealDamage;
                        bossWaitingCounter++;
                        isDisappeared = false;
                    }    
                }
                else
                {
                    if (bossAttackCounter == bossComboSkill)
                    {
                        Console.WriteLine($"\nБосс проводит комбо ударов.");
                        bossDealDamage = bossDamage * bossIncreaseDamage;
                        bossAttackCounter = 0;
                    }
                    else
                    {
                        Console.WriteLine($"\nБосс совершает классический удар по вам.");
                        bossDealDamage = bossDamage;
                        bossAttackCounter++;
                    }
                }

                health -= bossDealDamage;
                Console.WriteLine($"Босс наносит вам: {bossDealDamage} урона");
            }

            if (health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВы были повержены!" +
                    "\nПорождение тьмы одержало побежу.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nНанеся последний удар вам удается победить порождение тьмы." +
                    "\nС победой вас!");
            }
        }
    }
}
