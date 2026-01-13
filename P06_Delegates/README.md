# C# 1.0 - P06_Delegates

This sample (from the repo **Csharp-Version1-Samples**) demonstrates **delegates, events, and the subscribe/unsubscribe pattern** in **C# 1.0**.

Before diving into the details, let’s focus on the main concepts this example introduces: delegates, events, publishers, and subscribers.

## 1. Delegates
A delegate is like a contract for a method. 

It says: ‘any method that looks like this can be stored and called later.’

In our example, NotifyHandler is a delegate. 

It specifies that any method that takes a string and returns nothing can be plugged in.

Think of a delegate as a remote control: the button doesn’t know exactly what device is connected

, it only knows ‘when I press this, something with this shape will respond.’

## 2. Events
An event is a special way of using a delegate that protects how it’s raised.
It’s a message the Publisher can send out, and it’s a signal that something happened.

The key point: events connect the publisher with subscribers without them needing to know 

about each other directly.

## 3. Publisher Class
The Publisher is the one that creates the event. It owns the event OnNotify.

It doesn’t care who listens — it only raises the event whenever something important

happens (in our case, after DoSomething).

So the Publisher is like a news station: it just broadcasts messages.

## 4. Subscriber Class
The Subscriber is anyone who listens to the event.
It provides a method that matches the delegate (HandleNotification).
When it subscribes to the event, it’s saying: ‘Please call me whenever the news station broadcasts.’

So the Subscriber is like a viewer at home: it decides to tune in or tune out.

## 5. Subscription and Unsubscription
In the Main() method we see both.

Subscribing: pub.OnNotify += sub.HandleNotification; means connect my method to that event.

Unsubscribing: pub.OnNotify -= sub.HandleNotification; means stop calling me when the event happens.

This mechanism makes the system very flexible: publishers don’t need to know how many subscribers there are or what they do.

## Summary

Delegates define the shape of the callback.

Events provide a safe way to raise and handle those callbacks.

Publisher owns and raises the event.

Subscriber listens and reacts to the event.

This publisher–subscriber pattern is at the core of event-driven programming in C#. It allows us to build loosely coupled systems where components communicate without hard dependencies.”

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

## Example Explanation

### 1. Delegate – the "type" of method

```csharp
public delegate void NotifyHandler(string message);
```
A **delegate** is like a function pointer, but type-safe and object-oriented.

It **defines the signature of methods** that can be attached to the event.

Here, any method that takes a string parameter and returns void can be used.

Think of it as: "I will accept any method that looks like void Something(string msg)."

### 2. Event – publisher side

```
public event NotifyHandler OnNotify;
```

**OnNotify** is an event declared inside the Publisher.

**Events** are based on delegates but more restricted:

Only the class that declares the event (Publisher) can trigger (raise) it.

Other classes (Subscriber) can only **subscribe (+=)** or **unsubscribe (-=)**.

This enforces encapsulation: subscribers can’t trigger events themselves.

### 3. Raising the event

```
private void RaiseEvent(string msg)
{
    if (OnNotify != null)   // Check if anyone subscribed
        OnNotify(msg);      // Invoke the delegate list
}
```

**OnNotify** holds a list of subscribed methods (multicast delegate).

Before calling, we check OnNotify != null (otherwise no one is listening).

If there are subscribers, all their methods are executed in order.

This is the publish action of the "publish/subscribe" pattern.

### 4. Subscriber – event handler method
```
public void HandleNotification(string msg)
{
    Console.WriteLine("Subscriber received: " + msg);
}
```

This method matches the delegate signature (void with string).

It’s what gets called when the event is raised.

### 5. Subscribe / Unsubscribe pattern

```
pub.OnNotify += sub.HandleNotification;   // Subscribe
pub.DoSomething();                         // Event raised -> subscriber called
pub.OnNotify -= sub.HandleNotification;   // Unsubscribe
```

+= adds HandleNotification to the event’s invocation list.

When **pub.DoSomething()** is executed:

It raises the event

All subscribed methods (here just one) are invoked.

-= removes the subscription → the subscriber won’t be notified anymore.

This prevents memory leaks or unexpected callbacks when a subscriber is no longer interested.


### 6. Big Picture (flow)

Publisher defines a delegate + event.

Subscriber provides a method matching the delegate.

Subscriber subscribes (+=) → event now points to subscriber’s method.

Publisher raises the event → all subscribed methods are invoked.

Subscriber unsubscribes (-=) → removed from invocation list.

### 7. In short:

Delegate = method contract (what kind of methods can be called).

Event = wrapper around delegate that enforces publisher/subscriber rules.

Subscribe (+=) / Unsubscribe (-=) = add/remove handlers from event invocation list.

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
