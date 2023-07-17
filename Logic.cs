namespace SnakeGame {
  public static class Logic {
    // indexs only valid from 0-19
    public static string? Run(Point?[] snake, Point food, int dx, int dy) {
      if (Program.snakeSize == 0 || snake[0] == null)
        return "Snake Body Empty";

      Point newHead = new Point(snake[0].x + dx, snake[0].y + dy);

      if ((newHead.x < 0) || (newHead.x >= Program.BOARD_SIZE.Item1) || (newHead.y < 0) || (newHead.y >= Program.BOARD_SIZE.Item2))
        return $"Game Over, Score: {Program.snakeSize - 4}, out of bounds";

      bool isCollectingFood = newHead == food;

      // if not collecting, then write over snake[size - 1], else dont and increase size
      for (int i = Program.snakeSize - (isCollectingFood ? 1 : 2); i >= 0; i--) {
				if (snake[i] is null)
					return $"snake at index {i} is null";

        if (snake[i] == newHead)
          return $"Game Over {newHead} found in snake";

        snake[i+1] = snake[i];
      }

      if (isCollectingFood) {
				Program.snakeSize++;
				Program.food = GetRandomFreePoint(snake, new Random());
      }

      snake[0] = newHead;

      return null;
    }

    public static Point GetRandomFreePoint(Point?[] snake, Random rng) {
      List<Point> snakePoints = new List<Point>();

      for (int i = 0; i < snake.Length; i++) {
        if (snake[i] == null) break;
        snakePoints.Add(snake[i]);
      }

      List<Point> openPoints = new List<Point>();

      for (int x = 0; x < Program.BOARD_SIZE.Item1; x++) {
        for (int y = 0; y < Program.BOARD_SIZE.Item2; y++) {
          Point point = new Point(x, y);
          if (snakePoints.Contains(point)) continue;
          openPoints.Add(point);
        }
      }

      return openPoints[rng.Next(openPoints.Count)];
    }

    // snake, snakeSize, food, dx, dy
    public static (Point?[], int, Point, int, int) Setup(int snakeLength) {
      Point?[] snake = new Point?[snakeLength];

      snake[0] = new Point(10, 10);
      snake[1] = new Point(9, 10);
      snake[2] = new Point(8, 10);
      snake[3] = new Point(7, 10);

      Point food = new Point(15, 10);

      return (snake, 4, food, 1, 0);
    }
  }

  public class Point {
    public int x;
    public int y;

    public Point(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public override bool Equals(object? obj) => this.Equals(obj as Point);

    public bool Equals(Point? p) {
      if (p is null)
        return false;

      if (Object.ReferenceEquals(this, p))
        return true;

      if (this.GetType() != p.GetType())
        return false;

      return (x == p.x) && (y == p.y);
    }

    public override int GetHashCode() => (x, y).GetHashCode();

    public static bool operator ==(Point? lhs, Point? rhs) {
      if (lhs is null) {
        if (rhs is null)
          return true;
        return false;
      }

      return lhs.Equals(rhs);
    }

    public static bool operator !=(Point? lhs, Point? rhs) => !(lhs == rhs);

    public override string ToString() => $"({this.x}, {this.y})";
  }
}
