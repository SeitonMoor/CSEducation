using System;
using System.IO;

namespace Functions
{
    internal class BraveNewWorld
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 40);
            Console.CursorVisible = false;
            Random random = new Random();
            ConsoleColor winColor = ConsoleColor.Green;
            ConsoleColor defeatColor = ConsoleColor.Red;
            bool isPlaying = true;

            char pacman = '@';
            bool isAlive = true;
            int pacmanDX = 0;
            int pacmanDY = 1;

            int allDots = 0;
            int collectDots = 0;

            char ghost = 'O';
            int ghostDX = 0;
            int ghostDY = -1;

            char[,] map = ReadMap("Original pac-man map", out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref allDots);

            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }

                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    CollectDots(map, pacmanX, pacmanY, ref collectDots);

                    Move(map, pacman, ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);

                    DidPacmanGetEaten(ref isAlive, pacmanX, pacmanY, ghostX, ghostY);
                }

                if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
                {
                    Move(map, ghost, ref ghostX, ref ghostY, ghostDX, ghostDY);

                    DidPacmanGetEaten(ref isAlive, pacmanX, pacmanY, ghostX, ghostY);
                }
                else
                {
                    ChangeDirection(random, ref ghostDX, ref ghostDY);
                }

                System.Threading.Thread.Sleep(200);

                Console.SetCursorPosition(0, 32);
                Console.WriteLine($"Собрано {collectDots}/{allDots}");

                if (collectDots == allDots || isAlive == false)
                {
                    isPlaying = false;
                }
            }

            Console.SetCursorPosition(0, 33);
            if (collectDots == allDots)
            {
                WriteMessage("Вы победили!", winColor);
            }
            else if (isAlive == false)
            {
                WriteMessage("Вас съели!", defeatColor);
            }
        }

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allDots)
        {
            pacmanX = 0;
            pacmanY = 0;
            ghostX = 0;
            ghostY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                        InitializeDot(map, ref allDots, i, j);
                    }
                    else if (map[i, j] == 'O')
                    {
                        ghostX = i;
                        ghostY = j;
                        InitializeDot(map, ref allDots, i, j);
                    }
                    else if (map[i, j] == ' ')
                    {
                        InitializeDot(map, ref allDots, i, j);
                    }
                }
            }

            return map;
        }

        static void InitializeDot(char[,] map, ref int allDots, int positionX, int positionY)
        {
            map[positionX, positionY] = '.';
            allDots++;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void Move(char[,] map, char symbol, ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(map[positionX, positionY]);

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY, positionX);
            Console.Write(symbol);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;

                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;

                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }

        static void ChangeDirection(Random random, ref int diractionX, ref int directionY)
        {
            int ghostDirection = random.Next(1, 5);
            switch (ghostDirection)
            {
                case 1:
                    diractionX = -1;
                    directionY = 0;
                    break;

                case 2:
                    diractionX = 1;
                    directionY = 0;
                    break;

                case 3:
                    diractionX = 0;
                    directionY = -1;
                    break;

                case 4:
                    diractionX = 0;
                    directionY = 1;
                    break;
            }
        }

        static void CollectDots(char[,] map, int pacmanX, int pacmanY, ref int collectDots)
        {
            if (map[pacmanX, pacmanY] == '.')
            {
                map[pacmanX, pacmanY] = ' ';
                collectDots++;
            }
        }

        static void DidPacmanGetEaten(ref bool isAlive, int pacmanX, int pacmanY, int ghostX, int ghostY)
        {
            if (ghostX == pacmanX && ghostY == pacmanY)
            {
                isAlive = false;
            }
        }

        static void WriteMessage(string text, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}
