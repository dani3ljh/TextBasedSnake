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
    Console.Clear();

    (snake, snakeSize, food, dx, dy) = Logic.Setup(snake.Length);
    while (true) {
      Logic.Run(snake, food, dx, dy);
      Draw.Run(snake, food);
    }
  }
}
