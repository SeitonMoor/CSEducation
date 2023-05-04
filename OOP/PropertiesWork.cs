using System;

namespace OOP
{
    internal class PropertiesWork
    {
        void Work()
        {
            Renderer renderer = new Renderer();

            Hero hero = new Hero(12, 19);
            
            renderer.DrawCharacter(hero);
        }
    }

    class Hero
    {
        public Hero(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
    }

    class Renderer
    {
        public void DrawCharacter(Hero hero)
        {
            Console.WriteLine($"Игрок отрисован по координатам: {hero.PositionX}.{hero.PositionY}");
        }
    }
}
