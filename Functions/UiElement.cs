using System;

namespace Functions
{
    internal class UiElement
    {
        void UiBar()
        {
            int maxPercent = 100;

            Console.Write("Введите название бара: ");
            string barName = Console.ReadLine();
            Console.Write("Введите позицию бара по X: ");
            int barPostionX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите позицию бара по Y: ");
            int barPositionY = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число максимального показателя: ");
            int maxValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число текущего показателя: ");
            int value = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            int percent = CalculatePercent(value, maxValue, maxPercent);
            PrepareToDraw(barName, percent, maxPercent, barPostionX, barPositionY);
        }

        static void PrepareToDraw(string barName, int percent, int maxPercent, int positionX, int positionY)
        {
            string bar = $"{barName}: [";
            char valueSymbol = '#';
            char barSymbol = '_';
            int startIndex = 0;

            int value = RoundToValues(percent);
            int maxValue = RoundToValues(maxPercent);

            FillBar(ref bar, startIndex, value, valueSymbol);
            FillBar(ref bar, value, maxValue, barSymbol);

            DrawBar(bar, positionX, positionY);
        }

        static void DrawBar(string bar, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(bar);
        }

        static void FillBar(ref string bar, int startValue, int lastValue, char symbol)
        {
            for (int i = startValue; i < lastValue; i++)
            {
                bar += symbol;
            }

            if (startValue != 0)
            {
                bar += ']';
            }
        }

        static int CalculatePercent(int value, int maxValue, int maxPercent)
        {
            int percent = value * maxPercent / maxValue;

            return percent;
        }

        static int RoundToValues(int value)
        {
            int rounder = 10;
            value /= rounder;

            return value;
        }
    }
}
