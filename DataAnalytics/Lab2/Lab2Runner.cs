namespace DataAnalytics.Lab2;

public static class Lab2Runner
{
    public static void Run(string[] args)
    {
        int arraySize = Helper.GetUserInput<int>("Enter size of array (n)");
        int[] array = Helper.GenerateRandomArray(arraySize);

        int target;
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

        _ = LinearSearch(array, target);
        _ = BinarySearch(array, target);
    }

    public static int LinearSearch(int[] array, int target) // O(n)
    {
        Console.WriteLine($"Beginning linear search for {target}..");

        for (int i = 0; i < array.Length; i++)
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

        int low = 0;
        int high = array.Length - 1;
        int counter = 1;

        while (low <= high)
        {
            int middle = (low + high) / 2;
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
