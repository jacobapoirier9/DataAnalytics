namespace DataAnalytics.Lab8;

public static class Lab8Runner
{
    private const decimal _quarterValue = .25m;
    private const decimal _dimeValue = .10m;
    private const decimal _nickelValue = .05m;
    private const decimal _pennyValue = .01m;

    public static void Run()
    {
        var coinAmount = Helper.GetUserInput<decimal>("Enter coin amount");

        var numberOfQuarters = 0;
        var numberOfDimes = 0;
        var numberOfNickels = 0;
        var numberOfPennies = 0;

        while (coinAmount > 0)
        {
            if (coinAmount >= _quarterValue)
            {
                coinAmount -= _quarterValue;
                numberOfQuarters++;
            }
            else if (coinAmount >= _dimeValue)
            {
                coinAmount -= _dimeValue;
                numberOfDimes++;
            }
            else if (coinAmount >= _nickelValue)
            {
                coinAmount -= _nickelValue;
                numberOfNickels++;
            }
            else if (coinAmount >= _pennyValue)
            {
                coinAmount -= _pennyValue;
                numberOfPennies++;
            }
            else
                throw new ApplicationException();
        }

        var numberOfCoins = numberOfQuarters + numberOfDimes + numberOfNickels + numberOfPennies;

        Console.WriteLine("There are a total of {0} coins.", numberOfCoins);
        Console.WriteLine("Quarters: {0}", numberOfQuarters);
        Console.WriteLine("Dimes:    {0}", numberOfDimes);
        Console.WriteLine("Nickels:  {0}", numberOfNickels);
        Console.WriteLine("Pennies:  {0}", numberOfPennies);
    }
}