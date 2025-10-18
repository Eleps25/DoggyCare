using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using System.Data;

namespace DoggyCare.Pages {
    public partial class DashboardPage : UserControl, IPage {
        public DashboardPage() {
            InitializeComponent();
            Panel lastVetVisitCard = CreateCard("Poslední návštěva veterináře", SummaryHelper.GetLastVetVisitString());
            Panel lastVetVisitCard2 = CreateCard("Poslední návštěva veterináře 2", SummaryHelper.GetLastVetVisitString());
            Panel lastVetVisitCard3 = CreateCard("Poslední návštěva veterináře 3", SummaryHelper.GetLastVetVisitString());
            tlpDashboard.Controls.Add(lastVetVisitCard, 0, 0);
            tlpDashboard.Controls.Add(lastVetVisitCard2, 1, 0);
            tlpDashboard.Controls.Add(lastVetVisitCard3, 2, 0);

            DataGridView latestCareRecords = CreateLastXCareRecordsTable(5);

            tlpDashboard.Controls.Add(latestCareRecords, 0, 1);
            tlpDashboard.SetColumnSpan(latestCareRecords, 3);
        }

        public UserControl GetView() => this;

        private Panel CreateCard(string header, string value) {
            Panel card = new Panel();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            Label headerLabel = new Label();
            Label valueLabel = new Label();

            headerLabel.Text = header;
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            headerLabel.ForeColor = ColorTranslator.FromHtml("#888888");
            headerLabel.Dock = DockStyle.Fill;

            valueLabel.Text = value;
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI", 14);
            valueLabel.ForeColor = ColorTranslator.FromHtml("#333333");
            valueLabel.Dock = DockStyle.Fill;

            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tableLayoutPanel.Controls.Add(headerLabel, 0, 0);
            tableLayoutPanel.Controls.Add(valueLabel, 0, 1);

            card.Dock = DockStyle.Fill;
            card.BackColor = Color.White;
            card.Padding = new Padding(10, 15, 10, 15);
            card.Margin = new Padding(10, 10, 10, 10);
            card.Controls.Add(tableLayoutPanel);

            return card;
        }

        private DataGridView CreateLastXCareRecordsTable(int numberOfRecords) {
            DataGridView dataGridView = new DataGridView();
            DataTable dataTable = CareRecordsHelperFunctions.GetDataTableCareRecords();

            //Add events for changing description of columns
            dataGridView.DataBindingComplete -= dgvDashboardCareRecords_DataBindingComplete; // check to not being added 2x
            dataGridView.DataBindingComplete += dgvDashboardCareRecords_DataBindingComplete;

            dataGridView.CellFormatting -= dgvDashboardCareRecords_CellFormatting;
            dataGridView.CellFormatting += dgvDashboardCareRecords_CellFormatting;

            dataGridView.DataSource = dataTable;
            // Změnit zobrazení českým popisem
            foreach (DataGridViewColumn column in dataGridView.Columns) {
                column.HeaderText = dataTable.Columns[column.DataPropertyName].Caption;
            }

            CareRecordsHelperFunctions.StylizeDataGridView(dataGridView);



            return dataGridView;
        }

        private void dgvDashboardCareRecords_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) {
            if (sender is not DataGridView dgv) return;
            if (dgv.DataSource is not DataTable dt) return;

            // Nastav české popisky (Caption z DataTable.Columns)
            foreach (DataGridViewColumn column in dgv.Columns) {
                if (dt.Columns.Contains(column.DataPropertyName)) {
                    column.HeaderText = dt.Columns[column.DataPropertyName].Caption;
                }
            }
        }

        private void dgvDashboardCareRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (sender is not DataGridView dgv) return;
            if (dgv.DataSource is not DataTable dt) return;

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "Type") {
                e.Value = EnumExtensions.GetEnumDescription((CareRecordType)e.Value);
                e.FormattingApplied = true;
            }
        }
    }
}
