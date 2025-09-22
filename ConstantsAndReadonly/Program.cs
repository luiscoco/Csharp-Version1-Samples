using System;

public class MyConstants
{
    // Compile-time constant: value must be set at compile time
    public const double PI = 3.14159;

    // Run-time constant: value can be set at runtime, but only once in the constructor
    public readonly int MaxValue;

    public MyConstants(int maxValue)
    {
        MaxValue = maxValue; // Can be assigned only in constructor
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Value of PI: {MyConstants.PI}");

        MyConstants constants1 = new MyConstants(100);
        Console.WriteLine($"Max Value 1: {constants1.MaxValue}");

        MyConstants constants2 = new MyConstants(200);
        Console.WriteLine($"Max Value 2: {constants2.MaxValue}");

        // MyConstants.PI = 3.14; // Error: A const field cannot be assigned to (except in its declaration)
        // constants1.MaxValue = 150; // Error: A readonly field cannot be assigned to (except in a constructor or variable initializer)
    }
}
