# C# 1.0 - P10_Attributes Example Explanation

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **custom attributes, AttributeUsage, and reflection** in **C# 1.0**.

---

## Example Code

```csharp
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
}

[MyCustom(Description = "This is a custom attribute on a class.")]
class MyClass
{
    [MyCustom(Description = "This is a custom attribute on a method.")]
    public void MyMethod()
    {
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(MyClass);
        object[] attributes = type.GetCustomAttributes(false);

        foreach (object attribute in attributes)
        {
            if (attribute is MyCustomAttribute)
            {
                MyCustomAttribute myAttribute = (MyCustomAttribute)attribute;
                Console.WriteLine(myAttribute.Description);
            }
        }

        System.Reflection.MethodInfo methodInfo = type.GetMethod("MyMethod");
        object[] methodAttributes = methodInfo.GetCustomAttributes(false);

        foreach (object attribute in methodAttributes)
        {
            if (attribute is MyCustomAttribute)
            {
                MyCustomAttribute myAttribute = (MyCustomAttribute)attribute;
                Console.WriteLine(myAttribute.Description);
            }
        }
    }
}
```

---

## Key Concepts

### 1. Defining a Custom Attribute
```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
}
```
- Attributes must inherit from `System.Attribute`.
- `AttributeUsage` restricts where the attribute can be applied (here: **classes** and **methods**).
- This attribute has a property `Description` to hold metadata.

### 2. Applying the Attribute
```csharp
[MyCustom(Description = "This is a custom attribute on a class.")]
class MyClass
{
    [MyCustom(Description = "This is a custom attribute on a method.")]
    public void MyMethod() { }
}
```
- The attribute is applied to both the class and the method.
- Note: `MyCustom` is shorthand for `MyCustomAttribute`.

### 3. Reading Attributes with Reflection
```csharp
Type type = typeof(MyClass);
object[] attributes = type.GetCustomAttributes(false);
```
- `typeof(MyClass)` returns metadata for `MyClass`.
- `GetCustomAttributes(false)` gets all applied attributes.
- You check for `MyCustomAttribute` and print its description.

Same for the method:
```csharp
MethodInfo methodInfo = type.GetMethod("MyMethod");
object[] methodAttributes = methodInfo.GetCustomAttributes(false);
```

### 4. Output
```
This is a custom attribute on a class.
This is a custom attribute on a method.
```

---

## Why it Matters

- **Custom attributes** let you add metadata to your code in a declarative way.
- **Reflection** lets you inspect attributes at runtime.
- This pattern underpins many .NET frameworks:
  - ASP.NET (`[HttpGet]`, `[Authorize]`)
  - NUnit (`[Test]`)
  - Entity Framework (`[Key]`, `[Table]`)
