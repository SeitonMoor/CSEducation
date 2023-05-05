using System;

namespace LinqTasks
{
    internal class FindCriminal
    {
        static void Main(string[] args)
        {
            Interpol interpol = new Interpol();
            interpol.Work();
        }
    }

    enum Surname
    {
        Smith,
        Brown,
        Roy,
        Wilson,
        Petrov
    }

    enum Name
    {
        William,
        Ivan,
        John,
        Robert,
        Henry,
        Thomas,
        Petr,
        David,
        Alex
    }

    enum Patronymic
    {
        Adamson,
        Dixon,
        Wilson,
        Thompson,
        Ivanov,
        Petrov,
        Gibson,
        Emberson
    }

    enum Nation
    {
        British,
        American,
        Russian,
        Australian,
        Canadian,
        German,
        Italian
    }

    class Interpol
    {
        public void Work() { }
    }

    class Criminal
    {
    }
}
