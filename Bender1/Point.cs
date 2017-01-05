using System;

struct Point : IEquatable<Point>
{
    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public bool Equals(Point other)
    {
        return other.X == X && other.Y == Y;
    }
}
