namespace SnakeGame {
  public class Draw {
    private static int originalRow;
    private static int originalCol;

    public static void Run(Point?[] snake, Point food) {
      Console.Clear();

      foreach (Point? snakePoint in snake) {
        if (snakePoint == null) break;

        PrintAt(ConsoleColor.Green, snakePoint);
      }

      PrintAt(ConsoleColor.Red, food);
    }

    public static void Setup() {
      Console.CursorVisible = false;

      Console.Clear();

      originalRow = Console.CursorTop;
      originalCol = Console.CursorLeft;
      
      Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCtrlCHandler);
    }

    private static void PrintAt(ConsoleColor color, Point point){
      try {
        Console.SetCursorPosition(originalCol + point.x, originalRow + point.y);
        Console.BackgroundColor = color;
        Console.Write(" ");
        Console.ResetColor();
      } catch (ArgumentOutOfRangeException e) {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine(e.Message);
      }
    }

    // idk why this is protected i just copied some code
    protected static void OnCtrlCHandler(object sender, ConsoleCancelEventArgs args) {
      CleanUp();
    }

    public static void CleanUp() {
      Console.ResetColor();
      Console.Clear();

      Console.CursorVisible = true;
    }
  }
}
