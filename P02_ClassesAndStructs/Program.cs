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
