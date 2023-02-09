using DataAnalytics.Lab3;

namespace DataAnalytics.Lab3.GUI;

public partial class Form1 : Form
{
    private readonly List<Customer> _customers;
    private const string _notFoundImageLocation = @".\Lab3\NotFound.png";

    public Form1()
    {
        _customers = Lab3Runner.LoadCustomers();
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        ShowCustomers(_customers);
        _selectedCustomerPictureBox.ImageLocation = _notFoundImageLocation;

        _customersListBox.SelectedIndexChanged += (sender, args) =>
        {
            var selectedCustomer = _customers[_customersListBox.SelectedIndex];
            _selectedCustomerPictureBox.ImageLocation = selectedCustomer.PhotoLink;
        };
    }

    private void _filterByLastNameTextBox_TextChanged(object sender, EventArgs e)
    {
        ApplyCustomersFilter(_filterByLastNameTextBox.Text, c => c.LastName);
    }
    private void _filterByStateTextBox_TextChanged(object sender, EventArgs e)
    {
        ApplyCustomersFilter(_filterByStateTextBox.Text, c => c.State);
    }

    private void ApplyCustomersFilter(string thread, Func<Customer, string> propertySelection)
    {
        if (string.IsNullOrEmpty(thread))
        {
            ShowCustomers(_customers);
        }
        else
        {
            var filtered = new List<Customer>();
            foreach (var customer in _customers)
            {
                if (propertySelection(customer).Contains(thread, StringComparison.OrdinalIgnoreCase))
                    filtered.Add(customer);
            }

            ShowCustomers(filtered);
        }
    }

    private void ShowCustomers(List<Customer> customers)
    {
        _customersListBox.ForeColor = Color.Black;
        _customersListBox.Items.Clear();

        foreach (var customer in customers)
        {
            _customersListBox.Items.Add($"{customer.FirstName} {customer.LastName} ({customer.Address}, {customer.City} {customer.State}");
        }

        if (_customersListBox.Items.Count == 0)
        {
            _customersListBox.ForeColor = Color.Red;
            _customersListBox.Items.Add("No customers found.");
            _selectedCustomerPictureBox.ImageLocation = _notFoundImageLocation;
        }
    }
}
