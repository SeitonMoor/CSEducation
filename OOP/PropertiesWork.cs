using System;

namespace OOP
{
    internal class PropertiesWork
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();

            Player player = new Player(12, 19);
            
            renderer.DrawCharacter(player);
        }

        class Player
        {
            public int PositionX { get; private set; }
            public int PositionY { get; private set; }

            public Player(int positionX, int positionY)
            {
                PositionX = positionX;
                PositionY = positionY;
            }
        }

        class Renderer
        {
            public void DrawCharacter(Player player)
            {
                Console.WriteLine($"Игрок отрисован по координатам: {player.PositionX}.{player.PositionY}");
            }
        }
    }
}
