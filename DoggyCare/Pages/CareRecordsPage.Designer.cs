namespace DoggyCare.Pages {
    partial class CareRecordsPage {
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
            tlpCareRecordsPage = new TableLayoutPanel();
            dgvCareRecords = new DataGridView();
            tlpCareRecordsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCareRecords).BeginInit();
            SuspendLayout();
            // 
            // tlpCareRecordsPage
            // 
            tlpCareRecordsPage.ColumnCount = 2;
            tlpCareRecordsPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpCareRecordsPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpCareRecordsPage.Controls.Add(dgvCareRecords, 0, 1);
            tlpCareRecordsPage.Dock = DockStyle.Fill;
            tlpCareRecordsPage.Location = new Point(0, 0);
            tlpCareRecordsPage.Name = "tlpCareRecordsPage";
            tlpCareRecordsPage.RowCount = 2;
            tlpCareRecordsPage.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpCareRecordsPage.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tlpCareRecordsPage.Size = new Size(530, 395);
            tlpCareRecordsPage.TabIndex = 1;
            // 
            // dgvCareRecords
            // 
            dgvCareRecords.AllowUserToAddRows = false;
            dgvCareRecords.AllowUserToDeleteRows = false;
            dgvCareRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCareRecords.BackgroundColor = Color.White;
            dgvCareRecords.BorderStyle = BorderStyle.None;
            dgvCareRecords.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCareRecords.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvCareRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpCareRecordsPage.SetColumnSpan(dgvCareRecords, 2);
            dgvCareRecords.Dock = DockStyle.Fill;
            dgvCareRecords.Location = new Point(3, 42);
            dgvCareRecords.Name = "dgvCareRecords";
            dgvCareRecords.ReadOnly = true;
            dgvCareRecords.RowHeadersVisible = false;
            dgvCareRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCareRecords.Size = new Size(524, 350);
            dgvCareRecords.TabIndex = 1;
            // 
            // CareRecordsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tlpCareRecordsPage);
            Name = "CareRecordsPage";
            Size = new Size(530, 395);
            tlpCareRecordsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCareRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpCareRecordsPage;
        private DataGridView dgvCareRecords;
    }
}
