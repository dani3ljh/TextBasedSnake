using SnakeGame;

public static class Program
{
    // head is snakeBody.Last
    public static LinkedList<Point> snakeBody = new LinkedList<Point>();
    public static Point food = new Point(15, 20);

    public static int dx = 1;
    public static int dy = 0;
        

    public static void Main()
    {
        Setup();
        while (true) {
            Logic.Run(snakeBody, food, dx, dy);
            Draw.Run(snakeBody, food);
        }
    }

    public static void Setup()
    {
        Console.Clear();
        snakeBody.Clear();

        snakeBody.AddLast(new Point(7, 10));
        snakeBody.AddLast(new Point(8, 10));
        snakeBody.AddLast(new Point(9, 10));
        snakeBody.AddLast(new Point(10, 10));

        Console.WriteLine(snakeBody.Count);

        food = new Point(15, 20);

        (dx, dy) = (1, 0);
    }
}

