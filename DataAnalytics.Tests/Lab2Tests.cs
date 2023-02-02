using DataAnalytics.Lab2;

namespace DataAnalytics.Tests;
public class Lab2Tests
{
    private readonly int[] _array = new int[] { 4, 11, 19, 30, 45, 59, 60, 63, 66, 72, 103, 117, 144, 146, 148, 165, 171, 175, 192, 195 };

    [Fact]
    public void LinearSearch_ElementFound()
    {
        int index = Lab2Runner.LinearSearch(_array, 45);
        Assert.Equal(4, index);
    }

    [Fact]
    public void LinearSearch_ElementNotFound()
    {
        int index = Lab2Runner.LinearSearch(_array, 200);
        Assert.Equal(-1, index);
    }

    [Fact]
    public void BinarySearch_ElementFound()
    {
        int index = Lab2Runner.BinarySearch(_array, 45);
        Assert.Equal(4, index);
    }

    [Fact]
    public void BinarySearch_ElementNotFound()
    {
        int index = Lab2Runner.BinarySearch(_array, 200);
        Assert.Equal(-1, index);
    }
}
