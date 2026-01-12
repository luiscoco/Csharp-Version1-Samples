# Const vs Readonly in C#

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
