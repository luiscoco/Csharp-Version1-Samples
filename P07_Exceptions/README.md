# C# 1.0 - P07_Exceptions

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **exceptions, try/catch/finally, parsing with int.Parse, handling FormatException, and cleanup in finally** in **C# 1.0**.

---

## Example Code

```csharp
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
```

---

## Key Concepts

### 1. try / catch / finally
- **try** → contains code that may throw exceptions.
- **catch** → handles exceptions of a specific type.
- **finally** → always runs, whether or not an exception occurred.

### 2. int.Parse
- Converts a string into an integer.
- Example:
```csharp
int n = int.Parse("123"); // returns 123
int m = int.Parse("abc"); // throws FormatException
```

### 3. FormatException
- Thrown when input cannot be parsed to an integer.
- Example: trying to parse `"abc"` as an int.

### 4. finally Block
- Always executes, regardless of whether an exception was thrown.
- Used for cleanup tasks like closing files, disposing objects, releasing resources.

---

## Example Runs

Input:
```
123
```
Output:
```
You entered: 123
Finally block: cleanup code runs here.
```

Input:
```
abc
```
Output:
```
Error: Invalid number format.
Finally block: cleanup code runs here.
```

---

## Why it Matters

- Exceptions are **runtime errors** that must be handled properly.
- `try/catch/finally` provides a safe structure for handling errors.
- `int.Parse` demonstrates how exceptions can arise from invalid input.
- `finally` ensures that important cleanup code always runs.

## Prompt

```
Create a minimal C# console application (.NET) that demonstrates structured exception handling using try, catch, and finally.

Requirements:
- Language Restriction C# version 1.0
- Use `System` namespace
- Define a `Program` class with a `Main` method
- Prompt the user with: "Enter a number: "
- Read input from the console as a string
- Inside a `try` block:
  - Convert the string input to an integer using `int.Parse`
  - Print the parsed integer using: "You entered: {number}"
- Add a `catch` block that handles `FormatException`
  - Display the message: "Error: Invalid number format."
- Add a `finally` block that always executes
  - Display the message: "Finally block: cleanup code runs here."

Output the full, complete C# source file only. Do not add explanations or comments outside the code.
```
