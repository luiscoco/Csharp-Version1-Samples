using System;

public delegate void MyEventHandler(object sender, EventArgs e);

public class MyEventSource
{
    public event MyEventHandler MyEvent;

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
}

class Program
{
    static void Main()
    {
        MyEventSource source = new MyEventSource();
        source.MyEvent += new MyEventHandler(HandleEvent);
        source.RaiseEvent();
    }

    static void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event handled!");
    }
}
