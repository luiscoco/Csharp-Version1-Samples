# C# 1.0 - P22_ControlFlowBasics

Now we’re going to look at an example that demonstrates the basic control flow statements in C#.

These are the building blocks that control the order in which code runs.

## 1. If–Else If–Else

We start with a simple decision:

```csharp
if (number > 10)
    Console.WriteLine("Number is greater than 10");
else if (number < 10)
    Console.WriteLine("Number is less than 10");
else
    Console.WriteLine("Number is 10");
```

if runs a block when the condition is true.

else if checks another condition.

else runs when none of the above are true.

So here, since number = 10, the output is:

```
Number is 10
```

## 2. Switch Statement

Next, we see a switch:

```csharp
switch (day)
{
    case 1: Console.WriteLine("Monday"); break;
    case 2: Console.WriteLine("Tuesday"); break;
    case 3: Console.WriteLine("Wednesday"); break;
    default: Console.WriteLine("Another day"); break;
}
```

The value of day is compared against each case.

The break statement exits the switch after a match.

If nothing matches, the default block runs.

Here, day = 3, so it prints:

Wednesday

## 3. While Loop

```csharp
int i = 0;
while (i < 3)
{
    Console.WriteLine($"While loop iteration: {i}");
    i++;
}
```

A while loop checks the condition first, then runs the body.

This prints iterations for 0, 1, 2.

## 4. Do–While Loop

```csharp
int j = 0;
do
{
    Console.WriteLine($"Do-while loop iteration: {j}");
    j++;
} while (j < 3);
```

A do–while loop always runs at least once, because the condition is checked at the end.

It prints iterations for 0, 1, 2.

## 5. For Loop

```csharp
for (int k = 0; k < 3; k++)
{
    Console.WriteLine($"For loop iteration: {k}");
}
```

A for loop is compact: it has initialization (int k = 0), condition (k < 3), and increment (k++) in one line.

Runs for 0, 1, 2.

## 6. Foreach Loop

```csharp
int[] numbers = { 1, 2, 3 };
foreach (int num in numbers)
{
    Console.WriteLine($"Foreach loop number: {num}");
}
```

foreach is used to iterate directly over arrays or collections.

It’s simpler and safer than using indexes.

Prints each number: 1, 2, 3.

## 7. Break and Continue

```csharp
for (int l = 0; l < 5; l++)
{
    if (l == 2) continue; // skip iteration
    if (l == 4) break;    // exit loop
    Console.WriteLine(l);
}
```

continue skips the rest of the loop body for that iteration.

break exits the loop entirely.

So this prints 0, 1, 3 and stops at 4.

## 8. Goto Statement

```csharp
int m = 0;
MyLabel:
    Console.WriteLine($"Goto loop iteration: {m}");
    m++;
    if (m < 3)
        goto MyLabel;
```

goto jumps directly to a label in the code.

It prints 0, 1, 2.

While legal in C#, it’s discouraged in modern programming because it can make code hard to read.

## Summary of Key Concepts

if / else if / else → conditional branching.

switch → multiple choice branching.

while → loop with pre-condition.

do–while → loop with post-condition (runs at least once).

for → compact loop with initializer, condition, increment.

foreach → easy iteration over arrays/collections.

break / continue → control loop execution.

goto → direct jump (use sparingly).

## Why It Matters

These control flow statements are the core tools to direct program execution. 

Every program you’ll write in C# will use these in some form, whether for making decisions, iterating collections, or controlling loops.
