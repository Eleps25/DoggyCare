namespace DoggyCare
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            sidebar = new Panel();
            btnSettings = new Button();
            btnReports = new Button();
            btnRecords = new Button();
            btnDashboard = new Button();
            logo = new Label();
            header = new Panel();
            headerBtnAddRecord = new Button();
            lblTitle = new Label();
            mainPanel = new Panel();
            sidebar.SuspendLayout();
            header.SuspendLayout();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(47, 62, 70);
            sidebar.Controls.Add(btnSettings);
            sidebar.Controls.Add(btnReports);
            sidebar.Controls.Add(btnRecords);
            sidebar.Controls.Add(btnDashboard);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(220, 661);
            sidebar.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 230);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(20, 0, 0, 0);
            btnSettings.Size = new Size(220, 40);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Nastavení";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 180);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(220, 40);
            btnReports.TabIndex = 2;
            btnReports.Text = "Reporty";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnRecords
            // 
            btnRecords.FlatAppearance.BorderSize = 0;
            btnRecords.FlatStyle = FlatStyle.Flat;
            btnRecords.Font = new Font("Segoe UI", 10F);
            btnRecords.ForeColor = Color.White;
            btnRecords.Location = new Point(0, 130);
            btnRecords.Name = "btnRecords";
            btnRecords.Padding = new Padding(20, 0, 0, 0);
            btnRecords.Size = new Size(220, 40);
            btnRecords.TabIndex = 1;
            btnRecords.Text = "Záznamy";
            btnRecords.TextAlign = ContentAlignment.MiddleLeft;
            btnRecords.UseVisualStyleBackColor = true;
            btnRecords.Click += btnRecords_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 80);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(220, 40);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // logo
            // 
            logo.AutoSize = true;
            logo.BackColor = Color.FromArgb(47, 62, 70);
            logo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(20, 20);
            logo.Name = "logo";
            logo.Size = new Size(161, 37);
            logo.TabIndex = 1;
            logo.Text = "DoggyCare";
            // 
            // header
            // 
            header.Controls.Add(headerBtnAddRecord);
            header.Controls.Add(lblTitle);
            header.Dock = DockStyle.Top;
            header.Location = new Point(220, 0);
            header.Name = "header";
            header.Size = new Size(864, 80);
            header.TabIndex = 2;
            // 
            // headerBtnAddRecord
            // 
            headerBtnAddRecord.BackColor = Color.FromArgb(0, 191, 165);
            headerBtnAddRecord.FlatAppearance.BorderSize = 0;
            headerBtnAddRecord.FlatStyle = FlatStyle.Flat;
            headerBtnAddRecord.ForeColor = Color.White;
            headerBtnAddRecord.Location = new Point(710, 20);
            headerBtnAddRecord.Name = "headerBtnAddRecord";
            headerBtnAddRecord.Size = new Size(130, 36);
            headerBtnAddRecord.TabIndex = 1;
            headerBtnAddRecord.Text = "Přidat záznam";
            headerBtnAddRecord.UseVisualStyleBackColor = false;
            headerBtnAddRecord.Click += headerBtnAddRecord_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(138, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard";
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(240, 80);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(820, 560);
            mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1084, 661);
            Controls.Add(mainPanel);
            Controls.Add(header);
            Controls.Add(logo);
            Controls.Add(sidebar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoggyCare";
            sidebar.ResumeLayout(false);
            header.ResumeLayout(false);
            header.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel sidebar;
        private Label logo;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnDashboard;
        private Button btnSettings;
        private Button btnReports;
        private Button btnRecords;
        private Panel header;
        private Label lblTitle;
        private Button headerBtnAddRecord;
        private Panel mainPanel;
    }
}
