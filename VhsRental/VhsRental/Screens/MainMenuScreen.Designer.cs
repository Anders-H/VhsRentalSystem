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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnCreateRental = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(8, 8);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(332, 23);
            this.btnLogIn.TabIndex = 0;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnCreateRental
            // 
            this.btnCreateRental.Location = new System.Drawing.Point(8, 36);
            this.btnCreateRental.Name = "btnCreateRental";
            this.btnCreateRental.Size = new System.Drawing.Size(332, 23);
            this.btnCreateRental.TabIndex = 1;
            this.btnCreateRental.Text = "Create rental";
            this.btnCreateRental.UseVisualStyleBackColor = true;
            this.btnCreateRental.Click += new System.EventHandler(this.btnCreateRental_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.Controls.Add(this.btnCreateRental);
            this.Controls.Add(this.btnLogIn);
            this.Name = "MainMenuScreen";
            this.Size = new System.Drawing.Size(347, 474);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLogIn;
        private Button btnCreateRental;
    }
}
