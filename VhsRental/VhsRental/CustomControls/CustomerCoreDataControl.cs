using System.Globalization;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.CustomControls
{
    public partial class CustomerCoreDataControl : UserControl
    {
        public CustomerCoreDataControl()
        {
            InitializeComponent();
        }

        private void CustomerCoreDataControl_Resize(object sender, EventArgs e)
        {
            Width = 771;
            Height = 252;
        }

        public void SetData(Customer? customer)
        {
            if (customer == null)
            {
                ClearForm();
                return;
            }

            txtName.Text = customer.Name;
            txtSsn.Text = customer.Ssn;
            txtAddress1.Text = customer.Address1;
            txtAddress2.Text = customer.Address2;
            txtZipCode.Text = customer.ZipCode;
            txtCity.Text = customer.City;
            txtPhone.Text = customer.Phone;
            txtEMail.Text = customer.EMail;
            txtCustomerNumber.Text = customer.CustomerNumber;
            chkBlocked.Checked = customer.IsBlocked;
            txtCassetteEan.Text = customer.CassetteEan.ToString(CultureInfo.InvariantCulture);
            txtCassetteLastCustomerName.Text = customer.CassetteLastCustomerName;
            txtLastMovieTitle.Text = customer.LastMovieTitle;
            txtTotalNumberOfRentals.Text = customer.TotalNumberOfRentals.ToString("n0");
            txtCassettesOutNow.Text = customer.CassettesOutNow.ToString("n0");
            txtLastActivity.Text = customer.LastActivity == null
                ? ""
                : customer.LastActivity.Value.ToString("yyyy-MM-dd");
        }

        public void ClearForm()
        {
            txtName.Text = "";
            txtSsn.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtZipCode.Text = "";
            txtCity.Text = "";
            txtPhone.Text = "";
            txtEMail.Text = "";
            txtCustomerNumber.Text = "";
            chkBlocked.Checked = false;
            txtCassetteEan.Text = "";
            txtCassetteLastCustomerName.Text = "";
            txtLastMovieTitle.Text = "";
            txtTotalNumberOfRentals.Text = "";
            txtCassettesOutNow.Text = "";
            txtLastActivity.Text = "";
        }

        public void WriteBack(ref Customer target)
        {
            target.Name = txtName.Text.Trim();
            target.Ssn = txtSsn.Text.Trim();
            target.Address1 = txtAddress1.Text.Trim();
            target.Address2 = txtAddress2.Text.Trim();
            target.ZipCode = txtZipCode.Text.Trim();
            target.City = txtCity.Text.Trim();
            target.Phone = txtPhone.Text.Trim();
            target.EMail = txtEMail.Text.Trim();
            target.IsBlocked = chkBlocked.Checked;
        }

        public void DisableSsn(string ssn)
        {
            txtSsn.Enabled = false;
            txtSsn.Text = ssn;
        }

        public void EnableSsn(string ssn)
        {
            txtSsn.Enabled = true;
            txtSsn.Text = ssn;
        }

        public void EnableSsn() =>
            txtSsn.Enabled = true;

        public bool ValidateCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Focus();
                MessageBox.Show(@"The field Name cannot be empty.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSsn.Text))
            {
                txtSsn.Focus();
                MessageBox.Show(@"The field Social security number cannot be empty.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}