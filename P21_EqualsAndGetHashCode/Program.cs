using System;
using System.Collections.Generic; // For HashSet

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Override Equals for value equality
    public override bool Equals(object obj)
    {
        // Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Point p = (Point)obj;
            return (X == p.X) && (Y == p.Y);
        }
    }

    // Override GetHashCode for consistency with Equals
    public override int GetHashCode()
    {
        // Combine hash codes of immutable fields
        // A simple way is to XOR them, or use a prime number multiplier
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override string ToString()
    {
        return $("({X}, {Y})");
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(1, 2);
        Point p2 = new Point(1, 2);
        Point p3 = new Point(3, 4);

        Console.WriteLine($"p1: {p1}, p2: {p2}, p3: {p3}");

        // Test Equals method
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}"); // Should be true
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}"); // Should be false

        // Test reference equality vs value equality
        Console.WriteLine($"p1 == p2: {p1 == p2}"); // Should be false (default reference equality for classes)

        // Demonstrate behavior in collections (HashSet uses Equals and GetHashCode)
        HashSet<Point> points = new HashSet<Point>();
        points.Add(p1);
        Console.WriteLine($"HashSet contains p1: {points.Contains(p1)}"); // Should be true
        Console.WriteLine($"HashSet contains p2: {points.Contains(p2)}"); // Should be true (because Equals and GetHashCode are overridden)
        Console.WriteLine($"HashSet contains p3: {points.Contains(p3)}"); // Should be false

        points.Add(p2); // This will not add p2 because it's considered equal to p1
        Console.WriteLine($"Count in HashSet after adding p2: {points.Count}"); // Should still be 1
    }
}
