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
