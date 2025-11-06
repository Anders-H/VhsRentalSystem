using System.Globalization;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class ReturnOnTheFlyDialog : Form
{
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string Description { get; set; }

    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
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

    private void ReturnOnTheFlyDialog_Load(object sender, EventArgs e)
    {
        txtEan.Text = Cassette?.Ean.ToString(CultureInfo.InvariantCulture) ?? "";
        txtTitle.Text = Cassette?.Title ?? "";
        txtYear.Text = Cassette?.Year.ToString() ?? "";
    }
}