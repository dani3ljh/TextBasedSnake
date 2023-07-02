public static class Program
{
    // indexs only valid from 0-19
    public readonly static (int, int) BOARD_SIZE = (20,20);

    // head is at index 0
    public static SnakeQueue<Point> snakeBody = new SnakeQueue<Point>();
    public static Point food = new Point(15, 20);

    public static int dx = 1;
    public static int dy = 0;

    public static void Main()
    {
        Setup();
        while (true) {
            Logic();
            Draw();
        }
    }

    public static void Logic()
    {
        Point? oldHead = snakeBody.Last;
        if (oldHead is null)
            throw new Exception("Snake Queue Empty");
        Point head = new Point(oldHead.x + dx, oldHead.y + dy);
        snakeBody.Dequeue();
        if ((head.x < 0) || (head.x >= BOARD_SIZE.Item1) || (head.y < 0) || (head.y >= BOARD_SIZE.Item2))
            throw new Exception($"Game Over {head} out of bounds");
        if (snakeBody.Contains(head)) {
            throw new Exception($"Game Over {head} is in ");
        }
        snakeBody.Enqueue(head);
    }

    public static void Draw()
    {
    }

    public static void Setup()
    {
        Console.Clear();
        snakeBody.Clear();

        snakeBody.Enqueue(new Point(7, 10));
        snakeBody.Enqueue(new Point(8, 10));
        snakeBody.Enqueue(new Point(9, 10));
        snakeBody.Enqueue(new Point(10, 10));

        food = new Point(15, 20);

        (dx, dy) = (1, 0);
    }
}

public class Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj) => this.Equals(obj as Point);

    public bool Equals(Point? p)
    {
        if (p is null)
            return false;

        if (Object.ReferenceEquals(this, p))
            return true;

        if (this.GetType() != p.GetType())
            return false;

        return (x == p.x) && (y == p.y);
    }

    public override int GetHashCode() => (x, y).GetHashCode();

    public static bool operator ==(Point lhs, Point rhs)
    {
        if (lhs is null) {
            if (rhs is null)
                return true;
            return false;
        }

        return lhs.Equals(rhs);
    }

    public static bool operator !=(Point lhs, Point rhs) => !(lhs == rhs);

    public override string ToString() => $"({this.x}, {this.y})";
}

public class SnakeQueue<T> : Queue<T>
{
    public T? Last { get; private set; }

    public new void Enqueue(T item)
    {
         Last = item;
         base.Enqueue(item);
    }
}
