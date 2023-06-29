
namespace SnakeGame
{
    public class Snake
    {
        private List<int> x, y;
        private static int length;
        private int speed;
        private Direction direction;

        public Snake(int startX, int startY, int startSpeed)
        {
            x = new List<int>() { startX, startX - 1, startX - 2, startX - 3 };
            y = new List<int>() { startY, startY - 1, startY - 2, startY - 3 };
            length = 4;
            speed = startSpeed;
        }

        public Snake() { }


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
