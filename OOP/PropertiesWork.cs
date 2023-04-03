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
            public Player(int positionX, int positionY)
            {
                PositionX = positionX;
                PositionY = positionY;
            }

            public int PositionX { get; private set; }
            public int PositionY { get; private set; }
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
