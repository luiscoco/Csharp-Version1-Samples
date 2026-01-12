using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        try
        {
            int n = int.Parse(input);
            Console.WriteLine("You entered: " + n);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Invalid number format.");
        }
        finally
        {
            Console.WriteLine("Finally block: cleanup code runs here.");
        }
    }
}

