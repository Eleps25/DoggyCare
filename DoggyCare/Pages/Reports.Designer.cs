namespace DoggyCare.Pages {
    partial class Reports {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tlpReports = new TableLayoutPanel();
            flpDateTo = new FlowLayoutPanel();
            lblDateTo = new Label();
            dtpDateTo = new DateTimePicker();
            flpDateFrom = new FlowLayoutPanel();
            lblDateFrom = new Label();
            dtpDateFrom = new DateTimePicker();
            splitContainer1 = new SplitContainer();
            btnFilter = new Button();
            tlpReports.SuspendLayout();
            flpDateTo.SuspendLayout();
            flpDateFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpReports
            // 
            tlpReports.ColumnCount = 3;
            tlpReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpReports.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpReports.Controls.Add(flpDateTo, 1, 0);
            tlpReports.Controls.Add(flpDateFrom, 0, 0);
            tlpReports.Controls.Add(splitContainer1, 2, 0);
            tlpReports.Dock = DockStyle.Fill;
            tlpReports.Location = new Point(0, 0);
            tlpReports.Name = "tlpReports";
            tlpReports.RowCount = 4;
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tlpReports.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tlpReports.Size = new Size(641, 473);
            tlpReports.TabIndex = 0;
            // 
            // flpDateTo
            // 
            flpDateTo.Anchor = AnchorStyles.Left;
            flpDateTo.Controls.Add(lblDateTo);
            flpDateTo.Controls.Add(dtpDateTo);
            flpDateTo.Location = new Point(216, 3);
            flpDateTo.Name = "flpDateTo";
            flpDateTo.Padding = new Padding(0, 5, 0, 0);
            flpDateTo.Size = new Size(207, 31);
            flpDateTo.TabIndex = 1;
            // 
            // lblDateTo
            // 
            lblDateTo.Anchor = AnchorStyles.Left;
            lblDateTo.AutoSize = true;
            lblDateTo.Location = new Point(3, 12);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(65, 15);
            lblDateTo.TabIndex = 0;
            lblDateTo.Text = "Datum Od:";
            // 
            // dtpDateTo
            // 
            dtpDateTo.Format = DateTimePickerFormat.Short;
            dtpDateTo.Location = new Point(74, 8);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(111, 23);
            dtpDateTo.TabIndex = 1;
            // 
            // flpDateFrom
            // 
            flpDateFrom.Anchor = AnchorStyles.Left;
            flpDateFrom.Controls.Add(lblDateFrom);
            flpDateFrom.Controls.Add(dtpDateFrom);
            flpDateFrom.Location = new Point(3, 3);
            flpDateFrom.Name = "flpDateFrom";
            flpDateFrom.Padding = new Padding(0, 5, 0, 0);
            flpDateFrom.Size = new Size(207, 31);
            flpDateFrom.TabIndex = 0;
            // 
            // lblDateFrom
            // 
            lblDateFrom.Anchor = AnchorStyles.Left;
            lblDateFrom.AutoSize = true;
            lblDateFrom.Location = new Point(3, 12);
            lblDateFrom.Name = "lblDateFrom";
            lblDateFrom.Size = new Size(65, 15);
            lblDateFrom.TabIndex = 0;
            lblDateFrom.Text = "Datum Od:";
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Format = DateTimePickerFormat.Short;
            dtpDateFrom.Location = new Point(74, 8);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(111, 23);
            dtpDateFrom.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(429, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnFilter);
            splitContainer1.Size = new Size(209, 31);
            splitContainer1.SplitterDistance = 133;
            splitContainer1.TabIndex = 2;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(0, 8);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 0;
            btnFilter.Text = "Filtrovat";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(tlpReports);
            Name = "Reports";
            Size = new Size(641, 473);
            tlpReports.ResumeLayout(false);
            flpDateTo.ResumeLayout(false);
            flpDateTo.PerformLayout();
            flpDateFrom.ResumeLayout(false);
            flpDateFrom.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpReports;
        private FlowLayoutPanel flpDateFrom;
        private Label lblDateFrom;
        private FlowLayoutPanel flpDateTo;
        private Label lblDateTo;
        private DateTimePicker dtpDateTo;
        private DateTimePicker dtpDateFrom;
        private SplitContainer splitContainer1;
        private Button btnFilter;
    }
}
