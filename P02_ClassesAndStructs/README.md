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
