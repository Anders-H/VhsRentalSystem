namespace VhsRental.Dialogs;

public partial class RentalTransactionDialog : Form
{
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public int RentalEventTransactionId { get; set; }

    public RentalTransactionDialog()
    {
        InitializeComponent();
    }
}