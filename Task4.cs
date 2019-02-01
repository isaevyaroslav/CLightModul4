using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLightModul4
{
    class Task4
    {
        /*
         4 Brave new world. 9 баллов.
            Сделать игровую карту с помощью двумерного массива. Сделать метод рисования карты.
            Помимо этого, дать пользователю возможность перемещаться по карте и взаимодействовать с
            элементами (например пользователь не может пройти сквозь стену)
            Все элементы являются обычными символами
         */
        static void SetMap(int mapWidth, int mapHeight, out char[,] map)
        {
            map = new char[mapHeight, mapWidth];

            for (int rowNumber = 0; rowNumber < map.GetLength(0); rowNumber++)
            {
                for (int colNumber = 0; colNumber < map.GetLength(1); colNumber++)
                {
                    if (colNumber == 0 || rowNumber == 0 || colNumber == map.GetLength(1) - 1 || rowNumber == map.GetLength(0) - 1)
                    {
                        map[rowNumber, colNumber] = '#';
                    }
                    else
                    {
                        map[rowNumber, colNumber] = ' ';
                    }
                }
            }
        }
        static void DrawMap(char[,] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write(map[row, col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsCollision(int nextY, int nextX, char[,] map, string collisionChars)
        {
            bool isCollision = false;
            for (int charNumber = 0; charNumber < collisionChars.Length; charNumber++)
            {
                isCollision = map[nextY, nextX] == collisionChars[charNumber];
            }
            return isCollision;
        }
        static void Main(string[] args)
        {
            int mapWidth = 40;
            int mapHeight = 20;
            char userRight = 'R';
            char userLeft = 'Я';
            char user = userRight;
            string collisionChars = "#";
            


            SetMap(mapWidth, mapHeight, out char[,] map);
            char[] bag = new char[0];


            int Y = 1, X = 1;
            while (true)
            {
                Console.SetCursorPosition(0, 0);

                DrawMap(map);
                Console.SetCursorPosition(Y, X);
                 int nextX = X, nextY = Y;
                 Console.Write(user);

                 ConsoleKeyInfo charKey = Console.ReadKey();
                 switch (charKey.Key)
                 {
                     case ConsoleKey.UpArrow:
                         nextX--;
                         break;
                     case ConsoleKey.DownArrow:
                         nextX++;
                         break;
                     case ConsoleKey.LeftArrow:
                         nextY--;
                         user = userLeft;
                         break;
                     case ConsoleKey.RightArrow:
                         nextY++;
                         user = userRight;
                         break;
                 }
                 if (!IsCollision(nextX, nextY, map, collisionChars))
                 {
                     Y = nextY;
                     X = nextX;
                 }
                Console.Clear();
            }
        }
    }
}
