# C# 1.0 - P09_Attributes

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **custom attributes, AttributeUsage, and reflection** in **C# 1.0**.

Now let’s look at a C# 1.0 example that introduces custom attributes and reflection. 

This is a very powerful feature of .NET, because it lets us attach metadata to our code and later read it at runtime.

## 1. Defining a Custom Attribute

We start with:

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
}
```

Every custom attribute must inherit from System.Attribute.

[AttributeUsage] tells the compiler where this attribute can be applied. 

In this case, we allow it on classes and methods.

Our attribute has a property Description that stores extra metadata.

So we’ve created a blueprint for an attribute.

## 2. Applying the Attribute

Next, we apply it:

```csharp
[MyCustom(Description = "This is a custom attribute on a class.")]
class MyClass
{
    [MyCustom(Description = "This is a custom attribute on a method.")]
    public void MyMethod() { }
}
```

Notice we write [MyCustom(...)] instead of [MyCustomAttribute(...)] 

C# lets us drop the “Attribute” suffix when applying.

We apply it both to the class and to a method.

At this point, we’ve decorated our code with metadata. 

But how do we use it? That’s where reflection comes in.

## 3. Reading Attributes with Reflection

Inside Main(), we do:

```csharp
Type type = typeof(MyClass);
object[] attributes = type.GetCustomAttributes(false);
```

typeof(MyClass) gives us the metadata about the class.

GetCustomAttributes(false) returns an array of all attributes applied to it.

We loop over the attributes, check if they’re of type MyCustomAttribute, 

and then print the Description property.

We do the same with the method:

```csharp
MethodInfo methodInfo = type.GetMethod("MyMethod");
object[] methodAttributes = methodInfo.GetCustomAttributes(false);
```

This lets us inspect the attributes applied directly to the method.

## 4. Output

When we run the program, we see:

This is a custom attribute on a class.

This is a custom attribute on a method.

## Summary of Key Concepts

Defining an attribute: Inherit from System.Attribute, optionally restrict usage with [AttributeUsage].

Applying an attribute: Decorate classes, methods, or other members with [MyCustom(...)].

Reflection: Use typeof, GetCustomAttributes, and MethodInfo to read attributes at runtime.

## Why It Matters

Custom attributes let us add declarative metadata to our code. 

Reflection then allows frameworks or tools to read and act on that metadata.

This idea is the foundation of many .NET frameworks you already use:

ASP.NET MVC: [HttpGet], [Authorize]

NUnit: [Test], [SetUp]

Entity Framework: [Key], [Table]

In other words, attributes are how .NET connects declarative programming 

(annotations) with runtime behavior.

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

- `AttributeUsage` restricts where the attribute can be applied

  (here: **classes** and **methods**).

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

## Prompt

```
Generate a complete C# console application that demonstrates
how to define and consume custom attributes using reflection.

Requirements:
- Language Restriction C# version 1.0.
- Use C#.
- Define a custom attribute class named MyCustomAttribute.
- Decorate the attribute with AttributeUsage so it can be applied
  to both classes and methods.
- The attribute must expose a public string property named Description.

Demonstration code:
- Create a class named MyClass.
- Apply MyCustomAttribute to the class, setting the Description property.
- Inside MyClass, define a public method named MyMethod.
- Apply MyCustomAttribute to the method as well, with a different Description.

Reflection logic:
- In Main(), use reflection to:
  - Retrieve custom attributes applied to MyClass.
  - Detect instances of MyCustomAttribute.
  - Print the Description property to the console.
- Then retrieve the MethodInfo for MyMethod.
- Read its custom attributes in the same way and print their Description values.

Constraints:
- Use only System and System.Reflection.
- Use classic reflection APIs (GetCustomAttributes, typeof, GetMethod).
- Keep the example minimal and educational.
- Place all code in a single file suitable for learning purposes.
- The final program must compile and run as a standard C# console application.
```
