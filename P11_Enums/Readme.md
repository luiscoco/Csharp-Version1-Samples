# C# 1.0 - P11_Enums

Now let’s look at enums in C#. An enum, short for enumeration, is a way to give meaningful names to numeric constants.

This makes our code easier to read and less error-prone compared to using raw numbers.

## 1. Declaring an Enum

We start with:

```csharp
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
```

By default, enums are backed by integers, starting at 0 and incrementing by 1.

So Sunday = 0, Monday = 1, and so on.

This is useful when working with sets of related constants.

 ## 2. Using an Enum

```csharp
DaysOfWeek today = DaysOfWeek.Wednesday;
Console.WriteLine($"Today is: {today}");
Console.WriteLine($"Today's int value: {(int)today}");
```

Here today is set to Wednesday.

Printing today shows the name: Wednesday.

Casting it to (int) gives the underlying value: 3.

## 3. Casting from Int to Enum

```csharp
int dayValue = 1;
DaysOfWeek tomorrow = (DaysOfWeek)dayValue;
Console.WriteLine($"Tomorrow is: {tomorrow}");
```

Enums are really just numbers with labels.

We can cast 1 into DaysOfWeek, and it becomes Monday.

## 4. Enums with Custom Underlying Types

We can also define enums with a specific base type:

```csharp
public enum Status : byte
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}
```

Here, Status uses byte instead of the default int.

This saves memory if we know values will always be small.

Example:

```csharp
Status orderStatus = Status.Approved;
Console.WriteLine(orderStatus);         // Approved
Console.WriteLine((byte)orderStatus);   // 2
```

## 5. Converting Enum to String

```csharp
string statusString = orderStatus.ToString();
Console.WriteLine(statusString); // "Approved"
```

Every enum can be converted into its name as a string.

## 6. Parsing String Back to Enum

```csharp
string pendingString = "Pending";
Status parsedStatus = (Status)Enum.Parse(typeof(Status), pendingString);
Console.WriteLine(parsedStatus); // Pending
```

Enum.Parse lets us take a string and turn it back into an enum.

This is common when reading data from files, databases, or user input.

## Summary of Key Concepts

Enum = a set of named constants backed by numbers.

Default underlying type is int, but you can specify others (like byte).

You can cast between enums and numbers.

You can convert enums to strings and parse strings back into enums.

## Why It Matters

Enums make code more readable and less error-prone.

Instead of writing:

```csharp
if (status == 2) ...
```

we can write:

```csharp
if (status == Status.Approved) ...
```

which is much clearer and safer.

## Prompt 

```
You are generating a simple C# console application that demonstrates how enums work in C#.

Project constraints:
- Language Restriction C# version 1.0.
- Use classic C# syntax (no top-level statements).
- Everything must be contained in a single Program.cs file.
- The code should be beginner-friendly and heavily illustrative.
- Do not introduce additional abstractions or helper methods.

Generate the following code structure:

1. Import the System namespace.

2. Declare a public enum named DaysOfWeek:
   - Use the default underlying type (int).
   - Define the members in this order:
     Sunday = 0
     Monday = 1
     Tuesday = 2
     Wednesday = 3
     Thursday = 4
     Friday = 5
     Saturday = 6
   - Add inline comments showing the numeric values.

3. Declare a second public enum named Status:
   - Explicitly specify the underlying type as byte.
   - Define the members with explicit values:
     Pending = 1
     Approved = 2
     Rejected = 3
   - Add a comment explaining the underlying type choice.

4. Define a Program class with a static void Main() method.

Inside Main(), demonstrate the following enum operations with Console.WriteLine output:

- Assign an enum value (DaysOfWeek.Wednesday) to a variable and print:
  - The enum value
  - Its underlying integer value using a cast

- Cast an int value (1) to DaysOfWeek and print the result.

- Assign a Status enum value (Approved) and print:
  - The enum value
  - Its underlying byte value using a cast

- Convert the Status enum to a string using ToString() and print it.

- Parse a string ("Pending") into a Status enum using Enum.Parse and print the result.

Important rules:
- Use explicit casts where appropriate.
- Keep comments concise and educational.
- Produce only valid C# code.
- Do not add explanations outside the code.

The final result should be a single, complete Program.cs file ready to run.
```
