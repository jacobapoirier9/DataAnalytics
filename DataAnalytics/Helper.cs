namespace DataAnalytics;

public static class Helper
{
    public static T GetUserInput<T>(string prompt) where T : IConvertible
    {
        var response = default(string);
        do
        {
            Console.WriteLine(prompt);
            Console.Write(" >> ");
            response = Console.ReadLine();
        } while (response is null || response == string.Empty);

        return (T)Convert.ChangeType(response, typeof(T));
    }

    public static int[] GenerateRandomArray(int arraySize)
    {
        var random = new Random();

        var array = new int[arraySize];
        for (var i = 0; i < arraySize; i++)
        {
            array[i] = random.Next(0, arraySize * 10);
        }

        return array;
    }
}
