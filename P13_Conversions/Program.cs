using System;

public class Fahrenheit
{
    public double Degrees { get; set; }

    public Fahrenheit(double degrees)
    {
        Degrees = degrees;
    }

    // Implicit conversion from Fahrenheit to Celsius
    public static implicit operator Celsius(Fahrenheit fahrenheit)
    {
        return new Celsius((fahrenheit.Degrees - 32) * 5 / 9);
    }

    // Explicit conversion from Fahrenheit to Kelvin
    public static explicit operator Kelvin(Fahrenheit fahrenheit)
    {
        return new Kelvin((fahrenheit.Degrees - 32) * 5 / 9 + 273.15);
    }

    public override string ToString()
    {
        return $"{Degrees}°F";
    }
}

public class Celsius
{
    public double Degrees { get; set; }

    public Celsius(double degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return $"{Degrees}°C";
    }
}

public class Kelvin
{
    public double Degrees { get; set; }

    public Kelvin(double degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return $"{Degrees}K";
    }
}

class Program
{
    static void Main()
    {
        Fahrenheit fahrenheit = new Fahrenheit(212); // Boiling point of water

        // Implicit conversion
        Celsius celsius = fahrenheit;
        Console.WriteLine($"Fahrenheit to Celsius (implicit): {fahrenheit} = {celsius}");

        // Explicit conversion
        Kelvin kelvin = (Kelvin)fahrenheit;
        Console.WriteLine($"Fahrenheit to Kelvin (explicit): {fahrenheit} = {kelvin}");

        // Example of implicit conversion from int to a custom type (not shown above, but common)
        // MyIntType myInt = 5; // if implicit operator int to MyIntType exists
    }
}
