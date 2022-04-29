﻿using VhsRentalBusinessLayer.Entities;

namespace VhsRental.Dialogs;

public partial class PromptCassetteDialog : Form
{
    public List<AvailableCassette>? Cassettes { get; set; }
    public AvailableCassette? SelectedCassette { get; set; }

    public PromptCassetteDialog()
    {
        InitializeComponent();
    }

    private void PromptCassetteDialog_Load(object sender, EventArgs e)
    {
        lv.BeginUpdate();

        foreach (var c in Cassettes!)
        {
            var i = lv.Items.Add(c.Id.ToString("000000"), 0);
            i.Tag = c;
            i.SubItems.Add(c.Title);
            i.SubItems.Add(c.Year.ToString("0000"));
            i.SubItems.Add(c.CustomerPrice.ToString("n2"));
            i.SubItems.Add(c.NumberOfCopies.ToString("n0"));
        }

        lv.EndUpdate();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (lv.SelectedItems.Count <= 0)
        {
            MessageBox.Show(@"No cassette is selected.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        SelectedCassette = (AvailableCassette)lv.SelectedItems[0].Tag;
        DialogResult = DialogResult.OK;
    }

    private void lv_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        lv.SelectedItems.Clear();

        var i = lv.GetItemAt(e.X, e.Y);

        if (i == null)
            return;

        i.Selected = true;
        SelectedCassette = (AvailableCassette)lv.SelectedItems[0].Tag;
        DialogResult = DialogResult.OK;
    }
}