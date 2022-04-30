namespace VhsRental.CustomControls
{
    public partial class CustomerCoreDataControl : UserControl
    {
        public CustomerCoreDataControl()
        {
            InitializeComponent();
        }

        private void CustomerCoreDataControl_Resize(object sender, EventArgs e)
        {
            Width = 771;
            Height = 252;
        }
    }
}
