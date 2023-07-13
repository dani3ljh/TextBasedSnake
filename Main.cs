using SnakeGame;

public static class Program {
  public readonly static (int, int) BOARD_SIZE = (20,20);

  // head is snake[0]
  public static Point?[] snake = new Point?[BOARD_SIZE.Item1 * BOARD_SIZE.Item2];
  public static int snakeSize = 0;
  public static Point food = new Point(15, 10);

  public static int dx = 1;
  public static int dy = 0;

  public static void Main() {
    Setup();
    while (true) {
      Logic.Run(snake, food, dx, dy);
      Draw.Run(snake, food);
    }
  }

  public static void Setup() {
    Console.Clear();

    snake = new Point?[snake.Length];

    snake[0] = new Point(10, 10);
    snake[1] = new Point(9, 10);
    snake[2] = new Point(8, 10);
    snake[3] = new Point(7, 10);

    snakeSize = 4;

    food = new Point(15, 10);

    (dx, dy) = (1, 0);
  }
}
