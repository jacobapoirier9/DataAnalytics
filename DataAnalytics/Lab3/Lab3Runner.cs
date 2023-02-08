namespace DataAnalytics.Lab3;

public static class Lab3Runner
{
    public static void Run()
    {
        var customers = LoadCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }

    public static List<Customer> LoadCustomers()
    {
        var customers = new List<Customer>();
        var lines = File.ReadAllLines(@".\Lab3\Customers.csv");

        foreach (var line in lines)
        {
            var data = line.Split(',');

            var firstName = data[0];
            var lastName = data[1];
            var address = data[2];
            var city = data[3];
            var state = data[4];
            var zipCode = data[5];
            var phoneNumber = data[6];
            var email = data[7];
            var photoLink = data[8];

            var customer = new Customer(firstName, lastName, address, city, state, zipCode, phoneNumber, email, photoLink);
            customers.Add(customer);
        }

        return customers;
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

    public string FirstName => _firstName;
    public string LastName => _lastName;
    public string Address => _address;
    public string City => _city;
    public string State => _state;
    public string ZipCode => _zipCode;
    public string PhoneNumber => _phoneNumber;
    public string Email => _email;
    public string PhotoLink => _photoLink;

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

    public override string ToString()
    {
        return _firstName + " " + _lastName + " (" + _address + ", " + _city + " " + _state + ", " + _zipCode + "), (" + _phoneNumber + ", " + _email + ") - " + _photoLink;
    }
}