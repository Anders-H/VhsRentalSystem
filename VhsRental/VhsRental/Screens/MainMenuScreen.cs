namespace VhsRental.Screens;

public partial class MainMenuScreen : UserControl, IScreen
{
    public MainMenuScreen()
    {
        InitializeComponent();
    }

    public void Initialize() =>
        btnLogIn.Text = Context.CurrentStaff == null
            ? @"Log in"
            : $@"Log out: {Context.CurrentStaff}";

    private void btnLogIn_Click(object sender, EventArgs e)
    {
        if (Context.CurrentStaff == null)
        {
            using var x = new LoginForm();
            if (x.ShowDialog(this) == DialogResult.OK)
            {
                Initialize();
                return;
            }
        }

        if (Context.CurrentStaff == null)
        {
            Initialize();
            return;
        }

        var u = Context.CurrentStaff.ToString();
        Context.CurrentStaff = null;
        Initialize();
        Refresh();
        MessageBox.Show($@"{u} has logged out.", ParentForm!.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private bool IsLoggedIn()
    {
        if (Context.CurrentStaff != null)
            return true;

        MessageBox.Show(@"You need to log in first.", ParentForm!.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    private void btnCreateRental_Click(object sender, EventArgs e)
    {
        if (!IsLoggedIn())
            return;

        ((MainWindow)ParentForm).GetScreen<CreateRentalScreen>();
    }

    private void btnCustomers_Click(object sender, EventArgs e)
    {
        if (!IsLoggedIn())
            return;

        ((MainWindow)ParentForm).GetScreen<CustomersScreen>();
    }
}