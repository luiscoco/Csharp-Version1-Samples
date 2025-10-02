# C# 1.0 - P02_Classes Example Explanation

This sample demonstrates **classes, fields, constructors, properties, encapsulation, and overriding `ToString()`** in **C# 1.0**.

Now let’s look at another C# 1.0 example, this time focusing on classes, fields, constructors, properties, encapsulation, and overriding ToString().

## 1. Classes and Fields
A class is simply a blueprint for creating objects.

In this case, our class is Person. It defines what a person object will look like.

Inside the class, we have two fields: name and age.

They are marked private, which means they are hidden from the outside world.

These fields store the actual data inside the object.

## 2. Constructors
A constructor is a special method that runs when we create an object.

Here, the constructor takes two parameters, name and age, and uses them to set the fields.

So when we write new Person("Alice", 30), the constructor is immediately called to initialize the object’s state.

## 3. Properties (with Backing Fields)

In C# 1.0, properties are written explicitly, using a private field in the background — called a backing field.

For example, the Name property is connected to the name field.

The get block returns the value of the field.

The set block updates the field.

This allows us to access data like p.Name instead of directly accessing the private field.

In modern C#, we have auto-properties which make this shorter, but in version 1.0, everything had to be written out.

## 4. Encapsulation

Encapsulation is one of the key ideas of object-oriented programming.

It means: hide the internal data, but provide safe access through properties or methods.

By keeping name and age private and only exposing them through properties, we protect the object from misuse. For example, we could later add validation in the setter if needed, without changing how the class is used.

## 5. Overriding ToString()

Every object in C# has a ToString() method, but by default, it only prints the class name.

In our example, we override ToString() to return a meaningful description:

Name = Alice, Age = 30.

This makes our objects much easier to display and debug.

Putting It All Together
In the Main() method, we create a new Person with name Alice and age 30.

When we print it using Console.WriteLine(p), the runtime automatically calls our custom ToString() method and shows a nice formatted message.

## Summary

A class is a blueprint for objects.

Fields store the actual data, usually private.

Constructors initialize new objects.

Properties give controlled access to fields.

Encapsulation hides data but exposes safe access.

Overriding ToString() makes objects print meaningful information.

This is one of the most important foundations in C#. Everything else builds on these concepts

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

