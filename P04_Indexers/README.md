# C# 1.0 - P04_Indexers Example Explanation

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **indexers, arrays, and ToString() composition** in **C# 1.0**.

---

This sample demonstrates:

Indexers (this[...]) → allow objects to be indexed like arrays.

Arrays → storing collections of items.

ToString() composition → building a string representation that uses the indexer/array data.

## 1. What’s an Indexer?

An indexer lets an object be accessed using array-like syntax.

Instead of:

```
myCollection.GetItem(0);
```

you can write:

```
myCollection[0];
```

The keyword is this[...].

Example:

```
public class MyCollection
{
    private string[] data = new string[3];

    // Indexer
    public string this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}
```

Now you can write:

```
MyCollection c = new MyCollection();
c[0] = "Hello";
Console.WriteLine(c[0]); // "Hello"
```

## 2. Arrays Inside

Typically, the indexer is backed by an array (or list).
In C# 1.0, the natural choice was a fixed array.

## 3. ToString() Composition

Often, the class overrides ToString() to produce a readable summary of its data.
For example, concatenating all items in the array:

```
public override string ToString()
{
    return string.Join(", ", data);
}
```

## Complete Example Code

```csharp
using System;

public class WeekDays
{
    private string[] days = 
        { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

    // Custom indexer
    public string this[int index]
    {
        get { return days[index]; }
        set { days[index] = value; }
    }

    // Override ToString to compose all days into one string
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < days.Length; i++)
        {
            result += days[i] + " ";
        }
        return result.Trim();
    }
}

class Program
{
    static void Main()
    {
        WeekDays week = new WeekDays();

        // Access via indexer (like an array)
        Console.WriteLine(week[0]);   // Mon

        // Modify via indexer
        week[0] = "Monday";

        // ToString() shows all days
        Console.WriteLine(week);
    }
}
```

---

## Key Concepts

### 1. Indexer (`this[int]`)
- Lets you use objects with **array-like syntax**.
- Syntax: `public <type> this[int index] { get; set; }`.

### 2. Backing Array
- The indexer is implemented with a `string[]` that stores weekday names.

### 3. ToString() Composition
- Loops through the array and returns all items as a single string.

```csharp
public override string ToString()
{
    string result = "";
    for (int i = 0; i < days.Length; i++)
    {
        result += days[i] + " ";
    }
    return result.Trim();
}
```

### 4. Encapsulation
- The indexer could be extended to validate indices (e.g., range checking).

---

## Output Example

```
Mon
Monday Tue Wed Thu Fri Sat Sun
```

---

## Why it Matters

- Indexers make objects more **intuitive to use**, like arrays or lists.
- They are widely used in .NET collections (`List<T>`, `Dictionary<K,V>`, etc.).
- `ToString()` provides a simple way to visualize object contents.
