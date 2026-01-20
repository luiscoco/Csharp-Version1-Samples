# C# 1.0 - P12_Const vs Readonly

Now let’s look at an example that demonstrates the difference between const and readonly fields in C#.

Both are used to represent values that cannot be changed once set, but they work in different ways.

## 1. Const Fields (Compile-Time Constants)

In the class MyConstants, we have:

```csharp
public const double PI = 3.14159;
```

A const field is a compile-time constant.

Its value must be known and assigned at the time of declaration.

Once set, it can never change.

That’s why we can directly access it as:

```csharp
Console.WriteLine(MyConstants.PI);
```

And if we try to reassign it:

```csharp
MyConstants.PI = 3.14; // ❌ Error
```

the compiler won’t allow it.

Const is typically used for values like mathematical constants, fixed conversions, or system defaults that will never change.

## 2. Readonly Fields (Run-Time Constants)

Now look at the field:

```csharp
public readonly int MaxValue;
```

A readonly field can only be assigned once, but the assignment can happen either at declaration or inside the constructor.

This means each object can have a different value for the same readonly field.

In our constructor:

```csharp
public MyConstants(int maxValue)
{
    MaxValue = maxValue;
}
```

When we create objects:

```csharp
MyConstants constants1 = new MyConstants(100);
Console.WriteLine(constants1.MaxValue); // 100

MyConstants constants2 = new MyConstants(200);
Console.WriteLine(constants2.MaxValue); // 200
```

Here we see that MaxValue can vary per instance, but once the object is created, it cannot be modified.

If we try:

```csharp
constants1.MaxValue = 150; // ❌ Error
```

we’ll get a compiler error.

## 3. Key Difference: Const vs Readonly

const → must be assigned at declaration, value is the same for all objects, and it’s baked into the compiled code.

readonly → can be assigned at declaration or in a constructor, and allows different values for different objects.

## Summary of Key Concepts

Const = compile-time constant, fixed forever, same for all objects.

Readonly = run-time constant, assigned once per object, can vary between instances.

Both protect against modification after initialization, but readonly is more flexible.

##  Why It Matters

Use const for universal, unchanging values (like PI, DaysInWeek, MaxByteValue).

Use readonly for values that should not change after construction but may differ between objects (like configuration limits, IDs, or instance-specific settings).

## Prompt

```
You are generating a simple C# console application that explains the difference between `const` and `readonly` fields.

Project constraints:
- Language Restriction C# version 1.0.
- Use classic C# syntax (no top-level statements).
- Place everything in a single Program.cs file.
- The code should be educational and suitable for beginners.
- Do not introduce additional helper classes or methods beyond what is required.

Generate the following structure:

1. Import the System namespace.

2. Declare a public class named MyConstants.

   Inside MyConstants:
   - Declare a public `const double` named PI with the value 3.14159.
     Add a comment explaining that `const` values are compile-time constants.

   - Declare a public `readonly int` field named MaxValue.
     Add a comment explaining that `readonly` fields are runtime constants.

   - Implement a public constructor that takes an int parameter named maxValue
     and assigns it to MaxValue.
     Add a comment explaining that assignment is allowed only in the constructor.

3. Declare a Program class with a static void Main() method.

Inside Main():
- Print the value of PI using the class name.
- Create two different instances of MyConstants with different MaxValue values
  (for example 100 and 200).
- Print MaxValue for each instance to show that readonly fields can vary per object.

- Include commented-out code lines showing:
  - An invalid attempt to reassign PI
  - An invalid attempt to reassign MaxValue after construction
  Each commented line must include an explanatory comment about the compile-time error.

Rules:
- Keep comments short and educational.
- Do not include explanations outside the code.
- Produce only valid C# code ready to compile and run.

The result should be a single, complete Program.cs file.
```
