namespace DoggyCare.Pages {
    partial class AddUpdateCareRecordPage {
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
            tlpAddRecord = new TableLayoutPanel();
            SuspendLayout();
            // 
            // tlpAddRecord
            // 
            tlpAddRecord.ColumnCount = 2;
            tlpAddRecord.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpAddRecord.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpAddRecord.Dock = DockStyle.Fill;
            tlpAddRecord.Location = new Point(0, 0);
            tlpAddRecord.Name = "tlpAddRecord";
            tlpAddRecord.RowCount = 6;
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpAddRecord.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAddRecord.Size = new Size(428, 388);
            tlpAddRecord.TabIndex = 0;
            // 
            // AddCareRecordPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpAddRecord);
            Name = "AddCareRecordPage";
            Size = new Size(428, 388);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpAddRecord;
    }
}
