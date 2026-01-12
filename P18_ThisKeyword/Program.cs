using System;

public class MyClass
{
    private int value;

    // Constructor: 'this' distinguishes the field from the parameter
    public MyClass(int value)
    {
        this.value = value;
    }

    // Method: 'this' refers to the current instance
    public void DisplayValue()
    {
        Console.WriteLine($"Instance value: {this.value}");
    }

    // Method: 'this' can be passed as an argument
    public void PassSelf(AnotherClass another)
    {
        another.ReceiveInstance(this);
    }

    // Method: 'this' can be used to call other methods of the same instance
    public void ChainCalls()
    {
        Console.WriteLine("Chaining calls...");
        this.DisplayValue(); // Explicitly using 'this'
        // DisplayValue(); // Implicitly using 'this' (same effect)
    }
}

public class AnotherClass
{
    public void ReceiveInstance(MyClass instance)
    {
        Console.WriteLine($"Received instance with value: {instance.value}");
    }
}

class Program
{
    static void Main()
    {
        MyClass obj1 = new MyClass(10);
        obj1.DisplayValue();

        AnotherClass anotherObj = new AnotherClass();
        obj1.PassSelf(anotherObj);

        obj1.ChainCalls();
    }
}
