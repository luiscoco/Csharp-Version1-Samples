# C# 1.0 - P10_Namespaces

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **namespaces, using directives, access modifiers, and static member patterns** in **C# 1.0**.

---

## Example Code

```csharp
using System;
using MyCustomNamespace; // Using directive

namespace MyCustomNamespace
{
    public class MyClassInNamespace
    {
        public string GetMessage()
        {
            return "Hello from MyCustomNamespace!";
        }
    }
}

class Program
{
    static void Main()
    {
        MyClassInNamespace obj = new MyClassInNamespace();
        Console.WriteLine(obj.GetMessage());
    }
}
```

---

## Key Concepts

### 1. Namespaces
- Used to **organize code** and avoid name conflicts.
- Example:
```csharp
namespace MyCustomNamespace
{
    public class MyClassInNamespace { }
}
```

### 2. Using Directive
```csharp
using MyCustomNamespace;
```
- Brings the namespace into scope.
- Without it, you'd need to write the fully-qualified name:
```csharp
MyCustomNamespace.MyClassInNamespace obj = new MyCustomNamespace.MyClassInNamespace();
```

### 3. Access Modifiers
- **public** → accessible from anywhere.
- **internal** → accessible only within the same assembly.
- **private** → accessible only inside the declaring class.

Here, `MyClassInNamespace` is `public`, so it can be used from `Program`.

### 4. Static Members Pattern (C# 1.0)
- C# 1.0 did **not** have `static class`.
- Instead, developers wrote classes with only static members:
```csharp
public class Utility
{
    public static void Print(string msg)
    {
        Console.WriteLine(msg);
    }
}
```
Usage:
```csharp
Utility.Print("Hello from a static utility class");
```

---

## Output

```
Hello from MyCustomNamespace!
```

---

## Why it Matters

- **Namespaces** keep code organized and prevent conflicts.

- **Using directives** simplify code by avoiding fully-qualified names.

- **Access modifiers** control visibility and encapsulation.

- **Static member pattern** was the original way to group helper methods

  until `static class` was introduced in later C# versions.

## Prompt

```
You are generating a simple educational C# console application that demonstrates how namespaces work across multiple files.

Project requirements:

1. The project uses standard C# (no top-level statements).
2. The code must be split into two files: MyNamespace.cs and Program.cs.
3. The namespace must be custom and explicitly imported using a `using` directive.

Generate the following files exactly:

--- File: MyNamespace.cs ---
- Declare a namespace called `MyCustomNamespace`.
- Inside the namespace, define a public class named `MyClassInNamespace`.
- The class must contain a public method `GetMessage()` that returns the string:
  "Hello from MyCustomNamespace!"

--- File: Program.cs ---
- Import the `System` namespace.
- Import `MyCustomNamespace` using a `using` directive.
- Define a `Program` class with a `static void Main()` method.
- Inside `Main`, create an instance of `MyClassInNamespace`.
- Call `GetMessage()` and write the result to the console using `Console.WriteLine`.

Important:
- Language restriction C# version 1.0.
- Do not merge files.
- Do not use top-level statements.
- Keep the example simple and readable, suitable for beginners learning namespaces.

Produce only valid C# code for both files.
```
