using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class ReturnOnTheFlyDialog : Form
{
    public string Description { get; set; }
    public CassetteBasicInformation? Cassette { get; set; }

    public ReturnOnTheFlyDialog()
    {
        InitializeComponent();
        Description = "";
    }

    private void btnContinue_Click(object sender, EventArgs e)
    {
        Description = txtDescription.Text.Trim();
        DialogResult = DialogResult.OK;
    }
}