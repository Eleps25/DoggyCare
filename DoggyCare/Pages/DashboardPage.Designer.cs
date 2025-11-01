namespace DoggyCare.Pages {
    partial class DashboardPage {
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
            tlpDashboard = new TableLayoutPanel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            tlpDashboard.SuspendLayout();
            SuspendLayout();
            // 
            // tlpDashboard
            // 
            tlpDashboard.ColumnCount = 3;
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpDashboard.Controls.Add(formsPlot1, 0, 2);
            tlpDashboard.Dock = DockStyle.Fill;
            tlpDashboard.Location = new Point(0, 0);
            tlpDashboard.Name = "tlpDashboard";
            tlpDashboard.RowCount = 3;
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            tlpDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            tlpDashboard.Size = new Size(462, 404);
            tlpDashboard.TabIndex = 0;
            // 
            // formsPlot1
            // 
            tlpDashboard.SetColumnSpan(formsPlot1, 3);
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(3, 255);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(456, 146);
            formsPlot1.TabIndex = 0;
            // 
            // DashboardPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpDashboard);
            Name = "DashboardPage";
            Size = new Size(462, 404);
            tlpDashboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpDashboard;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}
