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
