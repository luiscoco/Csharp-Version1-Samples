using System;

public enum DaysOfWeek
{
    Sunday,    // 0
    Monday,    // 1
    Tuesday,   // 2
    Wednesday, // 3
    Thursday,  // 4
    Friday,    // 5
    Saturday   // 6
}

public enum Status : byte // Enum with underlying type byte
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}

class Program
{
    static void Main()
    {
        // Using a simple enum
        DaysOfWeek today = DaysOfWeek.Wednesday;
        Console.WriteLine($"Today is: {today}"); // Output: Wednesday
        Console.WriteLine($"Today's int value: {(int)today}"); // Output: 3

        // Casting int to enum
        int dayValue = 1;
        DaysOfWeek tomorrow = (DaysOfWeek)dayValue;
        Console.WriteLine($"Tomorrow is: {tomorrow}"); // Output: Monday

        // Using enum with specified underlying type and values
        Status orderStatus = Status.Approved;
        Console.WriteLine($"Order Status: {orderStatus}"); // Output: Approved
        Console.WriteLine($"Order Status byte value: {(byte)orderStatus}"); // Output: 2

        // Converting enum to string
        string statusString = orderStatus.ToString();
        Console.WriteLine($"Order Status as string: {statusString}"); // Output: Approved

        // Parsing string to enum
        string pendingString = "Pending";
        Status parsedStatus = (Status)Enum.Parse(typeof(Status), pendingString);
        Console.WriteLine($"Parsed Status: {parsedStatus}"); // Output: Pending
    }
}
