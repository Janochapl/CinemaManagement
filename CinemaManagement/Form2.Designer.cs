
namespace CinemaManagement
{
    partial class Form2
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelWorker = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxShowings = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonManageShowings = new System.Windows.Forms.Button();
            this.buttonManageFilms = new System.Windows.Forms.Button();
            this.buttonManageHalls = new System.Windows.Forms.Button();
            this.buttonManageRevervations = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(653, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(144, 50);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Hello, ";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWorker
            // 
            this.labelWorker.AutoSize = true;
            this.labelWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWorker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWorker.Location = new System.Drawing.Point(653, 463);
            this.labelWorker.Name = "labelWorker";
            this.labelWorker.Size = new System.Drawing.Size(144, 60);
            this.labelWorker.TabIndex = 1;
            this.labelWorker.Text = "Account: customer/worker";
            this.labelWorker.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(653, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change account details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxShowings, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonManageShowings, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonManageFilms, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonManageHalls, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonManageRevervations, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelWorker, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonLogout, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 523);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // listBoxShowings
            // 
            this.listBoxShowings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxShowings.FormattingEnabled = true;
            this.listBoxShowings.ItemHeight = 15;
            this.listBoxShowings.Location = new System.Drawing.Point(3, 53);
            this.listBoxShowings.Name = "listBoxShowings";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxShowings, 8);
            this.listBoxShowings.Size = new System.Drawing.Size(644, 467);
            this.listBoxShowings.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "Showings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonManageShowings
            // 
            this.buttonManageShowings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonManageShowings.Location = new System.Drawing.Point(653, 230);
            this.buttonManageShowings.Name = "buttonManageShowings";
            this.buttonManageShowings.Size = new System.Drawing.Size(144, 53);
            this.buttonManageShowings.TabIndex = 7;
            this.buttonManageShowings.Text = "Manage Showings";
            this.buttonManageShowings.UseVisualStyleBackColor = true;
            this.buttonManageShowings.Click += new System.EventHandler(this.buttonManageShowings_Click);
            // 
            // buttonManageFilms
            // 
            this.buttonManageFilms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonManageFilms.Location = new System.Drawing.Point(653, 171);
            this.buttonManageFilms.Name = "buttonManageFilms";
            this.buttonManageFilms.Size = new System.Drawing.Size(144, 53);
            this.buttonManageFilms.TabIndex = 6;
            this.buttonManageFilms.Text = "Manage Movies";
            this.buttonManageFilms.UseVisualStyleBackColor = true;
            this.buttonManageFilms.Click += new System.EventHandler(this.buttonManageFilms_Click);
            // 
            // buttonManageHalls
            // 
            this.buttonManageHalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonManageHalls.Location = new System.Drawing.Point(653, 289);
            this.buttonManageHalls.Name = "buttonManageHalls";
            this.buttonManageHalls.Size = new System.Drawing.Size(144, 53);
            this.buttonManageHalls.TabIndex = 5;
            this.buttonManageHalls.Text = "Manage Halls";
            this.buttonManageHalls.UseVisualStyleBackColor = true;
            this.buttonManageHalls.Click += new System.EventHandler(this.buttonManageHalls_Click);
            // 
            // buttonManageRevervations
            // 
            this.buttonManageRevervations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonManageRevervations.Location = new System.Drawing.Point(653, 112);
            this.buttonManageRevervations.Name = "buttonManageRevervations";
            this.buttonManageRevervations.Size = new System.Drawing.Size(144, 53);
            this.buttonManageRevervations.TabIndex = 8;
            this.buttonManageRevervations.Text = "Manage Revervations";
            this.buttonManageRevervations.UseVisualStyleBackColor = true;
            this.buttonManageRevervations.Click += new System.EventHandler(this.buttonManageRevervations_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogout.Location = new System.Drawing.Point(653, 348);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(144, 53);
            this.buttonLogout.TabIndex = 9;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelWorker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxShowings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonManageShowings;
        private System.Windows.Forms.Button buttonManageFilms;
        private System.Windows.Forms.Button buttonManageHalls;
        private System.Windows.Forms.Button buttonManageRevervations;
        private System.Windows.Forms.Button buttonLogout;
    }
}