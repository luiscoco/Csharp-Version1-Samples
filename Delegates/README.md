# C# 1.0 - P07_Delegates Example Explanation

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **delegates, events, and the subscribe/unsubscribe pattern** in **C# 1.0**.

---

## Example Code

```csharp
using System;

// Step 1: Declare a delegate type
public delegate void NotifyHandler(string message);

// Step 2: Publisher with an event
public class Publisher
{
    public event NotifyHandler OnNotify;

    public void DoSomething()
    {
        Console.WriteLine("Publisher: Doing something...");
        RaiseEvent("Event triggered!");
    }

    private void RaiseEvent(string msg)
    {
        if (OnNotify != null)   // Check for subscribers
            OnNotify(msg);      // Raise event
    }
}

// Step 3: Subscriber methods
public class Subscriber
{
    public void HandleNotification(string msg)
    {
        Console.WriteLine("Subscriber received: " + msg);
    }
}

class Program
{
    static void Main()
    {
        Publisher pub = new Publisher();
        Subscriber sub = new Subscriber();

        // Subscribe
        pub.OnNotify += sub.HandleNotification;

        pub.DoSomething();

        // Unsubscribe
        pub.OnNotify -= sub.HandleNotification;
    }
}
```

---

## Key Concepts

### 1. Delegates
- A **delegate** is a type-safe function pointer.
- Defines a method signature, e.g. `public delegate void NotifyHandler(string msg);`.

### 2. Events
- An **event** is a delegate field with restricted access.
- Only the class that declares the event can raise it.
- Other classes can **subscribe (`+=`)** or **unsubscribe (`-=`)**.

### 3. Subscribing / Unsubscribing
```csharp
pub.OnNotify += sub.HandleNotification; // subscribe
pub.OnNotify -= sub.HandleNotification; // unsubscribe
```

### 4. Raising Events
- Check if the event is not null (meaning there are subscribers).
- Invoke it like a method to notify all subscribers.

```csharp
if (OnNotify != null)
    OnNotify("Event triggered!");
```

---

## Output Example

```
Publisher: Doing something...
Subscriber received: Event triggered!
```

---

## Why it Matters

- Delegates and events are the **foundation of event-driven programming** in C#.
- Enable the **publish–subscribe pattern** between objects.
- Used heavily in GUIs, asynchronous programming, and .NET frameworks.
- Modern C# introduces generics (`Action<>`, `Func<>`, `EventHandler<T>`), but the concepts remain the same.
