using System;

public struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overload +
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    // Override ToString for formatting
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(2, 3);
        Point p2 = new Point(4, 5);

        Point sum = p1 + p2;   // calls overloaded operator

        Console.WriteLine(p1);   // (2, 3)
        Console.WriteLine(p2);   // (4, 5)
        Console.WriteLine(sum);  // (6, 8)
    }
}

