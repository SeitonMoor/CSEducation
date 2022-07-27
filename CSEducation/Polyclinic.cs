using System;

namespace CSEducation
{
    internal class Polyclinic
    {
        static void Main(string[] args)
        {
            int timePerPatient = 10;

            Console.Write("Напишите какое количество людей в очереди: ");
            int patientsInQueue = Convert.ToInt32(Console.ReadLine());

            int hoursWaiting = patientsInQueue * timePerPatient / 60;
            int minutesWaiting = patientsInQueue * timePerPatient % 60;

            Console.WriteLine($"Вы должны отстоять в очереди {hoursWaiting} часа и {minutesWaiting} минут.");
        }
    }
}
