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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbandon = new System.Windows.Forms.Button();
            this.btnOpenCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerSSN = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCassetteInfo1 = new System.Windows.Forms.TextBox();
            this.txtCassetteEan1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCassetteInfo2 = new System.Windows.Forms.TextBox();
            this.txtCassetteEan2 = new System.Windows.Forms.TextBox();
            this.txtCassetteInfo3 = new System.Windows.Forms.TextBox();
            this.txtCassetteEan3 = new System.Windows.Forms.TextBox();
            this.txtCassetteInfo4 = new System.Windows.Forms.TextBox();
            this.txtCassetteEan4 = new System.Windows.Forms.TextBox();
            this.txtCassetteInfo5 = new System.Windows.Forms.TextBox();
            this.txtCassetteEan5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.txtPrice3 = new System.Windows.Forms.TextBox();
            this.txtPrice4 = new System.Windows.Forms.TextBox();
            this.txtPrice5 = new System.Windows.Forms.TextBox();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbandon
            // 
            this.btnAbandon.Location = new System.Drawing.Point(112, 236);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(104, 23);
            this.btnAbandon.TabIndex = 24;
            this.btnAbandon.Text = "Abandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            // 
            // btnOpenCustomer
            // 
            this.btnOpenCustomer.Enabled = false;
            this.btnOpenCustomer.Location = new System.Drawing.Point(220, 236);
            this.btnOpenCustomer.Name = "btnOpenCustomer";
            this.btnOpenCustomer.Size = new System.Drawing.Size(104, 23);
            this.btnOpenCustomer.TabIndex = 25;
            this.btnOpenCustomer.Text = "Open customer";
            this.btnOpenCustomer.UseVisualStyleBackColor = true;
            this.btnOpenCustomer.Click += new System.EventHandler(this.btnOpenCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer SSN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer name:";
            // 
            // txtCustomerSSN
            // 
            this.txtCustomerSSN.Location = new System.Drawing.Point(8, 24);
            this.txtCustomerSSN.MaxLength = 50;
            this.txtCustomerSSN.Name = "txtCustomerSSN";
            this.txtCustomerSSN.Size = new System.Drawing.Size(124, 23);
            this.txtCustomerSSN.TabIndex = 1;
            this.txtCustomerSSN.TextChanged += new System.EventHandler(this.txtCustomerSSN_TextChanged);
            this.txtCustomerSSN.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustomerSSN_Validating);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(136, 24);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(412, 23);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.TabStop = false;
            // 
            // txtCassetteInfo1
            // 
            this.txtCassetteInfo1.Location = new System.Drawing.Point(204, 68);
            this.txtCassetteInfo1.Name = "txtCassetteInfo1";
            this.txtCassetteInfo1.ReadOnly = true;
            this.txtCassetteInfo1.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo1.TabIndex = 9;
            this.txtCassetteInfo1.TabStop = false;
            // 
            // txtCassetteEan1
            // 
            this.txtCassetteEan1.Location = new System.Drawing.Point(8, 68);
            this.txtCassetteEan1.MaxLength = 16;
            this.txtCassetteEan1.Name = "txtCassetteEan1";
            this.txtCassetteEan1.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan1.TabIndex = 5;
            this.txtCassetteEan1.Enter += new System.EventHandler(this.txtCassetteEan1_Enter);
            this.txtCassetteEan1.Leave += new System.EventHandler(this.txtCassetteEan1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cassette information:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cassette EAN:";
            // 
            // txtCassetteInfo2
            // 
            this.txtCassetteInfo2.Location = new System.Drawing.Point(204, 96);
            this.txtCassetteInfo2.Name = "txtCassetteInfo2";
            this.txtCassetteInfo2.ReadOnly = true;
            this.txtCassetteInfo2.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo2.TabIndex = 12;
            this.txtCassetteInfo2.TabStop = false;
            // 
            // txtCassetteEan2
            // 
            this.txtCassetteEan2.Location = new System.Drawing.Point(8, 96);
            this.txtCassetteEan2.MaxLength = 16;
            this.txtCassetteEan2.Name = "txtCassetteEan2";
            this.txtCassetteEan2.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan2.TabIndex = 10;
            this.txtCassetteEan2.Enter += new System.EventHandler(this.txtCassetteEan2_Enter);
            this.txtCassetteEan2.Leave += new System.EventHandler(this.txtCassetteEan2_Leave);
            // 
            // txtCassetteInfo3
            // 
            this.txtCassetteInfo3.Location = new System.Drawing.Point(204, 124);
            this.txtCassetteInfo3.Name = "txtCassetteInfo3";
            this.txtCassetteInfo3.ReadOnly = true;
            this.txtCassetteInfo3.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo3.TabIndex = 15;
            this.txtCassetteInfo3.TabStop = false;
            // 
            // txtCassetteEan3
            // 
            this.txtCassetteEan3.Location = new System.Drawing.Point(8, 124);
            this.txtCassetteEan3.MaxLength = 16;
            this.txtCassetteEan3.Name = "txtCassetteEan3";
            this.txtCassetteEan3.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan3.TabIndex = 13;
            this.txtCassetteEan3.Enter += new System.EventHandler(this.txtCassetteEan3_Enter);
            this.txtCassetteEan3.Leave += new System.EventHandler(this.txtCassetteEan3_Leave);
            // 
            // txtCassetteInfo4
            // 
            this.txtCassetteInfo4.Location = new System.Drawing.Point(204, 152);
            this.txtCassetteInfo4.Name = "txtCassetteInfo4";
            this.txtCassetteInfo4.ReadOnly = true;
            this.txtCassetteInfo4.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo4.TabIndex = 18;
            this.txtCassetteInfo4.TabStop = false;
            // 
            // txtCassetteEan4
            // 
            this.txtCassetteEan4.Location = new System.Drawing.Point(8, 152);
            this.txtCassetteEan4.MaxLength = 16;
            this.txtCassetteEan4.Name = "txtCassetteEan4";
            this.txtCassetteEan4.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan4.TabIndex = 16;
            this.txtCassetteEan4.Enter += new System.EventHandler(this.txtCassetteEan4_Enter);
            this.txtCassetteEan4.Leave += new System.EventHandler(this.txtCassetteEan4_Leave);
            // 
            // txtCassetteInfo5
            // 
            this.txtCassetteInfo5.Location = new System.Drawing.Point(204, 180);
            this.txtCassetteInfo5.Name = "txtCassetteInfo5";
            this.txtCassetteInfo5.ReadOnly = true;
            this.txtCassetteInfo5.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo5.TabIndex = 21;
            this.txtCassetteInfo5.TabStop = false;
            // 
            // txtCassetteEan5
            // 
            this.txtCassetteEan5.Location = new System.Drawing.Point(8, 180);
            this.txtCassetteEan5.MaxLength = 16;
            this.txtCassetteEan5.Name = "txtCassetteEan5";
            this.txtCassetteEan5.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan5.TabIndex = 19;
            this.txtCassetteEan5.Enter += new System.EventHandler(this.txtCassetteEan5_Enter);
            this.txtCassetteEan5.Leave += new System.EventHandler(this.txtCassetteEan5_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Price:";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Location = new System.Drawing.Point(136, 68);
            this.txtPrice1.MaxLength = 16;
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(64, 23);
            this.txtPrice1.TabIndex = 7;
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice1.TextChanged += new System.EventHandler(this.txtPrice1_TextChanged);
            this.txtPrice1.Validated += new System.EventHandler(this.txtPrice1_Validated);
            // 
            // txtPrice2
            // 
            this.txtPrice2.Location = new System.Drawing.Point(136, 96);
            this.txtPrice2.MaxLength = 16;
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(64, 23);
            this.txtPrice2.TabIndex = 11;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice2.TextChanged += new System.EventHandler(this.txtPrice2_TextChanged);
            this.txtPrice2.Validated += new System.EventHandler(this.txtPrice2_Validated);
            // 
            // txtPrice3
            // 
            this.txtPrice3.Location = new System.Drawing.Point(136, 124);
            this.txtPrice3.MaxLength = 16;
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.Size = new System.Drawing.Size(64, 23);
            this.txtPrice3.TabIndex = 14;
            this.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice3.TextChanged += new System.EventHandler(this.txtPrice3_TextChanged);
            this.txtPrice3.Validated += new System.EventHandler(this.txtPrice3_Validated);
            // 
            // txtPrice4
            // 
            this.txtPrice4.Location = new System.Drawing.Point(136, 152);
            this.txtPrice4.MaxLength = 16;
            this.txtPrice4.Name = "txtPrice4";
            this.txtPrice4.Size = new System.Drawing.Size(64, 23);
            this.txtPrice4.TabIndex = 17;
            this.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice4.TextChanged += new System.EventHandler(this.txtPrice4_TextChanged);
            this.txtPrice4.Validated += new System.EventHandler(this.txtPrice4_Validated);
            // 
            // txtPrice5
            // 
            this.txtPrice5.Location = new System.Drawing.Point(136, 180);
            this.txtPrice5.MaxLength = 16;
            this.txtPrice5.Name = "txtPrice5";
            this.txtPrice5.Size = new System.Drawing.Size(64, 23);
            this.txtPrice5.TabIndex = 20;
            this.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice5.TextChanged += new System.EventHandler(this.txtPrice5_TextChanged);
            this.txtPrice5.Validated += new System.EventHandler(this.txtPrice5_Validated);
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(136, 208);
            this.txtSum.MaxLength = 16;
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(64, 23);
            this.txtSum.TabIndex = 22;
            this.txtSum.TabStop = false;
            this.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CreateRentalScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.txtPrice5);
            this.Controls.Add(this.txtPrice4);
            this.Controls.Add(this.txtPrice3);
            this.Controls.Add(this.txtPrice2);
            this.Controls.Add(this.txtPrice1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCassetteInfo5);
            this.Controls.Add(this.txtCassetteEan5);
            this.Controls.Add(this.txtCassetteInfo4);
            this.Controls.Add(this.txtCassetteEan4);
            this.Controls.Add(this.txtCassetteInfo3);
            this.Controls.Add(this.txtCassetteEan3);
            this.Controls.Add(this.txtCassetteInfo2);
            this.Controls.Add(this.txtCassetteEan2);
            this.Controls.Add(this.txtCassetteInfo1);
            this.Controls.Add(this.txtCassetteEan1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerSSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenCustomer);
            this.Controls.Add(this.btnAbandon);
            this.Controls.Add(this.btnSave);
            this.Name = "CreateRentalScreen";
            this.Size = new System.Drawing.Size(650, 484);
            this.Load += new System.EventHandler(this.CreateRentalScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
