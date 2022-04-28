using System.Globalization;
using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Screens;

public partial class CreateRentalScreen : UserControl, IScreen
{
    public CreateRentalScreen()
    {
        InitializeComponent();
    }

    public void Initialize()
    {
    }

    private void txtCustomerSSN_Leave(object sender, EventArgs e)
    {
        var ssn = txtCustomerSSN.Text.Trim();
        txtCustomerSSN.Text = ssn;

        if (string.IsNullOrWhiteSpace(ssn))
        {
            txtCustomerSSN.GetTag().EntityId = 0;
            txtCustomerName.Text = "";
            return;
        }

        this.SetToWaitMode(true);

        var customer = CustomerContactInformation
            .Get(txtCustomerSSN.Text);

        var tag = txtCustomerSSN.GetTag();

        if (customer == null)
        {
            tag.EntityId = 0;
            txtCustomerName.Text = "";
        }
        else
        {
            tag.EntityId = customer.Id;
            txtCustomerSSN.Text = customer.Ssn;
            txtCustomerName.Text = customer.ToString();
        }

        this.SetToWaitMode(false);
    }

    private void txtCassetteEan1_Leave(object sender, EventArgs e) =>
        LoadCassette(txtCassetteEan1, txtPrice1, txtCassetteInfo1);

    private void txtCassetteEan2_Leave(object sender, EventArgs e) =>
        LoadCassette(txtCassetteEan2, txtPrice2, txtCassetteInfo2);

    private void txtCassetteEan3_Leave(object sender, EventArgs e) =>
        LoadCassette(txtCassetteEan3, txtPrice3, txtCassetteInfo3);

    private void txtCassetteEan4_Leave(object sender, EventArgs e) =>
        LoadCassette(txtCassetteEan4, txtPrice4, txtCassetteInfo4);

    private void txtCassetteEan5_Leave(object sender, EventArgs e) =>
        LoadCassette(txtCassetteEan5, txtPrice5, txtCassetteInfo5);

    private void LoadCassette(TextBox eanTextBox, TextBox priceTextBox, TextBox descriptionTextBox)
    {
        var ean = eanTextBox.Text.Trim();
        eanTextBox.Text = ean;

        var parseSuccess = decimal.TryParse(ean, NumberStyles.Any, CultureInfo.CurrentCulture, out var eanParsed);

        if (!parseSuccess)
        {
            eanTextBox.GetTag().EntityId = 0;
            priceTextBox.Text = "";
            descriptionTextBox.Text = "";
            return;
        }

        this.SetToWaitMode(true);

        // Assume that a cassette EAN code is scanned.

        // If not, assume that a movie EAN code is scanned.

        var cassettesFromMovieEan = AvailableCassette.GetAvailableCassettesFromMovieEan(eanParsed);

        var tag = eanTextBox.GetTag();

        if (cassettesFromMovieEan.Count <= 0)
        {
            tag.EntityId = 0;
            priceTextBox.Text = "";
            descriptionTextBox.Text = "";
        }
        else if (cassettesFromMovieEan.Count == 1)
        {
            var c = cassettesFromMovieEan.First();
            tag.EntityId = c.Id;
            priceTextBox.Text = c.CustomerPrice.ToString("n2");
            descriptionTextBox.Text = c.ToString();
        }
        else
        {
            // TODO: Prompt in some way...
        }

        this.SetToWaitMode(false);
    }
}