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
            components = new System.ComponentModel.Container();
            tlpAddRecord = new TableLayoutPanel();
            careRecordBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)careRecordBindingSource).BeginInit();
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
            // careRecordBindingSource
            // 
            careRecordBindingSource.DataSource = typeof(Models.CareRecord);
            // 
            // AddUpdateCareRecordPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpAddRecord);
            Name = "AddUpdateCareRecordPage";
            Size = new Size(428, 388);
            ((System.ComponentModel.ISupportInitialize)careRecordBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpAddRecord;
        private BindingSource careRecordBindingSource;
    }
}
