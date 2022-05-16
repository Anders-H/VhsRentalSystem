using VhsRental.Screens;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class CustomerDialog : Form
{
    private Customer? _customer;
    public int CurrentCustomerId { get; set; }

    public CustomerDialog()
    {
        InitializeComponent();
    }

    private void CustomerDialog_Shown(object sender, EventArgs e)
    {
        InitializeGui();
    }

    private void InitializeGui()
    {
        this.SetToWaitMode(true);

        if (CurrentCustomerId <= 0)
        {
            _customer = null;
            ClearForm();
        }
        else
        {
            _customer = Customer.Get(CurrentCustomerId);
            if (_customer == null)
            {
                CurrentCustomerId = 0;
                ClearForm();
            }
            else
            {
                PopulateForm();
            }
        }

        this.SetToWaitMode(false);
    }

    private void PopulateForm()
    {
        txtCustomerSsn.Text = _customer?.Ssn ?? "";
        customerCoreDataControl1.SetData(_customer);
        CurrentCustomerId = _customer?.Id ?? 0;
    }

    private void ClearForm()
    {
        txtCustomerSsn.Text = "";
        customerCoreDataControl1.ClearForm();
        CurrentCustomerId = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (CurrentCustomerId <= 0 || _customer == null)
        {
            MessageBox.Show(@"No customer is selected.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!customerCoreDataControl1.ValidateCustomer())
            return;

        customerCoreDataControl1.WriteBack(ref _customer);
        Customer.Set(_customer);
        DialogResult = DialogResult.OK;
    }

    private void txtCustomerSsn_Leave(object sender, EventArgs e)
    {
        var customer = Customer
            .Get(txtCustomerSsn.Text);

        if (customer == null)
        {
            ClearForm();
            customerCoreDataControl1.NewCustomer(txtCustomerSsn.Text);
            return;
        }

        _customer = customer;
        PopulateForm();
    }
}