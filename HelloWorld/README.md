# C# 1.0 Mini-Sample Explanation

This example demonstrates some of the fundamental concepts of **C# 1.0**:

```csharp
static void Print(string s)  { Console.WriteLine(s); }
static void Print(int n)     { Console.WriteLine(n); }

static void Main() 
{ 
    for (int i = 0; i < 3; i++) 
        Print("Hello " + i); 
}
```

---

## Concepts Covered

### 1. Console I/O
- `Console.WriteLine(...)` is used for **output** to the console.
- This program wraps it with `Print(...)` methods.

### 2. Methods
- `static void Print(string s)` takes a string and prints it.
- `static void Print(int n)` takes an integer and prints it.

### 3. Overloading
- C# allows multiple methods with the **same name** but different parameter types.
- Example:
  ```csharp
  Print("Hi!");  // calls Print(string)
  Print(42);     // calls Print(int)
  ```

### 4. For Loop
- `for (int i = 0; i < 3; i++)` repeats code with a counter (`i`).
- Runs with `i = 0, 1, 2`.

### 5. String Concatenation
- `"Hello " + i` joins a string with an integer.
- The integer is automatically converted to a string.

### 6. Program Output
When you run the program, the output is:

```
Hello 0
Hello 1
Hello 2
```

---

## Concepts Demonstrated
- Console I/O → `Console.WriteLine`
- Methods → `Print(...)`
- Overloading → multiple methods with same name
- For loops → repeating logic
- String concatenation → `"Hello " + i`
