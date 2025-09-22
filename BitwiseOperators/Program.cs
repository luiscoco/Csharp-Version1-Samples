using System;

[Flags] // Recommended for enums used with bitwise operations
public enum Permissions
{
    None = 0,
    Read = 1,        // 0001
    Write = 2,       // 0010
    Execute = 4,     // 0100
    Delete = 8,      // 1000
    All = Read | Write | Execute | Delete // 1111
}

class Program
{
    static void Main()
    {
        int a = 5;  // 0101 in binary
        int b = 3;  // 0011 in binary

        // Bitwise AND (&)
        int resultAnd = a & b; // 0001 (1)
        Console.WriteLine($"Bitwise AND ({a} & {b}): {resultAnd}");

        // Bitwise OR (|)
        int resultOr = a | b; // 0111 (7)
        Console.WriteLine($"Bitwise OR ({a} | {b}): {resultOr}");

        // Bitwise XOR (^)c
        int resultXor = a ^ b; // 0110 (6)
        Console.WriteLine($"Bitwise XOR ({a} ^ {b}): {resultXor}");

        // Bitwise NOT (~)
        int resultNotA = ~a; // 11111111111111111111111111111010 (-6 for 32-bit signed int)
        Console.WriteLine($"Bitwise NOT (~{a}): {resultNotA}");

        // Left Shift (<<)
        int resultLeftShift = a << 1; // 1010 (10)
        Console.WriteLine($"Left Shift ({a} << 1): {resultLeftShift}");

        // Right Shift (>>)
        int resultRightShift = a >> 1; // 0010 (2)
        Console.WriteLine($"Right Shift ({a} >> 1): {resultRightShift}");

        Console.WriteLine("\n--- Enum Bitwise Operations ---");

        Permissions userPermissions = Permissions.Read | Permissions.Execute; // Read and Execute
        Console.WriteLine($"User Permissions: {userPermissions}"); // Output: Read, Execute

        // Check if user has Read permission
        if ((userPermissions & Permissions.Read) == Permissions.Read)
        {
            Console.WriteLine("User has Read permission.");
        }

        // Check if user has Write permission (should be false)
        if ((userPermissions & Permissions.Write) == Permissions.Write)
        {
            Console.WriteLine("User has Write permission.");
        }
        else
        {
            Console.WriteLine("User does NOT have Write permission.");
        }

        // Add Write permission
        userPermissions |= Permissions.Write;
        Console.WriteLine($"User Permissions after adding Write: {userPermissions}"); // Output: Read, Write, Execute

        // Remove Execute permission
        userPermissions &= ~Permissions.Execute;
        Console.WriteLine($"User Permissions after removing Execute: {userPermissions}"); // Output: Read, Write
    }
}
