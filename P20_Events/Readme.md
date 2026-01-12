# Events and Delegates in C#

Now we’re going to look at an example that demonstrates how events work in C#. Events are the foundation for many interactive applications — they let one object notify another when something happens.

## 1. Declaring a Delegate

At the top, we have:

```csharp
public delegate void MyEventHandler(object sender, EventArgs e);
```

A delegate is like a type-safe function pointer.
It defines the signature of methods that can handle the event.

Here, any event handler must take:

object sender → the object that raised the event.

EventArgs e → additional event data (empty here, but often contains useful info).

This pattern comes directly from C# 1.0 and is still widely used.

## 2. Declaring an Event

Inside the class:

```csharp
public event MyEventHandler MyEvent;
```

This creates an event of type MyEventHandler.

Think of an event as a “list of methods to call” when something happens. Other objects can subscribe to this event.

## 3. Raising the Event

```csharp
public void RaiseEvent()
{
    OnMyEvent(EventArgs.Empty);
}

protected virtual void OnMyEvent(EventArgs e)
{
    if (MyEvent != null)
    {
        MyEvent(this, e);
    }
}
```

The RaiseEvent method triggers the event.

By convention, we use a protected virtual method named On<EventName> to raise the event.

```csharp
if (MyEvent != null) checks if there are any subscribers before invoking.
```

When invoked, every subscribed handler gets called.

## 4. Subscribing to the Event

In Main():

```csharp
source.MyEvent += new MyEventHandler(HandleEvent);
```

This means: “When MyEvent happens, call the method HandleEvent.”

And when we call:

```csharp
source.RaiseEvent();
```

the event fires, and HandleEvent executes:

Event handled!

## 5. The Handler Method

```csharp
static void HandleEvent(object sender, EventArgs e)
{
    Console.WriteLine("Event handled!");
}
```

This matches the delegate signature — it takes (object sender, EventArgs e).

## Summary of Key Concepts

Delegate → defines the shape of methods that can handle the event.

Event → a safe way to publish notifications; subscribers can add/remove their handlers.

Raising the event → done via OnMyEvent, which calls all subscribed handlers.

Subscribing → += adds a handler, -= removes one.

## Why It Matters

This is the classic event pattern in .NET. It underlies:

UI frameworks like WinForms and WPF (button clicks, key presses).

Asynchronous programming (event notifications).

Custom event systems in your own applications.

In modern C#, syntax has been simplified, but the core idea remains the same.
