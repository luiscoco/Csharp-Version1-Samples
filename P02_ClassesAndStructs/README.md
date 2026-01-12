# C# 1.0 - P02_Classes Example Explanation

This sample demonstrates **classes, fields, constructors, properties, encapsulation, and overriding `ToString()`** in **C# 1.0**.

This sample demonstrates classes, fields, constructors, properties, encapsulation, and overriding ToString() — all fundamental building blocks of object-oriented programming in C#.

 ## 1. Classes and Fields

A class is a blueprint for creating objects.

In our example, the class is Person, which defines what a person object looks like.

Inside, we have two fields, name and age.

They’re marked private, meaning they are hidden from the outside world.

These fields hold the actual data of the object.

This is the idea of keeping data safe inside the class.

## 2. Constructors

A constructor is a special method that runs automatically when we create a new object.

Here, the constructor takes two parameters — name and age — and uses them to initialize the fields.

So when we write new Person("Alice", 30), the constructor is immediately called to set up the new object.

## 3. Properties (with Backing Fields)

In C# 1.0, properties had to be written explicitly, using private fields behind the scenes — called backing fields.

For example, the Name property:

The get block reads the private field.

The set block updates the private field.

This lets us write p.Name instead of touching the field directly.

Today, C# has auto-properties, which make this shorter, but in version 1.0 everything had to be spelled out.

## 4. Encapsulation

Encapsulation means: hide the internal data, but provide controlled access through properties or methods.

By keeping name and age private and only exposing them through properties, we protect the internal state.

For example, later we could add validation in the set block (like preventing negative ages) without changing how the class is used.

This is one of the cornerstones of object-oriented programming (OOP).

## 5. Overriding ToString()

Every object in C# has a ToString() method, but by default it just prints the class name.

By overriding it, we return a meaningful string, for example:

Name = Alice, Age = 30.

This makes our objects easier to display, log, and debug.

Putting It All Together

In Main(), we create a new Person with "Alice", 30.

When we call Console.WriteLine(p), the runtime automatically uses our overridden ToString() method to print the formatted output.

Output:

Name = Alice, Age = 30

## Summary of Key Concepts

Class → Blueprint for objects.

Fields → Store the actual data (kept private).

Constructor → Initializes new objects.

Properties → Provide controlled access to fields.

Encapsulation → Hides data, exposes safe access.

ToString() override → Gives objects a meaningful string form.

## Why It Matters

These are the foundations of C# and OOP.

Even though modern C# adds conveniences like auto-properties, records, and improved syntax, the underlying concepts remain the same.

If you understand this example, you understand the core structure of every C# class you’ll write in the future.

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

This sample introduces structs, the difference between structs and classes, boxing and unboxing, and how value types are copied in C#.

## 1. Structs

A struct in C# is defined using the struct keyword.

Unlike classes, structs are value types. That means they are stored directly on the stack (or inline inside other objects).

Key point: when you assign a struct to another variable, you get a copy of the data, not a reference to the same object.

In the example:

'''csharp
Point p1 = new Point();
p1.X = 5;
Point p2 = p1;  // copy
p2.X = 10;
'''

Here, p1 and p2 are two independent copies. Changing p2.X does not affect p1.X.

Output:

'''csharp
p1.X = 5
p2.X = 10
'''

## 2. Structs vs Classes

This is the main difference you should remember:

Classes are reference types. When you assign them, both variables point to the same object in memory.

Structs are value types. When you assign them, the data is copied, and the variables work independently.

So:

With a class → both references see the same changes.

With a struct → each variable holds its own copy.

## 3. Boxing and Unboxing

Another important concept introduced in C# 1.0 is boxing and unboxing.

Boxing: when a value type (like a struct or int) is converted into an object. 

This allocates a new copy of the value on the heap and wraps it in an object reference.

Unboxing: when you extract the value type back from the object.

Example from our code:

'''csharp
object o = p1;      // BOXING (struct copied into an object)
Point q = (Point)o; // UNBOXING (copy back into a struct)
'''

Here, q is another independent copy of p1.

Why does this matter? Because boxing and unboxing cause extra memory allocations and copies, which can impact performance in tight loops or heavy calculations.

## 4. Copies by Value

Another consequence of structs being value types is method parameter passing.

By default, if you pass a struct into a method, you pass a copy. Any changes inside the method don’t affect the original.

If you want to modify the original, you must use the ref keyword.

Example:

'''csharp
void ChangePoint(Point p) { p.X = 99; }  // copy
ChangePoint(p1);
Console.WriteLine(p1.X); // still original value
'''

But with ref:

'''csharp
void ChangePoint(ref Point p) { p.X = 99; }  
ChangePoint(ref p1);
Console.WriteLine(p1.X); // now updated to 99
'''

## Summary of Key Concepts

Structs → value types, copied on assignment.

Classes → reference types, assigned by reference.

Boxing/Unboxing → value types can be wrapped in objects and later unwrapped, but this creates extra copies.

Value Copy Behavior → assigning or passing structs creates independent copies unless ref is used.

## Why It Matters

This example teaches the fundamental difference between value types and reference types in C#.

It also shows boxing/unboxing, which is important both conceptually and for performance reasons.

Understanding these basics will help you avoid subtle bugs, like accidentally working with copies of structs when you expected shared data, or running into hidden performance costs from boxing.

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

