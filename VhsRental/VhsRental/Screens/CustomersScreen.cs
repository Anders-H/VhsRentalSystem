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
        txtSearch.Text = txtSearch.Text.Trim();
        LoadCustomers(txtSearch.Text);
    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyData != Keys.Return && e.KeyData != Keys.Enter)
            return;

        e.SuppressKeyPress = true;
        btnSearch.Focus();
        btnSearch_Click(this, EventArgs.Empty);
    }

    private void LoadCustomers(string search)
    {
        this.SetToWaitMode(true);
        lv.BeginUpdate();
        lv.Items.Clear();

        var result = VhsRentalBusinessLayer.Entities.CustomerSearchResultEntity.Search(search);

        foreach (var c in result)
        {
            var li = lv.Items.Add(c.Name);
            li.Tag = c.Id;
            li.SubItems.Add(c.Ssn);
            li.SubItems.Add(c.IsBlocked ? "Yes" : "No");
            li.SubItems.Add(c.LastMovieTitle);
            li.SubItems.Add(c.TotalNumberOfRentals.ToString()).Tag = c.TotalNumberOfRentals;
            li.SubItems.Add(c.CassettesOutNow.ToString()).Tag = c.CassettesOutNow;
            li.SubItems.Add(c.LastActivity == null ? "" : c.LastActivity.Value.ToString("yyyy-MM-dd"));
        }

        lv.EndUpdate();
        this.SetToWaitMode(false);
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
        ((MainWindow)ParentForm!).GetScreen<MainMenuScreen>();
    }
}