using VhsRental.Screens;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class CustomerDialog : Form
{
    private bool AddMode { get; set; }
    public bool PromptOnAdd { get; set; }
    public Customer? Customer { get; private set; }
    public int CurrentCustomerId { get; set; }
    public string? CurrentSsn { get; set; }
    public bool AllowChangeCustomer { get; set; }

    public CustomerDialog()
    {
        InitializeComponent();
        AddMode = false;
        PromptOnAdd = true;
        AllowChangeCustomer = true;
    }

    private void CustomerDialog_Shown(object sender, EventArgs e)
    {
        txtCustomerSsn.Enabled = AllowChangeCustomer;
        InitializeGui();
    }

    private void InitializeGui()
    {
        this.SetToWaitMode(true);

        if (CurrentCustomerId <= 0)
        {
            Customer = null;
            ClearForm();
            AddMode = true;
            btnOk.Text = @"Add";
            txtCustomerSsn.Text = (CurrentSsn ?? "").Trim();
            customerCoreDataControl1.DisableSsn(txtCustomerSsn.Text);
        }
        else
        {
            Customer = Customer.Get(CurrentCustomerId);
            if (Customer == null)
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
                CurrentSsn = Customer.Ssn;
                PopulateForm();
                AddMode = false;
                btnOk.Text = @"Update";
                customerCoreDataControl1.EnableSsn(CurrentSsn ?? "");
            }
        }

        this.SetToWaitMode(false);
        txtCustomerSsn.Enabled = AllowChangeCustomer;
    }

    private void PopulateForm()
    {
        txtCustomerSsn.Text = Customer?.Ssn ?? "";
        customerCoreDataControl1.SetData(Customer);
        CurrentCustomerId = Customer?.Id ?? 0;
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
            if (PromptOnAdd && MessageBox.Show(@"Add a new customer?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            Customer = new Customer();
            var c = Customer;
            customerCoreDataControl1.WriteBack(ref c);
            Customer = c;
            CurrentCustomerId = Customer.Add(Customer.Name, Customer.Ssn, Customer.Address1, Customer.Address2, Customer.ZipCode, Customer.ZipCode, Customer.Phone, Customer.EMail);

            if (CurrentCustomerId <= 0)
            {
                MessageBox.Show(@"Add customer failed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            return;
        }

        if (Customer is not { Id: > 0 })
        {
            MessageBox.Show(@"Unexpected error.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var cst = Customer;
        customerCoreDataControl1.WriteBack(ref cst);
        Customer = cst;

        if (HasChangedSsn() && !Customer.UpdateSsn(Customer.Id, Customer.Ssn))
        {
            MessageBox.Show(@"The social security number could not be updated because it is not unique.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Customer.Set(Customer);

        DialogResult = DialogResult.OK;
    }

    private bool HasChangedSsn()
    {
        if (Customer == null)
            return false;

        if (string.IsNullOrWhiteSpace(Customer.Ssn) || string.IsNullOrWhiteSpace(CurrentSsn))
            return false;

        return Customer.Ssn != CurrentSsn;
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
            Customer = null;
            customerCoreDataControl1.ClearForm();
            btnOk.Text = @"Add";
            AddMode = true;
            customerCoreDataControl1.DisableSsn(txtCustomerSsn.Text.Trim());
            return;
        }

        btnOk.Text = @"Update";
        AddMode = false;
        Customer = customer;
        customerCoreDataControl1.EnableSsn();
        PopulateForm();
    }

    private void txtCustomerSsn_TextChanged(object sender, EventArgs e)
    {
        if (AddMode)
            customerCoreDataControl1.SetSsn(txtCustomerSsn.Text.Trim());
    }
}