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
