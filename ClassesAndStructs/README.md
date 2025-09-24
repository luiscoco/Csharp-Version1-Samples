# C# 1.0 - P02_Classes Example Explanation

This sample demonstrates **classes, fields, constructors, properties, encapsulation, and overriding `ToString()`** in **C# 1.0**.

---

## Example Structure

```csharp
public class Person
{
    private string name;   // backing field
    private int age;       // backing field

    // Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Property with backing field (no auto-properties in C# 1.0)
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    // Override ToString()
    public override string ToString()
    {
        return $"Name = {Name}, Age = {Age}";
    }
}

// Usage
class Program
{
    static void Main()
    {
        Person p = new Person("Alice", 30);
        Console.WriteLine(p);  // Calls ToString()
    }
}
```

---

## Key Concepts

### 1. Classes & Fields
- A **class** is a blueprint for objects.
- Fields (like `name` and `age`) store data internally.
- Marked `private` to enforce encapsulation.

### 2. Constructors
- Special methods used to **initialize** objects when created.
- Example: `new Person("Alice", 30)` calls the constructor and sets fields.

### 3. Properties (with Backing Fields)
- Provide **controlled access** to fields.
- In C# 1.0, you must write them explicitly (auto-properties came later).
- Example:
  ```csharp
  public string Name
  {
      get { return name; }
      set { name = value; }
  }
  ```

### 4. Encapsulation
- Fields are `private` (hidden from outside).
- Properties expose **safe, controlled** access to those fields.
- This protects internal state from misuse.

### 5. Override ToString()
- Default `ToString()` prints the class name.
- Overriding it provides a meaningful string representation of the object.

---

## Output Example

Running the program prints:

```
Name = Alice, Age = 30
```

---

## Why it Matters

- These are the **foundations of OOP in C#**.
- Even though modern C# has syntactic sugar (auto-properties, records, string interpolation, etc.), the underlying concepts remain essential.

# C# 1.0 - P03_Structs Example Explanation

This sample demonstrates **structs, classes, boxing/unboxing, and value copy behavior** in **C# 1.0**.

---

## Example Structure

```csharp
struct Point
{
    public int X;
    public int Y;
}

class Program
{
    static void Main()
    {
        // Struct copy by value
        Point p1 = new Point();
        p1.X = 5;
        Point p2 = p1;   // copy by value
        p2.X = 10;

        Console.WriteLine(p1.X); // 5
        Console.WriteLine(p2.X); // 10

        // Boxing and unboxing
        object o = p1;        // BOXING
        Point q = (Point)o;   // UNBOXING
        Console.WriteLine(q.X); // 5
    }
}
```

---

## Key Concepts

### 1. Structs
- Defined with `struct` keyword.
- Are **value types** (stored on stack or inline).
- When assigned or passed, they are **copied**.

### 2. Structs vs Classes
- **Classes** → reference types (heap, accessed by reference).
- **Structs** → value types (stack, copied on assignment).

Example difference:

```csharp
Point p1 = new Point { X = 5 };
Point p2 = p1; // copy

p2.X = 10;
Console.WriteLine(p1.X); // still 5
```

With a class, both variables would point to the same instance.

### 3. Boxing & Unboxing
- **Boxing**: wraps a value type inside an object reference (allocates on heap).
- **Unboxing**: extracts the value type back from the object.

```csharp
int n = 42;
object obj = n;       // BOXING
int m = (int)obj;     // UNBOXING
```

For structs:

```csharp
Point p = new Point { X = 1, Y = 2 };
object o = p;         // BOXING (copy on heap)
Point q = (Point)o;   // UNBOXING (copy back)
```

### 4. Copies by Value
- Assigning a struct copies its entire data.
- Passing a struct into a method passes a copy (unless `ref` is used).

```csharp
void ChangePoint(Point p) { p.X = 99; }

Point p1 = new Point { X = 1 };
ChangePoint(p1);
Console.WriteLine(p1.X); // still 1
```

Using `ref`:

```csharp
void ChangePoint(ref Point p) { p.X = 99; }
ChangePoint(ref p1);
Console.WriteLine(p1.X); // now 99
```

---

## Output Example

```
5
10
5
```

---

## Why it Matters

- Shows the **difference between value types and reference types**.
- Explains **boxing/unboxing**, which impacts **performance** (extra allocations and copies).
- Demonstrates how structs behave differently from classes in assignment and method calls.

