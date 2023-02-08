using DataAnalytics.Lab3;

namespace DataAnalytics.Lab3.GUI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var customers = Lab3Runner.LoadCustomers();
        foreach (var customer in customers)
        {
            _customersListBox.Items.Add($"{customer.FirstName} {customer.LastName} ({customer.Address}, {customer.City} {customer.State}");
        }

        _customersListBox.SelectedIndexChanged += (sender, args) =>
        {
            var selectedCustomer = customers[_customersListBox.SelectedIndex];

            _selectedCustomerPictureBox.ImageLocation = selectedCustomer.PhotoLink;
        };
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
}
