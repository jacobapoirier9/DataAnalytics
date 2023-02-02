﻿namespace DataAnalytics.Lab2;

public static class Lab2Runner
{
    public static void Run(string[] args)
    {
        var arraySize = Helper.GetUserInput<int>("Enter size of array (n)");
        var array = Helper.GenerateRandomArray(arraySize);

        var target = default(int);
        while (true)
        {
            target = Helper.GetUserInput<int>("Enter a number to search array for");

            if (target < 0)
            {
                Console.WriteLine("Number must be >= 0");
                continue;
            }
            else if (target >= arraySize * 10)
            {
                Console.WriteLine($"Number must be < {arraySize}");
                continue;
            }

            break;
        }

        LinearSearch(array, target);
        BinarySearch(array, target);
    }

    public static int LinearSearch(int[] array, int target) // O(n)
    {
        Console.WriteLine($"Beginning linear search for {target}..");

        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                Console.WriteLine($"Found {target} after {i + 1} attempts!");
                return i;
            }
        }

        Console.WriteLine($"Could not find {target} after {array.Length} attempts.");
        return -1;
    }

    public static int BinarySearch(int[] array, int target) // O(log n)
    {
        Array.Sort(array);

        Console.WriteLine($"Beginning binary search for {target}..");

        var low = 0;
        var high = array.Length - 1;
        var counter = 1;

        while (low <= high)
        {
            var middle = (low + high) / 2;
            if (target == array[middle])
            {
                Console.WriteLine($"Found {target} after {counter} attempts!");
                return middle;
            }

            else if (target < array[middle])
                high = middle - 1;
            else
                low = middle + 1;

            counter++;
        }

        Console.WriteLine($"Could not find {target} after {array.Length} attempts.");
        return -1;
    }
}