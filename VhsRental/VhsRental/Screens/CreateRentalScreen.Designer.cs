namespace VhsRental.Screens
{
    partial class CreateRentalScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            btnAbandon = new Button();
            btnOpenCustomer = new Button();
            label1 = new Label();
            label2 = new Label();
            txtCustomerSSN = new TextBox();
            txtCustomerName = new TextBox();
            txtCassetteInfo1 = new TextBox();
            txtCassetteEan1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtCassetteInfo2 = new TextBox();
            txtCassetteEan2 = new TextBox();
            txtCassetteInfo3 = new TextBox();
            txtCassetteEan3 = new TextBox();
            txtCassetteInfo4 = new TextBox();
            txtCassetteEan4 = new TextBox();
            txtCassetteInfo5 = new TextBox();
            txtCassetteEan5 = new TextBox();
            label5 = new Label();
            txtPrice1 = new TextBox();
            txtPrice2 = new TextBox();
            txtPrice3 = new TextBox();
            txtPrice4 = new TextBox();
            txtPrice5 = new TextBox();
            txtSum = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(4, 236);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 23);
            btnSave.TabIndex = 23;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAbandon
            // 
            btnAbandon.Location = new Point(112, 236);
            btnAbandon.Name = "btnAbandon";
            btnAbandon.Size = new Size(104, 23);
            btnAbandon.TabIndex = 24;
            btnAbandon.Text = "Abandon";
            btnAbandon.UseVisualStyleBackColor = true;
            btnAbandon.Click += btnAbandon_Click;
            // 
            // btnOpenCustomer
            // 
            btnOpenCustomer.Enabled = false;
            btnOpenCustomer.Location = new Point(220, 236);
            btnOpenCustomer.Name = "btnOpenCustomer";
            btnOpenCustomer.Size = new Size(104, 23);
            btnOpenCustomer.TabIndex = 25;
            btnOpenCustomer.Text = "Open customer";
            btnOpenCustomer.UseVisualStyleBackColor = true;
            btnOpenCustomer.Click += btnOpenCustomer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 0;
            label1.Text = "Customer SSN:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 8);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 2;
            label2.Text = "Customer name:";
            // 
            // txtCustomerSSN
            // 
            txtCustomerSSN.Location = new Point(8, 24);
            txtCustomerSSN.MaxLength = 50;
            txtCustomerSSN.Name = "txtCustomerSSN";
            txtCustomerSSN.Size = new Size(124, 23);
            txtCustomerSSN.TabIndex = 1;
            txtCustomerSSN.TextChanged += txtCustomerSSN_TextChanged;
            txtCustomerSSN.Validating += txtCustomerSSN_Validating;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(136, 24);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Size = new Size(412, 23);
            txtCustomerName.TabIndex = 3;
            txtCustomerName.TabStop = false;
            // 
            // txtCassetteInfo1
            // 
            txtCassetteInfo1.Location = new Point(204, 68);
            txtCassetteInfo1.Name = "txtCassetteInfo1";
            txtCassetteInfo1.ReadOnly = true;
            txtCassetteInfo1.Size = new Size(344, 23);
            txtCassetteInfo1.TabIndex = 9;
            txtCassetteInfo1.TabStop = false;
            // 
            // txtCassetteEan1
            // 
            txtCassetteEan1.Location = new Point(8, 68);
            txtCassetteEan1.MaxLength = 16;
            txtCassetteEan1.Name = "txtCassetteEan1";
            txtCassetteEan1.Size = new Size(124, 23);
            txtCassetteEan1.TabIndex = 5;
            txtCassetteEan1.Enter += txtCassetteEan1_Enter;
            txtCassetteEan1.Leave += txtCassetteEan1_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 52);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 8;
            label3.Text = "Cassette information:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 52);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 4;
            label4.Text = "Cassette EAN:";
            // 
            // txtCassetteInfo2
            // 
            txtCassetteInfo2.Location = new Point(204, 96);
            txtCassetteInfo2.Name = "txtCassetteInfo2";
            txtCassetteInfo2.ReadOnly = true;
            txtCassetteInfo2.Size = new Size(344, 23);
            txtCassetteInfo2.TabIndex = 12;
            txtCassetteInfo2.TabStop = false;
            // 
            // txtCassetteEan2
            // 
            txtCassetteEan2.Location = new Point(8, 96);
            txtCassetteEan2.MaxLength = 16;
            txtCassetteEan2.Name = "txtCassetteEan2";
            txtCassetteEan2.Size = new Size(124, 23);
            txtCassetteEan2.TabIndex = 10;
            txtCassetteEan2.Enter += txtCassetteEan2_Enter;
            txtCassetteEan2.Leave += txtCassetteEan2_Leave;
            // 
            // txtCassetteInfo3
            // 
            txtCassetteInfo3.Location = new Point(204, 124);
            txtCassetteInfo3.Name = "txtCassetteInfo3";
            txtCassetteInfo3.ReadOnly = true;
            txtCassetteInfo3.Size = new Size(344, 23);
            txtCassetteInfo3.TabIndex = 15;
            txtCassetteInfo3.TabStop = false;
            // 
            // txtCassetteEan3
            // 
            txtCassetteEan3.Location = new Point(8, 124);
            txtCassetteEan3.MaxLength = 16;
            txtCassetteEan3.Name = "txtCassetteEan3";
            txtCassetteEan3.Size = new Size(124, 23);
            txtCassetteEan3.TabIndex = 13;
            txtCassetteEan3.Enter += txtCassetteEan3_Enter;
            txtCassetteEan3.Leave += txtCassetteEan3_Leave;
            // 
            // txtCassetteInfo4
            // 
            txtCassetteInfo4.Location = new Point(204, 152);
            txtCassetteInfo4.Name = "txtCassetteInfo4";
            txtCassetteInfo4.ReadOnly = true;
            txtCassetteInfo4.Size = new Size(344, 23);
            txtCassetteInfo4.TabIndex = 18;
            txtCassetteInfo4.TabStop = false;
            // 
            // txtCassetteEan4
            // 
            txtCassetteEan4.Location = new Point(8, 152);
            txtCassetteEan4.MaxLength = 16;
            txtCassetteEan4.Name = "txtCassetteEan4";
            txtCassetteEan4.Size = new Size(124, 23);
            txtCassetteEan4.TabIndex = 16;
            txtCassetteEan4.Enter += txtCassetteEan4_Enter;
            txtCassetteEan4.Leave += txtCassetteEan4_Leave;
            // 
            // txtCassetteInfo5
            // 
            txtCassetteInfo5.Location = new Point(204, 180);
            txtCassetteInfo5.Name = "txtCassetteInfo5";
            txtCassetteInfo5.ReadOnly = true;
            txtCassetteInfo5.Size = new Size(344, 23);
            txtCassetteInfo5.TabIndex = 21;
            txtCassetteInfo5.TabStop = false;
            // 
            // txtCassetteEan5
            // 
            txtCassetteEan5.Location = new Point(8, 180);
            txtCassetteEan5.MaxLength = 16;
            txtCassetteEan5.Name = "txtCassetteEan5";
            txtCassetteEan5.Size = new Size(124, 23);
            txtCassetteEan5.TabIndex = 19;
            txtCassetteEan5.Enter += txtCassetteEan5_Enter;
            txtCassetteEan5.Leave += txtCassetteEan5_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 52);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 6;
            label5.Text = "Price:";
            // 
            // txtPrice1
            // 
            txtPrice1.Location = new Point(136, 68);
            txtPrice1.MaxLength = 16;
            txtPrice1.Name = "txtPrice1";
            txtPrice1.Size = new Size(64, 23);
            txtPrice1.TabIndex = 7;
            txtPrice1.TextAlign = HorizontalAlignment.Right;
            txtPrice1.TextChanged += txtPrice1_TextChanged;
            txtPrice1.Validated += txtPrice1_Validated;
            // 
            // txtPrice2
            // 
            txtPrice2.Location = new Point(136, 96);
            txtPrice2.MaxLength = 16;
            txtPrice2.Name = "txtPrice2";
            txtPrice2.Size = new Size(64, 23);
            txtPrice2.TabIndex = 11;
            txtPrice2.TextAlign = HorizontalAlignment.Right;
            txtPrice2.TextChanged += txtPrice2_TextChanged;
            txtPrice2.Validated += txtPrice2_Validated;
            // 
            // txtPrice3
            // 
            txtPrice3.Location = new Point(136, 124);
            txtPrice3.MaxLength = 16;
            txtPrice3.Name = "txtPrice3";
            txtPrice3.Size = new Size(64, 23);
            txtPrice3.TabIndex = 14;
            txtPrice3.TextAlign = HorizontalAlignment.Right;
            txtPrice3.TextChanged += txtPrice3_TextChanged;
            txtPrice3.Validated += txtPrice3_Validated;
            // 
            // txtPrice4
            // 
            txtPrice4.Location = new Point(136, 152);
            txtPrice4.MaxLength = 16;
            txtPrice4.Name = "txtPrice4";
            txtPrice4.Size = new Size(64, 23);
            txtPrice4.TabIndex = 17;
            txtPrice4.TextAlign = HorizontalAlignment.Right;
            txtPrice4.TextChanged += txtPrice4_TextChanged;
            txtPrice4.Validated += txtPrice4_Validated;
            // 
            // txtPrice5
            // 
            txtPrice5.Location = new Point(136, 180);
            txtPrice5.MaxLength = 16;
            txtPrice5.Name = "txtPrice5";
            txtPrice5.Size = new Size(64, 23);
            txtPrice5.TabIndex = 20;
            txtPrice5.TextAlign = HorizontalAlignment.Right;
            txtPrice5.TextChanged += txtPrice5_TextChanged;
            txtPrice5.Validated += txtPrice5_Validated;
            // 
            // txtSum
            // 
            txtSum.Location = new Point(136, 208);
            txtSum.MaxLength = 16;
            txtSum.Name = "txtSum";
            txtSum.ReadOnly = true;
            txtSum.Size = new Size(64, 23);
            txtSum.TabIndex = 22;
            txtSum.TabStop = false;
            txtSum.TextAlign = HorizontalAlignment.Right;
            // 
            // CreateRentalScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(4, 4);
            Controls.Add(txtSum);
            Controls.Add(txtPrice5);
            Controls.Add(txtPrice4);
            Controls.Add(txtPrice3);
            Controls.Add(txtPrice2);
            Controls.Add(txtPrice1);
            Controls.Add(label5);
            Controls.Add(txtCassetteInfo5);
            Controls.Add(txtCassetteEan5);
            Controls.Add(txtCassetteInfo4);
            Controls.Add(txtCassetteEan4);
            Controls.Add(txtCassetteInfo3);
            Controls.Add(txtCassetteEan3);
            Controls.Add(txtCassetteInfo2);
            Controls.Add(txtCassetteEan2);
            Controls.Add(txtCassetteInfo1);
            Controls.Add(txtCassetteEan1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtCustomerName);
            Controls.Add(txtCustomerSSN);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOpenCustomer);
            Controls.Add(btnAbandon);
            Controls.Add(btnSave);
            Name = "CreateRentalScreen";
            Size = new Size(650, 484);
            Load += CreateRentalScreen_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnSave;
        private Button btnAbandon;
        private Button btnOpenCustomer;
        private Label label1;
        private Label label2;
        private TextBox txtCustomerSSN;
        private TextBox txtCustomerName;
        private TextBox txtCassetteInfo1;
        private TextBox txtCassetteEan1;
        private Label label3;
        private Label label4;
        private TextBox txtCassetteInfo2;
        private TextBox txtCassetteEan2;
        private TextBox txtCassetteInfo3;
        private TextBox txtCassetteEan3;
        private TextBox txtCassetteInfo4;
        private TextBox txtCassetteEan4;
        private TextBox txtCassetteInfo5;
        private TextBox txtCassetteEan5;
        private Label label5;
        private TextBox txtPrice1;
        private TextBox txtPrice2;
        private TextBox txtPrice3;
        private TextBox txtPrice4;
        private TextBox txtPrice5;
        private TextBox txtSum;
    }
}
