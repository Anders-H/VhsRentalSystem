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
        txtCustomerSsn.Text = _customer!.Ssn;
        customerCoreDataControl1.SetData(_customer);
    }

    private void ClearForm()
    {
        txtCustomerSsn.Text = "";
        customerCoreDataControl1.ClearForm();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {

    }
}