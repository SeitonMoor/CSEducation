using System;

namespace CSEducation
{
    internal class Polyclinic
    {
        static void Main(string[] args)
        {
            int timePerPatient = 10;
            int minutesInHour = 60;

            Console.Write("Напишите какое количество людей в очереди: ");
            int patientsInQueue = Convert.ToInt32(Console.ReadLine());

            int timeWaiting = patientsInQueue * timePerPatient;
            int hoursWaiting = timeWaiting / minutesInHour;
            int minutesWaiting = timeWaiting % minutesInHour;

            Console.WriteLine($"Вы должны отстоять в очереди {hoursWaiting} часа и {minutesWaiting} минут.");
        }
    }
}
