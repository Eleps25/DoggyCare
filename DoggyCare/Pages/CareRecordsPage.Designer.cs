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
            dgvCareRecords = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCareRecords).BeginInit();
            SuspendLayout();
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
            dgvCareRecords.Dock = DockStyle.Fill;
            dgvCareRecords.Location = new Point(0, 0);
            dgvCareRecords.Name = "dgvCareRecords";
            dgvCareRecords.ReadOnly = true;
            dgvCareRecords.RowHeadersVisible = false;
            dgvCareRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCareRecords.Size = new Size(530, 395);
            dgvCareRecords.TabIndex = 0;
            dgvCareRecords.CellFormatting += dgvCareRecords_CellFormatting;
            // 
            // CareRecordsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(dgvCareRecords);
            Name = "CareRecordsPage";
            Size = new Size(530, 395);
            ((System.ComponentModel.ISupportInitialize)dgvCareRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCareRecords;
    }
}
