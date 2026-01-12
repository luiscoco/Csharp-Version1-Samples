using System;
using MyCustomNamespace; // Using directive to bring MyCustomNamespace into scope

class Program
{
    static void Main()
    {
        MyClassInNamespace obj = new MyClassInNamespace();
        Console.WriteLine(obj.GetMessage());
    }
}
