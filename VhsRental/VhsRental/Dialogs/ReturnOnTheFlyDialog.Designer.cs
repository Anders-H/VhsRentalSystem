namespace VhsRental.Dialogs
{
    partial class ReturnOnTheFlyDialog
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
            txtEan = new TextBox();
            txtTitle = new TextBox();
            label2 = new Label();
            txtYear = new TextBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            btnContinue = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "EAN:";
            // 
            // txtEan
            // 
            txtEan.Location = new Point(8, 24);
            txtEan.Name = "txtEan";
            txtEan.ReadOnly = true;
            txtEan.Size = new Size(132, 23);
            txtEan.TabIndex = 1;
            txtEan.TabStop = false;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(144, 24);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.Size = new Size(296, 23);
            txtTitle.TabIndex = 3;
            txtTitle.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 8);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 2;
            label2.Text = "Title:";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(444, 24);
            txtYear.Name = "txtYear";
            txtYear.ReadOnly = true;
            txtYear.Size = new Size(64, 23);
            txtYear.TabIndex = 5;
            txtYear.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(444, 8);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 4;
            label3.Text = "Year:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(8, 64);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(500, 23);
            txtDescription.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 48);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 6;
            label4.Text = "Ocular inspection:";
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(432, 100);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(75, 23);
            btnContinue.TabIndex = 8;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // ReturnOnTheFlyDialog
            // 
            AcceptButton = btnContinue;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 129);
            Controls.Add(btnContinue);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(txtYear);
            Controls.Add(label3);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(txtEan);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReturnOnTheFlyDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cassette is out";
            Load += ReturnOnTheFlyDialog_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtEan;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtYear;
        private Label label3;
        private TextBox txtDescription;
        private Label label4;
        private Button btnContinue;
    }
}