namespace Program
{
    struct Point
    {
        public int x, y;
        public static Point operator -(Point lhs, Point rhs)
        {
            return new Point(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Point operator +(Point lhs, Point rhs)
        {
            return new Point(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Point operator *(Point lhs, Point rhs)
        {
            return new Point(lhs.x * rhs.x, lhs.y * rhs.y);
        }
        public static bool operator ==(Point lhs, Point rhs)
        {
            if (lhs.x == rhs.x &&
                lhs.y == rhs.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Point lhs, Point rhs)
        {
            if (lhs.x != rhs.x || lhs.y != rhs.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (this == (Point)obj);
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point up = new Point(0, 1);
        public static Point down = new Point(0, -1);
        public static Point left = new Point(-1, 0);
        public static Point right = new Point(1, 0);
        public static Point zero = new Point(0, 0);
    }
}