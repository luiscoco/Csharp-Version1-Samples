# C# 1.0 "Hello World"

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

## Prompt for Coding AI Agent

```
You are the VS Code Codex programming agent.

Repo / target:
- GitHub repo: https://github.com/luiscoco/Csharp-Version1-Samples
- Focus folder: /P01_HelloWorld

Goal:
Turn P01_HelloWorld into a polished, self-contained “Hello World” C# sample that:
1) Builds and runs reliably with the modern .NET SDK,
2) Preserves the original intent of a C# v1-style minimal sample,
3) Adds developer-friendly documentation and (optionally) a modern equivalent version for comparison.

Hard requirements:
- Do NOT change the meaning of the original sample.
- Keep an “original” version intact (or as close as possible), and put any modernization in a separate variant.
- Prefer deterministic builds and simple commands (dotnet CLI).
- Output must be runnable on a clean machine with .NET SDK installed.

Work plan:
1) Inspect the repository structure and the contents of /P01_HelloWorld.
   - Identify whether it is: a raw .cs file, a legacy .csproj, a .sln, or just a snippet.
   - Identify expected output and any missing build metadata.

2) Create/normalize build scaffolding:
   - If there is no project file, create one using: `dotnet new console`
   - Place the original code in a clearly labeled location:
     - Option A: keep as the main Program.cs but comment/document it as “Original”
     - Option B (preferred): keep original in /original and create a minimal runner that references it
   - Ensure `dotnet build` and `dotnet run` work from within P01_HelloWorld.

3) Add documentation:
   - Create/upgrade README.md inside /P01_HelloWorld with:
     - What this sample is
     - How to build/run
     - What “C# v1 style” means in this context (briefly)
     - Expected output
     - Folder layout explanation
   - Add a short “Troubleshooting” section (SDK missing, wrong directory, etc.)

4) Add a modern comparison variant (separate, optional but recommended):
   - Create a sibling folder inside P01_HelloWorld, e.g.:
     - /modern (or /P01_HelloWorld.Modern)
   - Implement the modern version using top-level statements and current conventions.
   - Add a short note in README comparing “original vs modern” with a few bullets.

5) Quality checks:
   - Run `dotnet --info` (only if needed) and ensure the project targets an LTS framework (e.g., net8.0).
   - Run:
     - `dotnet restore`
     - `dotnet build`
     - `dotnet run`
   - Ensure output matches the README exactly.

Deliverables (must commit as changes in the workspace):
- P01_HelloWorld builds/runs with dotnet CLI
- README.md updated/created with clear instructions
- Original sample preserved
- Optional modern variant added cleanly (no breaking changes to original)

Acceptance criteria:
- From the P01_HelloWorld directory:
  - `dotnet build` succeeds
  - `dotnet run` prints the expected Hello World message
- README contains exact commands and expected output
- The “original” code path still looks and reads like a classic minimal C# sample (no unnecessary modern constructs in that version)

Implementation notes:
- If the original sample was written for very old tooling (pre-SDK-style projects), do NOT try to recreate that old toolchain.
  Instead: keep the code semantics and adapt only the project scaffolding needed to run it today.
- Keep changes minimal and well-explained in commit messages or in README notes.

Now proceed: open the repository folder, inspect P01_HelloWorld, implement the plan, and run the checks.
When finished, summarize what you changed and provide the exact run commands.
```
