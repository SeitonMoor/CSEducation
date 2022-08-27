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
            int positionX;
            int positionY;

            public Player(int positionX, int positionY)
            {
                this.positionX = positionX;
                this.positionY = positionY;
            }

            public int GetPositionX()
            {
                return positionX;
            }

            public int GetPositionY()
            {
                return positionY;
            }
        }

        class Renderer
        {
            public void DrawCharacter(Player player)
            {
                Console.WriteLine($"Игрок отрисован по координатам: {player.GetPositionX()}.{player.GetPositionY()}");
            }
        }
    }
}
