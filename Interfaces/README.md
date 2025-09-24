# C# 1.0 - P04_Interfaces Example Explanation

This sample demonstrates **interfaces, inheritance, virtual/override methods, and polymorphism via interface references** in **C# 1.0**.

---

## Example Structure

```csharp
public interface IShape
{
    double Area();
}

public class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a generic shape.");
    }
}

public class Circle : Shape, IShape
{
    public double Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine("Drawing a circle.");
    }

    public double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape, IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle.");
    }

    public double Area() => Width * Height;
}

class Program
{
    static void Main()
    {
        IShape[] shapes =
        {
            new Circle { Radius = 2 },
            new Rectangle { Width = 3, Height = 4 }
        };

        foreach (IShape s in shapes)
        {
            Console.WriteLine("Area = " + s.Area());
        }
    }
}
```

---

## Key Concepts

### 1. Interfaces
- Define a **contract** (methods/properties) without implementation.
- Classes or structs that implement the interface must provide the implementation.

Example:
```csharp
public interface IShape
{
    double Area();
}
```

### 2. Inheritance
- Classes can **inherit** from one base class and extend/override behavior.
- Example: `Circle` and `Rectangle` inherit from `Shape`.

### 3. Virtual / Override
- Base class method marked `virtual` can be overridden.
- Derived classes provide their own implementation using `override`.

```csharp
public override void Draw()
{
    Console.WriteLine("Drawing a circle.");
}
```

### 4. Polymorphism via Interfaces
- Different objects can be treated uniformly through their interface type.

```csharp
IShape s1 = new Circle { Radius = 3 };
IShape s2 = new Rectangle { Width = 4, Height = 5 };

Console.WriteLine(s1.Area()); // Circle's Area
Console.WriteLine(s2.Area()); // Rectangle's Area
```

---

## Output Example

```
Area = 12.5663706143592
Area = 12
```

---

## Why it Matters

- **Interfaces** decouple code from specific implementations.
- **Inheritance** allows reuse and extension of base functionality.
- **Virtual/Override** enable runtime polymorphism (dynamic method dispatch).
- **Polymorphism** makes code more flexible and extensible.
