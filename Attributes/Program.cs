using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
}

[MyCustom(Description = "This is a custom attribute on a class.")]
class MyClass
{
    [MyCustom(Description = "This is a custom attribute on a method.")]
    public void MyMethod()
    {
    }
}

class Program
{
    static void Main()
    {
        Type type = typeof(MyClass);
        object[] attributes = type.GetCustomAttributes(false);

        foreach (object attribute in attributes)
        {
            if (attribute is MyCustomAttribute)
            {
                MyCustomAttribute myAttribute = (MyCustomAttribute)attribute;
                Console.WriteLine(myAttribute.Description);
            }
        }

        System.Reflection.MethodInfo methodInfo = type.GetMethod("MyMethod");
        object[] methodAttributes = methodInfo.GetCustomAttributes(false);

        foreach (object attribute in methodAttributes)
        {
            if (attribute is MyCustomAttribute)
            {
                MyCustomAttribute myAttribute = (MyCustomAttribute)attribute;
                Console.WriteLine(myAttribute.Description);
            }
        }
    }
}
