namespace SnakeGame;

internal class Program
{
    internal static int score;

    static void Main(string[] args)
    {
        Console.WriteLine("----НАЖМИТЕ ЛЮБУЮ КНОПУ ЧТОБЫ НАЧАТЬ ИГРАТЬ----");

        SetConsoleProperties();
        Map map = new Map();
        char[,] field = map.ReadMap(@"D:\Place For All VS projects\SnakeProj\snakeMap.txt");
        Snake snake = new Snake(10, 6, 1);
        ConsoleKeyInfo key = Console.ReadKey(false);

        Task.Run(() =>
        {
            while (true)
            {
                key = Console.ReadKey(false);

            }
        });


        while (true)
        {
            Console.Clear();

            if (Map.IsExist(field))
            {
                map.SetApples(field);
            }

            map.DrawMap(field);

            Console.SetCursorPosition(0, 18);
            Console.Write($"Score : {score}");

            snake.DrawSnake();
            snake.MoveSnake(key, field);

            Thread.Sleep(200);
        }

    }

    private static void SetConsoleProperties()
    {
        Console.CursorVisible = false;
        Console.WindowHeight = 25;
        Console.WindowWidth = 50;
    }
}