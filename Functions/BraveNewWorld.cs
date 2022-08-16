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
            int pacmanDirectionX = 0;
            int pacmanDirectionY = 1;

            int allDots = 0;
            int collectDots = 0;

            char ghost = 'O';
            int ghostDirectionX = 0;
            int ghostDirectionY = -1;

            char[,] map = ReadMap("Original pac-man map", out int pacmanPositionX, out int pacmanPositionY, out int ghostPositionX, out int ghostPositionY, ref allDots);

            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, ref pacmanDirectionX, ref pacmanDirectionY);
                }

                if (map[pacmanPositionX + pacmanDirectionX, pacmanPositionY + pacmanDirectionY] != '#')
                {
                    CollectDots(map, pacmanPositionX, pacmanPositionY, ref collectDots);

                    Move(map, pacman, ref pacmanPositionX, ref pacmanPositionY, pacmanDirectionX, pacmanDirectionY);

                    DidPacmanGetEaten(ref isAlive, pacmanPositionX, pacmanPositionY, ghostPositionX, ghostPositionY);
                }

                if (map[ghostPositionX + ghostDirectionX, ghostPositionY + ghostDirectionY] != '#')
                {
                    Move(map, ghost, ref ghostPositionX, ref ghostPositionY, ghostDirectionX, ghostDirectionY);

                    DidPacmanGetEaten(ref isAlive, pacmanPositionX, pacmanPositionY, ghostPositionX, ghostPositionY);
                }
                else
                {
                    ChangeDirection(random, ref ghostDirectionX, ref ghostDirectionY);
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

        static char[,] ReadMap(string mapName, out int pacmanPositionX, out int pacmanPositionY, out int ghostPositionX, out int ghostPositionY, ref int allDots)
        {
            pacmanPositionX = 0;
            pacmanPositionY = 0;
            ghostPositionX = 0;
            ghostPositionY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')
                    {
                        pacmanPositionX = i;
                        pacmanPositionY = j;
                        InitializeDot(map, ref allDots, i, j);
                    }
                    else if (map[i, j] == 'O')
                    {
                        ghostPositionX = i;
                        ghostPositionY = j;
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

        static void CollectDots(char[,] map, int pacmanPositionX, int pacmanPositionY, ref int collectDots)
        {
            if (map[pacmanPositionX, pacmanPositionY] == '.')
            {
                map[pacmanPositionX, pacmanPositionY] = ' ';
                collectDots++;
            }
        }

        static void DidPacmanGetEaten(ref bool isAlive, int pacmanPositionX, int pacmanPositionY, int ghostPositionX, int ghostPositionY)
        {
            if (ghostPositionX == pacmanPositionX && ghostPositionY == pacmanPositionY)
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
