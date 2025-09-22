using System;

class Program
{
    static void Main()
    {
        // if-else if-else
        int number = 10;
        if (number > 10)
        {
            Console.WriteLine("Number is greater than 10");
        }
        else if (number < 10)
        {
            Console.WriteLine("Number is less than 10");
        }
        else
        {
            Console.WriteLine("Number is 10");
        }

        // switch statement
        int day = 3;
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            default:
                Console.WriteLine("Another day");
                break;
        }

        // while loop
        int i = 0;
        while (i < 3)
        {
            Console.WriteLine($"While loop iteration: {i}");
            i++;
        }

        // do-while loop
        int j = 0;
        do
        {
            Console.WriteLine($"Do-while loop iteration: {j}");
            j++;
        } while (j < 3);

        // for loop
        for (int k = 0; k < 3; k++)
        {
            Console.WriteLine($"For loop iteration: {k}");
        }

        // foreach loop (with an array)
        int[] numbers = { 1, 2, 3 };
        foreach (int num in numbers)
        {
            Console.WriteLine($"Foreach loop number: {num}");
        }

        // break and continue
        for (int l = 0; l < 5; l++)
        {
            if (l == 2)
            {
                continue; // Skip this iteration
            }
            if (l == 4)
            {
                break; // Exit the loop
            }
            Console.WriteLine($"Break/Continue loop iteration: {l}");
        }

        // goto statement (use sparingly)
        int m = 0;
    MyLabel:
        Console.WriteLine($"Goto loop iteration: {m}");
        m++;
        if (m < 3)
        {
            goto MyLabel;
        }
    }
}
