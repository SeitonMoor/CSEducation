using System;

namespace CSEducation
{
    internal class Images
    {
        public void Solution()
        {
            int userImages = 52;
            byte imagesInRow = 3;
            int numberOfRow;
            int extraImages;

            numberOfRow = userImages / imagesInRow;
            extraImages = userImages % imagesInRow;

            Console.WriteLine($"С вашим количеством картинок ({userImages}), " +
                $"можно заполнить рядов: {numberOfRow}. После чего останутся лишние картинки в количестве: {extraImages}");
        }
    }
}
