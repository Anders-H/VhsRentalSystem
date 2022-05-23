namespace VhsRental.Screens;

public partial class CustomersScreen : UserControl, IScreen
{
    public CustomersScreen()
    {
        InitializeComponent();
    }

    public void Initialize()
    {
        txtSearch.Text = "";
        btnSearch_Click(this, EventArgs.Empty);
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {

    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData != Keys.Return && e.KeyData != Keys.Enter)
            return;

        e.SuppressKeyPress = true;
        btnSearch.Focus();
        btnSearch_Click(this, EventArgs.Empty);
    }
}