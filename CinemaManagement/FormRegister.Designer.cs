
namespace CinemaManagement
{
    partial class Form1
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxFirst_Name = new System.Windows.Forms.TextBox();
            this.textBoxLast_Name = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelFirst_Name = new System.Windows.Forms.Label();
            this.labelLast_Name = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelResponse = new System.Windows.Forms.Label();
            this.textBoxPIN = new System.Windows.Forms.TextBox();
            this.labelRegisterResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 326);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxFirst_Name
            // 
            this.textBoxFirst_Name.Location = new System.Drawing.Point(107, 84);
            this.textBoxFirst_Name.Name = "textBoxFirst_Name";
            this.textBoxFirst_Name.Size = new System.Drawing.Size(188, 23);
            this.textBoxFirst_Name.TabIndex = 1;
            // 
            // textBoxLast_Name
            // 
            this.textBoxLast_Name.Location = new System.Drawing.Point(107, 140);
            this.textBoxLast_Name.Name = "textBoxLast_Name";
            this.textBoxLast_Name.Size = new System.Drawing.Size(188, 23);
            this.textBoxLast_Name.TabIndex = 2;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(107, 199);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(188, 23);
            this.textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(107, 256);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(188, 23);
            this.textBoxPassword.TabIndex = 4;
            // 
            // labelFirst_Name
            // 
            this.labelFirst_Name.AutoSize = true;
            this.labelFirst_Name.Location = new System.Drawing.Point(43, 91);
            this.labelFirst_Name.Name = "labelFirst_Name";
            this.labelFirst_Name.Size = new System.Drawing.Size(62, 15);
            this.labelFirst_Name.TabIndex = 5;
            this.labelFirst_Name.Text = "First name";
            // 
            // labelLast_Name
            // 
            this.labelLast_Name.AutoSize = true;
            this.labelLast_Name.Location = new System.Drawing.Point(43, 147);
            this.labelLast_Name.Name = "labelLast_Name";
            this.labelLast_Name.Size = new System.Drawing.Size(63, 15);
            this.labelLast_Name.TabIndex = 6;
            this.labelLast_Name.Text = "Last Name";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(43, 206);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(60, 15);
            this.labelUsername.TabIndex = 7;
            this.labelUsername.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(82, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Adding new customer";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(167, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 10;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(36, 304);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(56, 15);
            this.labelResponse.TabIndex = 11;
            this.labelResponse.Text = "Tajny PIN";
            // 
            // textBoxPIN
            // 
            this.textBoxPIN.Location = new System.Drawing.Point(98, 301);
            this.textBoxPIN.Name = "textBoxPIN";
            this.textBoxPIN.PasswordChar = '*';
            this.textBoxPIN.Size = new System.Drawing.Size(63, 23);
            this.textBoxPIN.TabIndex = 13;
            // 
            // labelRegisterResult
            // 
            this.labelRegisterResult.AutoSize = true;
            this.labelRegisterResult.Location = new System.Drawing.Point(167, 280);
            this.labelRegisterResult.Name = "labelRegisterResult";
            this.labelRegisterResult.Size = new System.Drawing.Size(0, 15);
            this.labelRegisterResult.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.labelRegisterResult);
            this.Controls.Add(this.textBoxPIN);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelLast_Name);
            this.Controls.Add(this.labelFirst_Name);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxLast_Name);
            this.Controls.Add(this.textBoxFirst_Name);
            this.Controls.Add(this.buttonLogin);
            this.Name = "Form1";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxFirst_Name;
        private System.Windows.Forms.TextBox textBoxLast_Name;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelFirst_Name;
        private System.Windows.Forms.Label labelLast_Name;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.TextBox textBoxPIN;
        private System.Windows.Forms.Label labelRegisterResult;
    }
}