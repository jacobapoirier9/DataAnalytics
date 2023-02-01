
using DataAnalytics.Lab2;

namespace DataAnalytics.Tests;

public class HelpersTests
{
    [Fact]
    public void GeneratesRandomArray()
    {
        var arraySize = 124;

        var array = Helper.GenerateRandomArray(arraySize);

        Assert.Equal(arraySize, array.Length);
        Assert.All(array, number => Assert.False(number > arraySize * 10));
        Assert.All(array, number => Assert.False(number < 0));
    }
}