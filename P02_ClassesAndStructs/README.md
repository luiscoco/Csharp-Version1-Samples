# C# 1.0 - P02_Classes and Structs

This sample shows the core differences between classes and structs in C# 1.0 using simple fields and assignments.

## Key ideas
- **Class**: reference type; variables refer to the same object.
- **Struct**: value type; assignments copy the data.
- **Fields**: store data inside the type.

## Example

```csharp
public class PersonClass
{
    public string Name;
}

public struct PointStruct
{
    public int X, Y;
}

PersonClass person = new PersonClass();
person.Name = "John";

PointStruct point = new PointStruct();
point.X = 10;
point.Y = 20;
```

## What to notice
- `person` is a reference to a class instance.
- `point` is a value with its own copied fields.

## Prompt

```
Generate a simple C# console application that demonstrates the fundamental difference
between a class (reference type) and a struct (value type).

Requirements:
- Use the System namespace.
- Define a public class named PersonClass with a public string field called Name.
- Define a public struct named PointStruct with two public integer fields: X and Y.
- In the Main method:
  - Create an instance of PersonClass.
  - Assign the Name field a sample value (e.g., "John").
  - Create an instance of PointStruct.
  - Assign values to X and Y (e.g., 10 and 20).
- Print the person's name and the point's coordinates to the console
  using Console.WriteLine.
- Keep the code minimal, explicit, and beginner-friendly.
- Do not use advanced features, properties, constructors, or records.
- Ensure the program compiles and runs as a standard .NET console app.
```
