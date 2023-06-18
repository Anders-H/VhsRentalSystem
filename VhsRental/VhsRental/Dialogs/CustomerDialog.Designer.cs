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
            label1 = new Label();
            customerCoreDataControl1 = new CustomControls.CustomerCoreDataControl();
            btnOk = new Button();
            btnCancel = new Button();
            txtCustomerSsn = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Selected customer:";
            // 
            // customerCoreDataControl1
            // 
            customerCoreDataControl1.Location = new Point(4, 32);
            customerCoreDataControl1.Name = "customerCoreDataControl1";
            customerCoreDataControl1.Size = new Size(771, 252);
            customerCoreDataControl1.TabIndex = 2;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(616, 288);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.CausesValidation = false;
            btnCancel.Location = new Point(696, 288);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCustomerSsn
            // 
            txtCustomerSsn.Location = new Point(120, 4);
            txtCustomerSsn.Name = "txtCustomerSsn";
            txtCustomerSsn.Size = new Size(172, 23);
            txtCustomerSsn.TabIndex = 1;
            txtCustomerSsn.TextChanged += txtCustomerSsn_TextChanged;
            txtCustomerSsn.Validating += txtCustomerSsn_Validating;
            // 
            // CustomerDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(777, 315);
            Controls.Add(txtCustomerSsn);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(customerCoreDataControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer";
            Shown += CustomerDialog_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CustomControls.CustomerCoreDataControl customerCoreDataControl1;
        private Button btnOk;
        private Button btnCancel;
        private TextBox txtCustomerSsn;
    }
}