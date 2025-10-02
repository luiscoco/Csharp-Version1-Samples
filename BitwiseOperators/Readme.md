Bitwise Operators and [Flags] Enums

“Now let’s look at a C# example that demonstrates bitwise operators and the special use of enums with the [Flags] attribute. These concepts are important because they let us work directly with bits, which is very efficient and commonly used for permissions, settings, or hardware-level programming.

1. Bitwise Operators on Integers

We start with two integers:

int a = 5;  // binary 0101
int b = 3;  // binary 0011


Let’s go through the operations step by step:

AND (&): Keeps only the bits that are 1 in both numbers.

0101
0011
----
0001 = 1


OR (|): Keeps the bits that are 1 in either number.

0101
0011
----
0111 = 7


XOR (^): Keeps the bits that are 1 in exactly one of the numbers.

0101
0011
----
0110 = 6


NOT (~): Flips all the bits.
For a = 5 (binary 0101), the result is all bits flipped → which becomes -6 in signed 32-bit integers.

Left Shift (<<): Shifts bits to the left, adding zeros on the right.
5 << 1 = 10 (0101 → 1010).

Right Shift (>>): Shifts bits to the right, discarding bits on the right.
5 >> 1 = 2 (0101 → 0010).

These operators give us precise control over binary data.

2. Enums with [Flags]

Now let’s connect this to a practical use case: permissions.

We define an enum like this:

[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,        // 0001
    Write = 2,       // 0010
    Execute = 4,     // 0100
    Delete = 8,      // 1000
    All = Read | Write | Execute | Delete
}


The [Flags] attribute tells the compiler and developers that this enum is meant to be combined with bitwise operations.

For example:

Permissions userPermissions = Permissions.Read | Permissions.Execute;


This means the user has both Read and Execute permissions.

When we print it, the output is:

Read, Execute

3. Checking, Adding, and Removing Flags

Check:

if ((userPermissions & Permissions.Read) == Permissions.Read)
    Console.WriteLine("User has Read permission.");


We use & to test if a specific bit is set.

Add:

userPermissions |= Permissions.Write;


Now the user has Read, Execute, Write.

Remove:

userPermissions &= ~Permissions.Execute;


Now Execute is gone, leaving Read, Write.

✅ Summary of Key Concepts

Bitwise operators let us manipulate individual bits: AND, OR, XOR, NOT, shifts.

[Flags] enums are designed for combining values with bitwise operators.

We can check, add, and remove flags to represent things like permissions.

💡 Why It Matters
This is a common pattern in real-world programming:

File systems use it for access permissions.

Operating systems use it for process flags.

Game engines use it for toggling multiple settings at once.

It’s efficient, compact, and very powerful.
