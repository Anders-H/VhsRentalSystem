﻿namespace VhsRental.Screens
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAbandon
            // 
            this.btnAbandon.Location = new System.Drawing.Point(112, 4);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(104, 23);
            this.btnAbandon.TabIndex = 1;
            this.btnAbandon.Text = "Abandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            // 
            // btnOpenCustomer
            // 
            this.btnOpenCustomer.Location = new System.Drawing.Point(220, 4);
            this.btnOpenCustomer.Name = "btnOpenCustomer";
            this.btnOpenCustomer.Size = new System.Drawing.Size(104, 23);
            this.btnOpenCustomer.TabIndex = 2;
            this.btnOpenCustomer.Text = "Open customer";
            this.btnOpenCustomer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer SSN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer name:";
            // 
            // txtCustomerSSN
            // 
            this.txtCustomerSSN.Location = new System.Drawing.Point(8, 48);
            this.txtCustomerSSN.MaxLength = 50;
            this.txtCustomerSSN.Name = "txtCustomerSSN";
            this.txtCustomerSSN.Size = new System.Drawing.Size(124, 23);
            this.txtCustomerSSN.TabIndex = 5;
            this.txtCustomerSSN.Leave += new System.EventHandler(this.txtCustomerSSN_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(136, 48);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(412, 23);
            this.txtCustomerName.TabIndex = 6;
            this.txtCustomerName.TabStop = false;
            // 
            // txtCassetteInfo1
            // 
            this.txtCassetteInfo1.Location = new System.Drawing.Point(204, 92);
            this.txtCassetteInfo1.Name = "txtCassetteInfo1";
            this.txtCassetteInfo1.ReadOnly = true;
            this.txtCassetteInfo1.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo1.TabIndex = 12;
            this.txtCassetteInfo1.TabStop = false;
            // 
            // txtCassetteEan1
            // 
            this.txtCassetteEan1.Location = new System.Drawing.Point(8, 92);
            this.txtCassetteEan1.MaxLength = 16;
            this.txtCassetteEan1.Name = "txtCassetteEan1";
            this.txtCassetteEan1.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan1.TabIndex = 10;
            this.txtCassetteEan1.Leave += new System.EventHandler(this.txtCassetteEan1_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cassette information:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cassette EAN:";
            // 
            // txtCassetteInfo2
            // 
            this.txtCassetteInfo2.Location = new System.Drawing.Point(204, 120);
            this.txtCassetteInfo2.Name = "txtCassetteInfo2";
            this.txtCassetteInfo2.ReadOnly = true;
            this.txtCassetteInfo2.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo2.TabIndex = 15;
            this.txtCassetteInfo2.TabStop = false;
            // 
            // txtCassetteEan2
            // 
            this.txtCassetteEan2.Location = new System.Drawing.Point(8, 120);
            this.txtCassetteEan2.MaxLength = 16;
            this.txtCassetteEan2.Name = "txtCassetteEan2";
            this.txtCassetteEan2.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan2.TabIndex = 13;
            this.txtCassetteEan2.Leave += new System.EventHandler(this.txtCassetteEan2_Leave);
            // 
            // txtCassetteInfo3
            // 
            this.txtCassetteInfo3.Location = new System.Drawing.Point(204, 148);
            this.txtCassetteInfo3.Name = "txtCassetteInfo3";
            this.txtCassetteInfo3.ReadOnly = true;
            this.txtCassetteInfo3.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo3.TabIndex = 18;
            this.txtCassetteInfo3.TabStop = false;
            // 
            // txtCassetteEan3
            // 
            this.txtCassetteEan3.Location = new System.Drawing.Point(8, 148);
            this.txtCassetteEan3.MaxLength = 16;
            this.txtCassetteEan3.Name = "txtCassetteEan3";
            this.txtCassetteEan3.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan3.TabIndex = 16;
            this.txtCassetteEan3.Leave += new System.EventHandler(this.txtCassetteEan3_Leave);
            // 
            // txtCassetteInfo4
            // 
            this.txtCassetteInfo4.Location = new System.Drawing.Point(204, 176);
            this.txtCassetteInfo4.Name = "txtCassetteInfo4";
            this.txtCassetteInfo4.ReadOnly = true;
            this.txtCassetteInfo4.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo4.TabIndex = 21;
            this.txtCassetteInfo4.TabStop = false;
            // 
            // txtCassetteEan4
            // 
            this.txtCassetteEan4.Location = new System.Drawing.Point(8, 176);
            this.txtCassetteEan4.MaxLength = 16;
            this.txtCassetteEan4.Name = "txtCassetteEan4";
            this.txtCassetteEan4.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan4.TabIndex = 19;
            this.txtCassetteEan4.Leave += new System.EventHandler(this.txtCassetteEan4_Leave);
            // 
            // txtCassetteInfo5
            // 
            this.txtCassetteInfo5.Location = new System.Drawing.Point(204, 204);
            this.txtCassetteInfo5.Name = "txtCassetteInfo5";
            this.txtCassetteInfo5.ReadOnly = true;
            this.txtCassetteInfo5.Size = new System.Drawing.Size(344, 23);
            this.txtCassetteInfo5.TabIndex = 24;
            this.txtCassetteInfo5.TabStop = false;
            // 
            // txtCassetteEan5
            // 
            this.txtCassetteEan5.Location = new System.Drawing.Point(8, 204);
            this.txtCassetteEan5.MaxLength = 16;
            this.txtCassetteEan5.Name = "txtCassetteEan5";
            this.txtCassetteEan5.Size = new System.Drawing.Size(124, 23);
            this.txtCassetteEan5.TabIndex = 22;
            this.txtCassetteEan5.Leave += new System.EventHandler(this.txtCassetteEan5_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price:";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Location = new System.Drawing.Point(136, 92);
            this.txtPrice1.MaxLength = 16;
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(64, 23);
            this.txtPrice1.TabIndex = 11;
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice2
            // 
            this.txtPrice2.Location = new System.Drawing.Point(136, 120);
            this.txtPrice2.MaxLength = 16;
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(64, 23);
            this.txtPrice2.TabIndex = 14;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice3
            // 
            this.txtPrice3.Location = new System.Drawing.Point(136, 148);
            this.txtPrice3.MaxLength = 16;
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.Size = new System.Drawing.Size(64, 23);
            this.txtPrice3.TabIndex = 17;
            this.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice4
            // 
            this.txtPrice4.Location = new System.Drawing.Point(136, 176);
            this.txtPrice4.MaxLength = 16;
            this.txtPrice4.Name = "txtPrice4";
            this.txtPrice4.Size = new System.Drawing.Size(64, 23);
            this.txtPrice4.TabIndex = 20;
            this.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrice5
            // 
            this.txtPrice5.Location = new System.Drawing.Point(136, 204);
            this.txtPrice5.MaxLength = 16;
            this.txtPrice5.Name = "txtPrice5";
            this.txtPrice5.Size = new System.Drawing.Size(64, 23);
            this.txtPrice5.TabIndex = 23;
            this.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 232);
            this.textBox1.MaxLength = 16;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(64, 23);
            this.textBox1.TabIndex = 25;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CreateRentalScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.Controls.Add(this.textBox1);
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
        private TextBox textBox1;
    }
}