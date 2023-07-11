namespace SnakeGame {
    public static class Logic {
        // indexs only valid from 0-19
        public readonly static (int, int) BOARD_SIZE = (20,20);

        public static void Run(LinkedList<Point> snakeBody, Point food, int dx, int dy) {
            LinkedListNode<Point>? lastHead = snakeBody.Last;

            if (snakeBody.Count == 0 || lastHead == null)
                throw new Exception("Snake Queue Empty");

            Point head = new Point(lastHead.Value.x + dx, lastHead.Value.y + dy);

            if ((head.x < 0) || (head.x >= BOARD_SIZE.Item1) || (head.y < 0) || (head.y >= BOARD_SIZE.Item2))
                throw new Exception($"Game Over {head} out of bounds");

            if (snakeBody.Contains(head))
                throw new Exception($"Game Over {head} is in Linked List");

            snakeBody.AddLast(head);
            snakeBody.RemoveFirst();
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

        public static bool operator ==(Point lhs, Point rhs) {
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
}
