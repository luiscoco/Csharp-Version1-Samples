# C# 1.0 - P08_Operators

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **operator overloading on a struct** and **formatting output with ToString()** in **C# 1.0**.

---

## Example Code

```csharp
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

    // Overload + operator
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

        Point sum = p1 + p2;   // Calls overloaded operator

        Console.WriteLine(p1);   // (2, 3)
        Console.WriteLine(p2);   // (4, 5)
        Console.WriteLine(sum);  // (6, 8)
    }
}
```

---

## Key Concepts

### 1. Operator Overloading
- Custom types can redefine how operators work.
- Must be declared as `public static`.
- Example: `public static Point operator +(Point a, Point b)`.

### 2. Structs
- Here `Point` is a struct with `X` and `Y` coordinates.
- Adding two points creates a new point with summed coordinates.

### 3. ToString()
- Overridden to provide friendly string output.
- Without overriding, printing would show the struct type name.

```csharp
public override string ToString()
{
    return $"({X}, {Y})";
}
```

---

## Example Output

```
(2, 3)
(4, 5)
(6, 8)
```

---

## Why it Matters

- Operator overloading makes **custom types** more natural to use.
- Enables expressions like `p1 + p2` instead of `Add(p1, p2)`.
- `ToString()` improves readability and debugging output.
