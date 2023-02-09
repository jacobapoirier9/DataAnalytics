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

    private void _filterByLastNameTextBox_TextChanged(object sender, EventArgs e) => ApplyCustomerFilters();
    private void _filterByStateTextBox_TextChanged(object sender, EventArgs e) => ApplyCustomerFilters();

    private void ApplyCustomerFilters()
    {
        var filteredCustomers = new List<Customer>();
        foreach (var customer in _customers)
        {
            if (RunFilter(customer.LastName, _filterByLastNameTextBox.Text) && RunFilter(customer.State, _filterByStateTextBox.Text))
                filteredCustomers.Add(customer);
        }

        ShowCustomers(filteredCustomers);
    }

    private bool RunFilter(string sourceField, string thread) =>
        string.IsNullOrEmpty(thread) || sourceField.Contains(thread, StringComparison.OrdinalIgnoreCase);

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
