namespace DataAnalytics.Lab1;

public static class Lab1Runner
{
    public static void Run(string[] args)
    {
        int[] numbers = LoadData();

        Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
        Console.WriteLine($"Minimum: {numbers.FindMin()}");
        Console.WriteLine($"Maximum: {numbers.FindMax()}");
        Console.WriteLine($"Average: {numbers.FindAverage()}");
    }

    public static int[] LoadData() // O(n)
    {
        string filePath = @".\Lab1\Lab1Data.csv"; // Data.csv will copy to the output directory on build.

        int[] numbers = File.ReadAllText(filePath)
            .Split(Environment.NewLine)
            .Select(line => int.Parse(line))
            .ToArray();

        return numbers;
    }

    public static int FindMin(this int[] numbers) // O(n)
    {
        if (numbers.Length == 0)
            return 0;

        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }

        return min;
    }

    public static int FindMax(this int[] numbers) // O(n)
    {
        if (numbers.Length == 0)
            return 0;

        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }

        return max;
    }

    public static double FindAverage(this int[] numbers) // O(n)
    {
        if (numbers.Length == 0)
            return 0;

        int sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double avg = (double)sum / numbers.Length;
        return avg;
    }
}