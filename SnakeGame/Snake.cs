
using NAudio.Wave;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnakeGame
{
    internal class Snake
    {
        private List<int> x, y;
        private static int length;
        private int speed;
        private Direction direction;

        internal Snake(int startX, int startY, int startSpeed)
        {
            x = new List<int>() { startX };
            y = new List<int>() { startY };
            length = 1;
            speed = startSpeed;
        }

        internal void MoveSnake(ConsoleKeyInfo key, char[,] map)
        {

            switch (key.Key)
            {
                case ConsoleKey.UpArrow: direction = Direction.UP; break;
                case ConsoleKey.DownArrow: direction = Direction.DOWN; break;
                case ConsoleKey.LeftArrow: direction = Direction.LEFT; break;
                case ConsoleKey.RightArrow: direction = Direction.RIGHT; break;
            }

            for (int i = length - 1; i > 0; i--)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }

            int[] nextDirection = NextDirection();
            int nextX = nextDirection[0] + x[0];
            int nextY = nextDirection[1] + y[0];

            if (map[nextY, nextX] == ' ')
            {
                x[0] = nextX;
                y[0] = nextY;
            }

            else if (map[nextY, nextX] == '*')
            {
                var audio = new AudioFileReader(@"D:\Place For All VS projects\SnakeProjNew\y2mate.com - video game beepSound effect.mp3");
                var outputFile = new WaveOutEvent();
                outputFile.Init(audio);
                outputFile.Play();
                x.Add(nextX);
                y.Add(nextY);
                length++;
                map[nextY, nextX] = ' ';
                Program.score++;
            }

            else if (map[nextY, nextX] == '|' || map[nextY, nextX] == '-')
            {
                Console.Clear();
                Console.WriteLine("---GAME OVER---");
                throw new Exception();
            }
        }

        internal int[] NextDirection()
        {
            int[] nextDirection = { 0, 0 };

            switch (direction)
            {
                case Direction.UP: nextDirection[1]--; break;
                case Direction.DOWN: nextDirection[1]++; break;
                case Direction.LEFT: nextDirection[0]--; break;
                case Direction.RIGHT: nextDirection[0]++; break;
            }
            return nextDirection;
        }

        internal void DrawSnake()
        {
            for (int i = 0; i < length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write('@');
            }
        }
    }

    enum Direction
    {
        UP, 
        DOWN, 
        LEFT, 
        RIGHT
    }
}
