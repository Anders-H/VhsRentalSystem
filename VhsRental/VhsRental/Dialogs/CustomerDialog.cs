using VhsRental.Screens;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class CustomerDialog : Form
{
    private Customer? _customer;
    public int CurrentCustomerId { get; set; }
    public string? CurrentSsn { get; set; }
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
            txtCustomerSsn.Text = (CurrentSsn ?? "").Trim();
            customerCoreDataControl1.DisableSsn(txtCustomerSsn.Text);
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
                txtCustomerSsn.Text = (CurrentSsn ?? "").Trim();
                customerCoreDataControl1.DisableSsn(txtCustomerSsn.Text);
            }
            else
            {
                PopulateForm();
                AddMode = false;
                btnOk.Text = @"Update";
                customerCoreDataControl1.EnableSsn(CurrentSsn ?? "");
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
                _customer = new Customer();
                customerCoreDataControl1.WriteBack(ref _customer);
                CurrentCustomerId = Customer.Add(_customer.Name, _customer.Ssn, _customer.Address1, _customer.Address2, _customer.ZipCode, _customer.ZipCode, _customer.Phone, _customer.EMail);

                if (CurrentCustomerId <= 0)
                {
                    MessageBox.Show(@"Add customer failed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

        if (AddMode)
            return;

        var customer = Customer
            .Get(txtCustomerSsn.Text);

        if (customer == null)
        {
            _customer = null;
            customerCoreDataControl1.ClearForm();
            btnOk.Text = @"Add";
            AddMode = true;
            customerCoreDataControl1.DisableSsn(txtCustomerSsn.Text.Trim());
            return;
        }

        btnOk.Text = @"Update";
        AddMode = false;
        _customer = customer;
        customerCoreDataControl1.EnableSsn();
        PopulateForm();
    }
}