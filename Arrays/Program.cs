using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

        Console.WriteLine("Elements in the array:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
