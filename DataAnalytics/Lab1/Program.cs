﻿using System.ComponentModel.DataAnnotations;

namespace DataAnalytics.Lab1;

public static class Lab1Runner
{
    public static void Run(string[] args)
    {
        var numbers = LoadData();

        Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
        Console.WriteLine($"Minimum: {numbers.FindMin()}");
        Console.WriteLine($"Maximum: {numbers.FindMax()}");
        Console.WriteLine($"Average: {numbers.FindAverage()}");
    }

    // Big-O: O(n)
    public static int[] LoadData()
    {
        var filePath = @".\Lab1Data.csv"; // Data.csv will copy to the output directory on build.

        var numbers = File.ReadAllText(filePath)
            .Split(Environment.NewLine)
            .Select(line => int.Parse(line))
            .ToArray();

        return numbers;
    }

    // Big-O: O(n - 1)
    public static int FindMin(this int[] numbers)
    {
        if (numbers.Length == 0)
            return 0;

        var min = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
        }

        return min;
    }

    // Big-O: O(n - 1)
    public static int FindMax(this int[] numbers)
    {
        if (numbers.Length == 0)
            return 0;

        var max = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }

        return max;
    }

    // Big-O: O(n - 1)
    public static double FindAverage(this int[] numbers)
    {
        if (numbers.Length == 0)
            return 0;

        var sum = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        var avg = (double)sum / numbers.Length;
        return avg;
    }
}