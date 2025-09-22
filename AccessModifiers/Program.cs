using System;

// Public class: accessible from anywhere
public class PublicClass
{
    public string PublicField = "Public";
    private string PrivateField = "Private"; // Accessible only within this class
    protected string ProtectedField = "Protected"; // Accessible within this class and derived classes
    internal string InternalField = "Internal"; // Accessible within the same assembly
    protected internal string ProtectedInternalField = "Protected Internal"; // Accessible within the same assembly or derived classes in other assemblies

    public void DisplayPrivateField()
    {
        Console.WriteLine($"Private Field: {PrivateField}");
    }
}

// Derived class in the same assembly
class DerivedClass : PublicClass
{
    public void AccessProtectedField()
    {
        Console.WriteLine($"Protected Field (from DerivedClass): {ProtectedField}");
    }
}

// Another class in the same assembly
class AnotherClass
{
    public void AccessInternalField()
    {
        PublicClass obj = new PublicClass();
        Console.WriteLine($"Internal Field (from AnotherClass): {obj.InternalField}");
        Console.WriteLine($"Protected Internal Field (from AnotherClass): {obj.ProtectedInternalField}");
    }
}

class Program
{
    static void Main()
    {
        PublicClass publicObj = new PublicClass();
        Console.WriteLine($"Public Field: {publicObj.PublicField}");
        publicObj.DisplayPrivateField(); // Access private field via public method

        DerivedClass derivedObj = new DerivedClass();
        derivedObj.AccessProtectedField();

        AnotherClass anotherObj = new AnotherClass();
        anotherObj.AccessInternalField();
    }
}
