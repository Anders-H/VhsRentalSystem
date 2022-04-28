using VhsRental.Screens;
using VhsRentalBusinessLayer;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental
{
    public partial class LoginForm : Form
    {
        public Staff? Staff { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var ssn = textBox1.Text.Trim();
            textBox1.Text = ssn;
            
            if (string.IsNullOrWhiteSpace(ssn))
            {
                MessageBox.Show(@"Enter your social security number.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            this.SetToWaitMode(true);

            var staff = Login.TryLogin(ssn);

            this.SetToWaitMode(false);

            switch (staff.Result)
            {
                case LoginResult.Success:
                    Context.CurrentStaff = staff.Staff;
                    DialogResult = DialogResult.OK;
                    break;
                case LoginResult.StaffInactive:
                    MessageBox.Show(@"Inactive staff.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.StaffNotFound:
                    MessageBox.Show(@"Staff not found.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.ConnectionError:
                    MessageBox.Show(@"Database connection error.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
