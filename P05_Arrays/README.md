# C# 1.0 - P05_Arrays

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **arrays, foreach loops, the params keyword, and simple joining** in **C# 1.0**.

Arrays, Foreach, Params, and Joining

“Now let’s look at another early C# example, which demonstrates arrays, foreach loops, the params keyword, and simple string joining.

These were foundational in C# 1.0 and remain important concepts today.

## 1. Array Creation

An array is a fixed-size collection of elements of the same type.

You can create arrays in two main ways:

```csharp
int[] numbers = new int[3];       // creates {0, 0, 0}
string[] words = { "one", "two"}; // creates {"one", "two"}
```

In our example, we create a string array of colors:

```csharp
string[] colors = { "red", "green", "blue" };
```

This array has three elements.

## 2. Foreach Loop

To iterate over an array, we can use the foreach loop:

```csharp
foreach (string c in colors)
    Console.WriteLine(c);
```

The loop automatically steps through each element of the array — c takes on the values "red", "green", "blue".

Key detail: the loop variable is read-only inside foreach. That means you can read values, but you can’t assign to c.

Output:

red
green
blue

## 3. The params Keyword

Next, we have a method that demonstrates params:

```csharp
static void PrintAll(params string[] items)
{
    foreach (string s in items)
        Console.Write(s + " ");
    Console.WriteLine();
}
```

The params keyword allows a method to accept a variable number of arguments.
That means we can call it in two ways:

```csharp
PrintAll("one", "two", "three");   // multiple arguments
PrintAll(colors);                  // an existing array
```

The output is:

one two three
red green blue

This feature is very practical — for example, Console.WriteLine itself uses params internally.

 ##4. Simple Joining (Pre–C# 2.0)

In modern C#, we would just write:

```csharp
string.Join(" ", items);
```

But in C# 1.0, we had to manually loop and concatenate strings:

```csharp
string JoinWithSpaces(string[] items)
{
    string result = "";
    foreach (string s in items)
        result += s + " ";
    return result.Trim();
}
```

This was the manual way of joining array content, and it laid the groundwork for later improvements like string.Join and eventually LINQ.

## Summary of Key Concepts

Arrays → fixed-size sequences of elements.

foreach → clean, safe way to loop over an array.

params → allows passing a variable number of arguments without explicitly creating an array.

Joining → in C# 1.0, done manually with loops; later simplified with built-in methods.

## Why It Matters

Arrays were the foundation for all later collection types in C#.

foreach made iteration safer and simpler than indexing.

params improved method usability — you’ll see it in many built-in .NET methods.

Manual joining shows how developers used to solve aggregation tasks before LINQ and modern APIs.

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
