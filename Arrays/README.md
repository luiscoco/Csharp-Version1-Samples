# C# 1.0 - P06_Arrays Example Explanation

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **arrays, foreach loops, the params keyword, and simple joining** in **C# 1.0**.

---

## Example Code

```csharp
using System;

class Program
{
    static void PrintAll(params string[] items)
    {
        foreach (string s in items)
            Console.Write(s + " ");
        Console.WriteLine();
    }

    static void Main()
    {
        // Array creation
        string[] colors = { "red", "green", "blue" };

        // foreach iteration
        foreach (string c in colors)
            Console.WriteLine(c);

        // params usage (variable number of arguments)
        PrintAll("one", "two", "three");
        PrintAll(colors); // can also pass an existing array
    }
}
```

---

## Key Concepts

### 1. Array Creation
- Arrays are fixed-size sequences of elements.
- Created with `new` or initialized directly:

```csharp
int[] numbers = new int[3];       // {0, 0, 0}
string[] words = { "one", "two"}; // {"one", "two"}
```

### 2. foreach Loop
- Cleaner iteration over arrays:

```csharp
foreach (string w in words)
{
    Console.WriteLine(w);
}
```

- The loop variable is read-only inside `foreach`.

### 3. params Keyword
- Allows passing a variable number of arguments as an array.

```csharp
static void PrintAll(params string[] items)
{
    foreach (string s in items)
        Console.WriteLine(s);
}
```

- Usage:
```csharp
PrintAll("one", "two", "three");
PrintAll(new string[] { "four", "five" });
```

### 4. Simple Joining
- In C# 1.0, joining strings usually meant looping:

```csharp
string JoinWithSpaces(string[] items)
{
    string result = "";
    foreach (string s in items)
        result += s + " ";
    return result.Trim();
}
```

- Later versions introduced `string.Join(" ", items)`.

---

## Output Example

```
red
green
blue
one two three 
red green blue 
```

---

## Why it Matters

- Arrays are the foundation of collections in C#.
- `foreach` makes iteration simpler and safer than manual indexing.
- `params` improves usability of methods (e.g., `Console.WriteLine` uses it).
- Joining array content demonstrates aggregation logic, precursor to LINQ.
