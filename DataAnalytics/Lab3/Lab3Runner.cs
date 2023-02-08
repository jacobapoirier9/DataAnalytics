namespace DataAnalytics.Lab3;

public static class Lab3Runner
{
    public static void Run()
    {

    }
}

public class Customer
{
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _address;
    private readonly string _city;
    private readonly string _state;
    private readonly string _zipCode;
    private readonly string _phoneNumber;
    private readonly string _email;
    private readonly string _photoLink;

    public Customer(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email, string photoLink)
    {
        _firstName = firstName;
        _lastName = lastName;
        _address = address;
        _city = city;
        _state = state;
        _zipCode = zipCode;
        _phoneNumber = phoneNumber;
        _email = email;
        _photoLink = photoLink;
    }
}