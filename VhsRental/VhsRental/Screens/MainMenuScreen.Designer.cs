namespace VhsRental.Screens
{
    partial class MainMenuScreen
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
            btnLogIn = new Button();
            btnCreateRental = new Button();
            btnCustomers = new Button();
            SuspendLayout();
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(8, 64);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(332, 23);
            btnLogIn.TabIndex = 2;
            btnLogIn.Text = "Log in";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnCreateRental
            // 
            btnCreateRental.Location = new Point(8, 8);
            btnCreateRental.Name = "btnCreateRental";
            btnCreateRental.Size = new Size(332, 23);
            btnCreateRental.TabIndex = 0;
            btnCreateRental.Text = "Create rental";
            btnCreateRental.UseVisualStyleBackColor = true;
            btnCreateRental.Click += btnCreateRental_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(8, 36);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(332, 23);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // MainMenuScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(4, 4);
            Controls.Add(btnCustomers);
            Controls.Add(btnCreateRental);
            Controls.Add(btnLogIn);
            Name = "MainMenuScreen";
            Size = new Size(569, 474);
            ResumeLayout(false);

        }

        #endregion

        private Button btnLogIn;
        private Button btnCreateRental;
        private Button btnCustomers;
    }
}
