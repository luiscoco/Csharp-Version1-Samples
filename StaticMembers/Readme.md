# Static Members in C#

“Now let’s look at an example that demonstrates static classes, static fields, and static methods in C#.

## 1. Static Classes

In the code, we have a class called MyStaticClass, marked with the static keyword.

A static class has these rules:

You cannot create an instance of it (new MyStaticClass() is not allowed).

All of its members must be static.

It’s like a container for global data or utility methods.

In our example:

StaticField is a static field with value 10.

StaticMethod() is a static method that just prints a message.

In Main(), notice we access them directly:

'''csharp
Console.WriteLine(MyStaticClass.StaticField);
MyStaticClass.StaticMethod();
'''

No object creation is needed.

## 2. Static Members in a Regular Class

Now look at MyClassWithStaticMembers. This is a normal class, but it has a static field and static method.

The static field InstanceCount keeps track of how many objects we create.

In the constructor, we do InstanceCount++. Every time a new object is created, this shared counter goes up.

The static method DisplayInstanceCount() shows how many instances exist.

In Main(), we create two objects:

'''csharp
MyClassWithStaticMembers obj1 = new MyClassWithStaticMembers();
MyClassWithStaticMembers obj2 = new MyClassWithStaticMembers();
'''

That increments the counter twice.

When we call:

'''csharp
MyClassWithStaticMembers.DisplayInstanceCount();
'''

The output is:

Number of instances: 2

## 3. Key Difference Between Static and Instance Members

Instance members belong to individual objects. Each object has its own copy.

Static members belong to the class itself. All objects share the same copy.

So in this example:

Each MyClassWithStaticMembers object is unique, but they all update the same shared InstanceCount.

## Summary of Key Concepts

A static class can’t be instantiated; it only contains static members.

A static field is shared across all instances of a class.

A static method can be called without creating an object.

In our example, the static field InstanceCount acts like a global counter for all objects created.

## Why It Matters

Static members are very useful for:

Shared data across objects (like counters, caches, or configuration).

Utility methods that don’t depend on object state (like Math.Sqrt() in C#).

But be careful: too many static members can make code less flexible and harder to test.
