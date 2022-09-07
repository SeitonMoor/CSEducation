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
            private int _positionX;
            private int _positionY;

            public Player(int positionX, int positionY)
            {
                this._positionX = positionX;
                this._positionY = positionY;
            }

            public int GetPositionX()
            {
                return _positionX;
            }

            public int GetPositionY()
            {
                return _positionY;
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
