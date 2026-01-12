# C# 1.0 - P21_Equality_HashCodes_Collections

Now let’s look at an example that teaches us about object equality in C#. This is fundamental for understanding how objects behave in comparisons and in collections like HashSet or Dictionary.

## 1. The Point Class

We have a simple class:

```csharp
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```

Each point has two coordinates, X and Y.

## 2. The Default Equality (Reference Equality)

In C#, classes are reference types.

By default, if we compare two objects with ==, we are checking if they are the same reference in memory, not if their data matches.

That’s why in this code:

```csharp
Point p1 = new Point(1, 2);
Point p2 = new Point(1, 2);
Console.WriteLine(p1 == p2); // false
```

Even though both points have the same values, they are different objects in memory.

## 3. Overriding Equals for Value Equality

To compare by values, we override the Equals method:

```csharp
public override bool Equals(object obj)
{
    if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        return false;
    Point p = (Point)obj;
    return (X == p.X) && (Y == p.Y);
}
```

This makes p1.Equals(p2) return true, because they both have X = 1 and Y = 2.

So:

```csharp
p1.Equals(p2)  // true
p1.Equals(p3)  // false
```

## 4. Overriding GetHashCode

Whenever we override Equals, we must also override GetHashCode.

Why? Because collections like HashSet and Dictionary use hash codes to quickly group and look up objects.

Here we do:

```csharp
public override int GetHashCode()
{
    return X.GetHashCode() ^ Y.GetHashCode();
}
```

This combines the hash codes of X and Y.

Now two points with the same values will also have the same hash code, making them behave correctly in collections.

## 5. Behavior in Collections

Let’s test with a HashSet<Point>:

```csharp
HashSet<Point> points = new HashSet<Point>();
points.Add(p1);

Console.WriteLine(points.Contains(p1)); // true
Console.WriteLine(points.Contains(p2)); // true, because Equals + GetHashCode match
Console.WriteLine(points.Contains(p3)); // false
```

Without overriding Equals and GetHashCode, p2 would not be recognized as equal to p1, even though the values are the same.

Also, when we add p2:

```csharp
points.Add(p2);
Console.WriteLine(points.Count); // still 1
```

The HashSet doesn’t add a duplicate because it considers p1 and p2 equal.

## Summary of Key Concepts

Default class equality: compares references, not values.

Override Equals: defines when two objects should be considered equal based on their fields.

Override GetHashCode: ensures objects that are equal share the same hash code, critical for collections.

Collections like HashSet rely on both methods to avoid duplicates.

## Why It Matters

This is the foundation of value equality in C#.

It underpins how .NET collections work, how objects are compared, and even how frameworks like Entity Framework or LINQ handle uniqueness.
