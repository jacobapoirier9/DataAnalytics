namespace DataAnalytics.Lab2;

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
            else if (target >= arraySize)
            {
                Console.WriteLine($"Number must be < {arraySize}");
                continue;
            }

            break;
        }

        LinearSearch(array, target);
    }

    private static void LinearSearch(int[] array, int target) // O(n)
    {
        Console.WriteLine($"Beginning linear search for {target}..");

        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                Console.WriteLine($"Found {target} at index {i}!");
                return;
            }
        }

        Console.WriteLine($"Could not find {target} after {array.Length} attempts.");
    }
}
