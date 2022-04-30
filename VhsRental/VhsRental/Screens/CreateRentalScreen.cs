﻿using System.Globalization;
using VhsRental.Dialogs;
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
        foreach (Control control in Controls)
        {
            if (control is not TextBox)
                continue;

            control.Text = "";
            control.GetTag().Clear();
        }

        txtSum.Text = 0m.ToString("n2");
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

        var alwaysPrompt = false;
        var cassettesFromMovieEan = AvailableCassette.GetAvailableCassettesFromMovieEan(eanParsed);

        if (cassettesFromMovieEan.Count <= 0)
            cassettesFromMovieEan = AvailableCassette.GetCassetteFromEan(eanParsed);

        if (cassettesFromMovieEan.Count <= 0)
        {
            alwaysPrompt = true;

            var c = AvailableCassette.GetUnavailableCassettesFromMovieEan(eanParsed);

            if (c != null)
                cassettesFromMovieEan.Add(c);
        }

        var tag = eanTextBox.GetTag();

        if (cassettesFromMovieEan.Count <= 0)
        {
            tag.EntityId = 0;
            priceTextBox.Text = "";
            descriptionTextBox.Text = "";
        }
        else if (cassettesFromMovieEan.Count == 1 && !alwaysPrompt)
        {
            var c = cassettesFromMovieEan.First();
            tag.EntityId = c.Id;
            priceTextBox.Text = c.CustomerPrice.ToString("n2");
            descriptionTextBox.Text = c.ToString();
        }
        else
        {
            if (string.Compare(tag.OriginalText.Trim(), eanTextBox.Text.Trim(), StringComparison.CurrentCultureIgnoreCase) == 0)
                return;

            using var x = new PromptCassetteDialog();
            x.Cassettes = cassettesFromMovieEan;
            if (x.ShowDialog(this) == DialogResult.OK)
            {
                var c = x.SelectedCassette!;
                tag.EntityId = c.Id;
                priceTextBox.Text = c.CustomerPrice.ToString("n2");
                descriptionTextBox.Text = c.ToString();
            }
            
        }

        this.SetToWaitMode(false);
    }

    private void txtPrice1_TextChanged(object sender, EventArgs e) =>
        UpdatePrice(false);

    private void txtPrice2_TextChanged(object sender, EventArgs e) =>
        UpdatePrice(false);

    private void txtPrice3_TextChanged(object sender, EventArgs e) =>
        UpdatePrice(false);

    private void txtPrice4_TextChanged(object sender, EventArgs e) =>
        UpdatePrice(false);

    private void txtPrice5_TextChanged(object sender, EventArgs e) =>
        UpdatePrice(false);

    private void UpdatePrice(bool writeBack)
    {
        var p1 = ValidatePrice(txtPrice1, txtCassetteEan1, writeBack);
        var p2 = ValidatePrice(txtPrice2, txtCassetteEan2, writeBack);
        var p3 = ValidatePrice(txtPrice3, txtCassetteEan3, writeBack);
        var p4 = ValidatePrice(txtPrice4, txtCassetteEan4, writeBack);
        var p5 = ValidatePrice(txtPrice5, txtCassetteEan5, writeBack);

        var sum = p1 + p2 + p3 + p4 + p5;

        var tag = txtSum.GetTag();
        tag.Money = sum;
        txtSum.Text = sum.ToString("n2");
    }

    private static decimal ValidatePrice(Control price, Control cassette, bool writeBack)
    {
        var tag = cassette.GetTag();

        if (tag.EntityId <= 0)
        {
            price.ForeColor = Color.DimGray;
            return 0m;
        }

        if (decimal.TryParse(price.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out var n))
        {
            price.ForeColor = Color.DarkGreen;

            if (writeBack)
                price.Text = n.ToString("n2");
            
            return n;
        }

        price.ForeColor = Color.DarkRed;

        if (writeBack)
            price.Text = price.Text.Trim();

        return 0m;
    }

    private void txtPrice1_Validated(object sender, EventArgs e) =>
        UpdatePrice(true);

    private void txtPrice2_Validated(object sender, EventArgs e) =>
        UpdatePrice(true);

    private void txtPrice3_Validated(object sender, EventArgs e) =>
        UpdatePrice(true);

    private void txtPrice4_Validated(object sender, EventArgs e) =>
        UpdatePrice(true);

    private void txtPrice5_Validated(object sender, EventArgs e) =>
        UpdatePrice(true);

    private void txtCassetteEan1_Enter(object sender, EventArgs e) =>
        txtCassetteEan1.GetTag().OriginalText = txtCassetteEan1.Text;

    private void txtCassetteEan2_Enter(object sender, EventArgs e) =>
        txtCassetteEan2.GetTag().OriginalText = txtCassetteEan2.Text;

    private void txtCassetteEan3_Enter(object sender, EventArgs e) =>
        txtCassetteEan3.GetTag().OriginalText = txtCassetteEan3.Text;

    private void txtCassetteEan4_Enter(object sender, EventArgs e) =>
        txtCassetteEan4.GetTag().OriginalText = txtCassetteEan4.Text;

    private void txtCassetteEan5_Enter(object sender, EventArgs e) =>
        txtCassetteEan5.GetTag().OriginalText = txtCassetteEan5.Text;

    private void btnAbandon_Click(object sender, EventArgs e)
    {
        if (HasCustomer() || HasAnyCassette())
            if (MessageBox.Show(@"Abandon this rental an return to main menu?", ParentForm!.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

        ((MainWindow)ParentForm).GetScreen<MainMenuScreen>();
    }

    private bool HasCustomer() =>
        txtCustomerSSN.GetTag().EntityId > 0;

    private bool HasAnyCassette() =>
        txtCassetteEan1.GetTag().EntityId > 0
        || txtCassetteEan2.GetTag().EntityId > 0
        || txtCassetteEan3.GetTag().EntityId > 0
        || txtCassetteEan4.GetTag().EntityId > 0
        || txtCassetteEan5.GetTag().EntityId > 0;

    private void btnOpenCustomer_Click(object sender, EventArgs e)
    {
        using var x = new CustomerDialog();
        x.CurrentCustomerId = txtCustomerSSN.GetTag().EntityId;

        if (x.ShowDialog() == DialogResult.OK)
        {
            this.SetToWaitMode(true);
            
            txtCustomerSSN.GetTag().EntityId = x.CurrentCustomerId;

            if (x.CurrentCustomerId <= 0)
            {

            }
            else
            {
                var customer = CustomerContactInformation.Get(x.CurrentCustomerId);

                if (customer == null)
                {
                    txtCustomerSSN.Text = "";
                    txtCustomerName.Text = "";
                }
                else
                {
                    txtCustomerSSN.Text = customer.Ssn;
                    txtCustomerName.Text = customer.ToString();
                }
            }

            this.SetToWaitMode(false);
        }
    }
}