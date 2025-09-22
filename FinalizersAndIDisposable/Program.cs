using System;

public class MyResource : IDisposable
{
    private bool disposed = false;
    private string resourceName;

    public MyResource(string name)
    {
        resourceName = name;
        Console.WriteLine($"Resource '{resourceName}' created.");
    }

    // Finalizer (destructor)
    ~MyResource()
    {
        Dispose(false);
    }

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Suppress finalization.
    }

    // Protected virtual method to support Dispose pattern
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
                Console.WriteLine($"Disposing managed resources for '{resourceName}'.");
            }

            // Free unmanaged resources (unmanaged objects).
            Console.WriteLine($"Disposing unmanaged resources for '{resourceName}'.");
            disposed = true;
        }
    }

    public void DoWork()
    {
        if (disposed)
        {
            throw new ObjectDisposedException(resourceName);
        }
        Console.WriteLine($"Resource '{resourceName}' is doing work.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Demonstrating IDisposable (deterministic cleanup) ---");
        // Using statement ensures Dispose is called even if exceptions occur
        using (MyResource res1 = new MyResource("FileHandle1"))
        {
            res1.DoWork();
        } // Dispose() is called automatically here

        Console.WriteLine("\n--- Demonstrating Finalizer (non-deterministic cleanup) ---");
        // Resource created without using statement, relies on GC for cleanup
        CreateAndForgetResource("NetworkConnection1");

        Console.WriteLine("\n--- Forcing Garbage Collection (for demonstration purposes only) ---");
        Console.WriteLine("Calling GC.Collect()...");
        GC.Collect(); // Forces garbage collection
        GC.WaitForPendingFinalizers(); // Waits for finalizers to complete
        Console.WriteLine("GC.Collect() finished.");

        Console.WriteLine("\nProgram finished.");
    }

    static void CreateAndForgetResource(string name)
    {
        MyResource res = new MyResource(name);
        res.DoWork();
        // 'res' goes out of scope, but Dispose() is not explicitly called.
        // Finalizer will eventually clean it up.
    }
}
