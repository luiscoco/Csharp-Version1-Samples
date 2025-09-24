# C# 1.0 - P05_Indexers Example Explanation

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **indexers, arrays, and ToString() composition** in **C# 1.0**.

---

## Example Code

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
