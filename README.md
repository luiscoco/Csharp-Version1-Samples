# C# Version 1 Features

This repository contains examples of features available in C# version 1. Each feature is in its own project.

## HelloWorld

The classic "Hello, World!" program. It demonstrates the basic structure of a C# console application.

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}
```

## Arrays

Demonstrates the declaration, initialization, and iteration of an array.

```csharp
using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

        Console.WriteLine("Elements in the array:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
```

## Classes and Structs

Shows the definition of a simple class (`PersonClass`) and a struct (`PointStruct`) and how to create instances of them.

```csharp
using System;

public class PersonClass
{
    public string Name;
}

public struct PointStruct
{
    public int X, Y;
}

class Program
{
    static void Main()
    {
        PersonClass person = new PersonClass();
        person.Name = "John";

        PointStruct point = new PointStruct();
        point.X = 10;
        point.Y = 20;

        Console.WriteLine("Person's Name: " + person.Name);
        Console.WriteLine("Point's Coordinates: (" + point.X + ", " + point.Y + ")");
    }
}
```

## Interfaces

Illustrates the use of interfaces for defining a contract that classes can implement.

```csharp
using System;

interface IShape
{
    void Draw();
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a circle.");
    }
}

class Program
{
    static void Main()
    {
        IShape shape = new Circle();
        shape.Draw();
    }
}
```

## Properties

Demonstrates how to use properties to encapsulate a private field.

```csharp
using System;

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();
        person.Name = "Alice";
        Console.WriteLine("Person's Name: " + person.Name);
    }
}
```

## Delegates

Shows how to declare, instantiate, and use a delegate.

```csharp
using System;

delegate void MyDelegate(string message);

class Program
{
    static void Main()
    {
        MyDelegate del = new MyDelegate(MethodA);
        del("Hello from Delegate!");
    }

    static void MethodA(string message)
    {
        Console.WriteLine(message);
    }
}
```

## Events

Demonstrates the use of events for communication between objects.

```csharp
using System;

public delegate void MyEventHandler(object sender, EventArgs e);

public class MyEventSource
{
    public event MyEventHandler MyEvent;

    public void RaiseEvent()
    {
        OnMyEvent(EventArgs.Empty);
    }

    protected virtual void OnMyEvent(EventArgs e)
    {
        if (MyEvent != null)
        {
            MyEvent(this, e);
        }
    }
}

class Program
{
    static void Main()
    {
        MyEventSource source = new MyEventSource();
        source.MyEvent += new MyEventHandler(HandleEvent);
        source.RaiseEvent();
    }

    static void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event handled!");
    }
}
```

## Attributes

Shows how to create and use custom attributes.

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