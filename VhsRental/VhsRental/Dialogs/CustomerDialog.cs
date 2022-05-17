using VhsRental.Screens;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class CustomerDialog : Form
{
    private Customer? _customer;
    public int CurrentCustomerId { get; set; }
    private bool AddMode { get; set; }

    public CustomerDialog()
    {
        InitializeComponent();
        AddMode = false;
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
            AddMode = true;
            btnOk.Text = @"Add";
        }
        else
        {
            _customer = Customer.Get(CurrentCustomerId);
            if (_customer == null)
            {
                CurrentCustomerId = 0;
                ClearForm();
                AddMode = true;
                btnOk.Text = @"Add";
            }
            else
            {
                PopulateForm();
                AddMode = false;
                btnOk.Text = @"Update";
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
        if (!customerCoreDataControl1.ValidateCustomer())
            return;

        if (AddMode)
        {
            var response = MessageBox.Show(@"Add a new customer?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (response == DialogResult.Yes)
            {
                customerCoreDataControl1.NewCustomer(txtCustomerSsn.Text.Trim());
                _customer = new Customer();
                customerCoreDataControl1.WriteBack(ref _customer);
                Customer.Add(_customer);
                DialogResult = DialogResult.OK;
                return;
            }

            return;
        }

        if (_customer == null || _customer.Id <= 0)
        {
            MessageBox.Show(@"Unexpected error.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        customerCoreDataControl1.WriteBack(ref _customer);
        Customer.Set(_customer);
        DialogResult = DialogResult.OK;
    }

    private void txtCustomerSsn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var ssn = txtCustomerSsn.Text.Trim();
        txtCustomerSsn.Text = ssn;

        var customer = Customer
            .Get(txtCustomerSsn.Text);

        if (customer == null)
        {
            _customer = null;
            customerCoreDataControl1.ClearForm();
            btnOk.Text = @"Add";
            return;
        }

        btnOk.Text = @"Update";
        _customer = customer;
        PopulateForm();
    }
}