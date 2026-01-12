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
