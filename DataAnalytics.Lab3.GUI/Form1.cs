using DataAnalytics.Lab3;

namespace DataAnalytics.Lab3.GUI;

public partial class Form1 : Form
{
    private readonly List<Customer> _customers;

    public Form1()
    {
        _customers = Lab3Runner.LoadCustomers();
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        ShowCustomers(_customers);
        _customersListBox.SelectedIndexChanged += (sender, args) =>
        {
            var selectedCustomer = _customers[_customersListBox.SelectedIndex];
            _selectedCustomerPictureBox.ImageLocation = selectedCustomer.PhotoLink;
        };
    }

    private void _filterByLastNameTextBox_TextChanged(object sender, EventArgs e)
    {
        var thread = _filterByLastNameTextBox.Text;
        if (string.IsNullOrEmpty(thread))
        {
            ShowCustomers(_customers);
        }
        else
        {
            var filtered = _customers.Where(c => c.LastName.Contains(thread, StringComparison.OrdinalIgnoreCase)).ToList();
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
        }
    }
}
