using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Map
    {
        internal char[,] ReadMap(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[,] map = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }

            return map;
        }

        internal void DrawMap(char[,] map)
        {
            int rows = map.GetLength(0);
            int columns = map.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        internal void SetApples(char[,] map)
        {
            int positionX = new Random().Next(2, 37);
            int positionY = new Random().Next(2, 16);

            map[positionY, positionX] = '*';
        }

        internal static bool IsExist(char[,] map)
        {
            bool result = true;

            foreach (var item in map)
            {
                if (item == '*') result = false;
            }
            return result;
        }
    }
}