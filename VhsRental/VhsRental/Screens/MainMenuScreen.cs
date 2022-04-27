using VhsRentalBusinessLayer.Entities;

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
}