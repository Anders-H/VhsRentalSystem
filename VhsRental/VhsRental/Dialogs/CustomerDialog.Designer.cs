namespace VhsRental.Dialogs
{
    partial class CustomerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomerSsn = new System.Windows.Forms.ComboBox();
            this.customerCoreDataControl1 = new VhsRental.CustomControls.CustomerCoreDataControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected customer:";
            // 
            // cboCustomerSsn
            // 
            this.cboCustomerSsn.FormattingEnabled = true;
            this.cboCustomerSsn.Location = new System.Drawing.Point(120, 4);
            this.cboCustomerSsn.Name = "cboCustomerSsn";
            this.cboCustomerSsn.Size = new System.Drawing.Size(168, 23);
            this.cboCustomerSsn.TabIndex = 1;
            // 
            // customerCoreDataControl1
            // 
            this.customerCoreDataControl1.Location = new System.Drawing.Point(4, 32);
            this.customerCoreDataControl1.Name = "customerCoreDataControl1";
            this.customerCoreDataControl1.Size = new System.Drawing.Size(771, 252);
            this.customerCoreDataControl1.TabIndex = 2;
            // 
            // CustomerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 365);
            this.Controls.Add(this.customerCoreDataControl1);
            this.Controls.Add(this.cboCustomerSsn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cboCustomerSsn;
        private CustomControls.CustomerCoreDataControl customerCoreDataControl1;
    }
}