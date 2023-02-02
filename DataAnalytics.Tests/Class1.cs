namespace DataAnalytics.Tests;

public class HelpersTests
{
    [Fact]
    public void GeneratesRandomArray()
    {
        int arraySize = 124;

        int[] array = Helper.GenerateRandomArray(arraySize);

        Assert.Equal(arraySize, array.Length);
        Assert.All(array, number => Assert.False(number > arraySize * 10));
        Assert.All(array, number => Assert.False(number < 0));
    }
}