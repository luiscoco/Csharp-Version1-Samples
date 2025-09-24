public class WeekDays
{
    private string[] days =
        { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

    // Indexer
    public string this[int index]
    {
        get { return days[index]; }
        set { days[index] = value; }
    }

    // Override ToString
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < days.Length; i++)
        {
            result += days[i] + " ";
        }
        return result.Trim();
    }
}

class Program
{
    static void Main()
    {
        WeekDays week = new WeekDays();
        Console.WriteLine(week[0]);   // Mon
        week[0] = "Monday";           // modify via indexer
        Console.WriteLine(week);      // Monday Tue Wed Thu Fri Sat Sun
    }
}

