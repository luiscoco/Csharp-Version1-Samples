using System;

public static class MyStaticClass
{
    public static int StaticField = 10;

    public static void StaticMethod()
    {
        Console.WriteLine("This is a static method.");
    }
}

public class MyClassWithStaticMembers
{
    public static int InstanceCount = 0;

    public MyClassWithStaticMembers()
    {
        InstanceCount++;
    }

    public static void DisplayInstanceCount()
    {
        Console.WriteLine($"Number of instances: {InstanceCount}");
    }
}

class Program
{
    static void Main()
    {
        // Accessing static members of a static class
        Console.WriteLine($"Static field in MyStaticClass: {MyStaticClass.StaticField}");
        MyStaticClass.StaticMethod();

        // Accessing static members of a non-static class
        MyClassWithStaticMembers obj1 = new MyClassWithStaticMembers();
        MyClassWithStaticMembers obj2 = new MyClassWithStaticMembers();
        MyClassWithStaticMembers.DisplayInstanceCount();
    }
}
