using DataAnalytics.Lab1;

namespace DataAnalytics.Tests;

public class Lab1Tests
{
    private readonly int[] _emptyArray = new int[] { };
    private readonly int[] _notEmptyArray = new int[] { 2, 5, 6, 3, 2, 4, 8, 9, 1, 3, 5 };

    [Fact]
    public void FindMin_EmptyArray()
    {
        int min = Lab1Runner.FindMin(_emptyArray);
        Assert.Equal(0, min);
    }

    [Fact]
    public void FindMax_EmptyArray()
    {
        int max = Lab1Runner.FindMax(_emptyArray);
        Assert.Equal(0, max);
    }

    [Fact]
    public void FindAverage_EmptyArray()
    {
        double avg = Lab1Runner.FindAverage(_emptyArray);
        Assert.Equal(0, avg);
    }

    [Fact]
    public void FindMin_NotEmptyArray()
    {
        int min = Lab1Runner.FindMin(_notEmptyArray);
        Assert.Equal(1, min);
    }

    [Fact]
    public void FindMax_NotEmptyArray()
    {
        int max = Lab1Runner.FindMax(_notEmptyArray);
        Assert.Equal(9, max);
    }

    [Fact]
    public void FindAverage_NotEmptyArray()
    {
        double avg = Lab1Runner.FindAverage(_notEmptyArray);
        Assert.Equal(4.3636363636363633, avg);
    }
}