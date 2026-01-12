# C# 1.0 - P24_AccessModifiers

Now let’s look at an example that demonstrates the different access modifiers in C#. 

Access modifiers control who can see and use a member of a class. 

They are the foundation of encapsulation and data protection.

## 1. Public

In PublicClass, we have:

```csharp
public string PublicField = "Public";
```

A public member is accessible from anywhere.

In our Main() method, we can directly do:

```csharp
Console.WriteLine(publicObj.PublicField);
```

So public is the most open access level.

## 2. Private

We also have:

```csharp
private string PrivateField = "Private";
```

A private member is accessible only inside the same class.

We cannot access it from outside — not even from a derived class.

To demonstrate, the class defines a method:

```csharp
public void DisplayPrivateField()
{
    Console.WriteLine($"Private Field: {PrivateField}");
}
```

This public method is the only way to access the private field.

So private is the most restrictive level.

## 3. Protected

Next, we have:

```csharp
protected string ProtectedField = "Protected";
```

A protected member is accessible inside the class and in its derived classes.

For example, DerivedClass inherits from PublicClass.

Inside DerivedClass, we can access ProtectedField and print it.

But from Main(), we cannot directly access it.

## 4. Internal

Now, we see:

```csharp
internal string InternalField = "Internal";
```

An internal member is visible only within the same assembly (same project or DLL).

So, in AnotherClass (which is in the same assembly), we can access InternalField.

But if AnotherClass were in another assembly, it would not be accessible.

## 5. Protected Internal

Finally:

```csharp
protected internal string ProtectedInternalField = "Protected Internal";
```

This one is a combination:

Accessible in the same assembly (like internal).

Also accessible in derived classes from other assemblies (like protected).

In our case, AnotherClass can access it because it’s in the same assembly.

## 6. Putting It All Together

In Main():

We create PublicClass and access the public field directly.

We call DisplayPrivateField() to access the private field indirectly.

We create a DerivedClass and access the protected field through a method.

We create AnotherClass and access both internal and protected internal fields.

## Summary of Access Levels

public → accessible everywhere.

private → accessible only within the class.

protected → accessible within the class and derived classes.

internal → accessible within the same assembly.

protected internal → accessible within the same assembly, or in derived classes across assemblies.

💡 Why It Matters
Access modifiers give us control over visibility. They help us enforce encapsulation, protect data, and design clear boundaries between components.
