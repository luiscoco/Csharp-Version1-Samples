# Properties in C#

“Let’s look at a simple example that introduces properties in C#.

## 1. Fields and Encapsulation

In the Person class, we have a private field:

'''csharp
private string name;
'''

This field stores the person’s name, but because it’s marked private, it cannot be accessed directly from outside the class.

This is called encapsulation: hiding internal data so it’s not exposed directly.

## 2. Properties with Get and Set

To safely expose the name field, we use a property:

'''csharp
public string Name
{
    get { return name; }
    set { name = value; }
}
'''

Here:

The get accessor returns the value of the private field.

The set accessor updates the private field.

This way, code outside the class can read and write the value, but only through this controlled gateway.

In C# 1.0, properties had to be written with explicit backing fields. (Later versions introduced auto-properties, which made this much shorter.)

## 3. Using the Property

In the Main() method, we create a Person object:

'''csharp
Person person = new Person();
person.Name = "Alice";
'''

Here we’re not directly accessing the private field — we’re using the property’s set accessor.

When we print:

'''csharp
Console.WriteLine("Person's Name: " + person.Name);
'''

the runtime calls the property’s get accessor and retrieves the value.

The output is:

Person's Name: Alice

## Summary of Key Concepts

Fields store the actual data.

Properties provide controlled access to fields with get and set.

Encapsulation keeps data safe and flexible, since we could add validation later without changing how the class is used.

## Why It Matters

Properties are the standard way in C# to expose fields.

They give us the convenience of field-like syntax (person.Name) while keeping the safety and flexibility of methods.
