# C# 1.0 - P13_User-Defined Conversions (Implicit vs Explicit)

“Now let’s look at an example that demonstrates how to define custom type conversions in C#.

Normally, C# allows conversions between built-in types (like int to double, or byte to int). 

But with operator overloading, we can also define conversions between our own classes.

This sample uses a real-world scenario: temperature units.

## 1. The Fahrenheit Class

We start with a Fahrenheit class that stores a number of degrees.

Inside it, we define two special operators:

An implicit operator to convert Fahrenheit into Celsius.

An explicit operator to convert Fahrenheit into Kelvin.

Why both? Let’s break it down.

## 2. Implicit Conversion

```csharp
public static implicit operator Celsius(Fahrenheit fahrenheit)
{
    return new Celsius((fahrenheit.Degrees - 32) * 5 / 9);
}
```

The keyword implicit means the conversion happens automatically, without a cast.

For example:

```csharp
Fahrenheit f = new Fahrenheit(212);
Celsius c = f;  // no cast needed
```

In this case, 212°F automatically becomes 100°C.

We use implicit conversion when the conversion is safe and won’t cause data loss or confusion.

## 3. Explicit Conversion

```csharp
public static explicit operator Kelvin(Fahrenheit fahrenheit)
{
    return new Kelvin((fahrenheit.Degrees - 32) * 5 / 9 + 273.15);
}
```

The keyword explicit means the programmer must request the conversion using a cast:

```csharp
Kelvin k = (Kelvin)f;
```

Here, 212°F becomes 373.15K.

We use explicit conversion when the conversion may not always be obvious or could involve potential data loss. 

Requiring a cast makes the programmer aware of what they’re doing.

## 4. The Other Classes (Celsius, Kelvin)

Both Celsius and Kelvin are simple classes with a Degrees property and a ToString() override to display values nicely.

## 5. Putting It Together in Main

```csharp
Fahrenheit fahrenheit = new Fahrenheit(212);
Celsius celsius = fahrenheit;              // implicit
Kelvin kelvin = (Kelvin)fahrenheit;        // explicit
```

The output is:

```csharp
Fahrenheit to Celsius (implicit): 212°F = 100°C
Fahrenheit to Kelvin (explicit): 212°F = 373.15K
```

## Summary of Key Concepts

implicit operator → safe conversions that happen automatically.

explicit operator → conversions that require a cast, used when extra care is needed.

This allows seamless use of custom types in arithmetic, assignment, and method calls.

## Why It Matters

User-defined conversions make custom types feel as natural as built-in ones.

For example:

In graphics programming, you might convert between pixels and points.

In finance, you might convert between dollars and euros.

In scientific apps, you might convert between different measurement units.

With implicit/explicit operators, these conversions become part of the language itself, improving code readability and safety.
