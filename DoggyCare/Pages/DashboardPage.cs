using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Navigation;
using DoggyCare.UI;
using System.Data;

namespace DoggyCare.Pages {
    public partial class DashboardPage : UserControl, IPage {
        public DashboardPage() {
            InitializeComponent();
            PageManager.LastPageType = PageType.Dashboard;
            Panel lastVetVisitCard = CustomElements.CreateDashboardCard("Poslední návštěva veterináře", SummaryHelper.GetLastVetVisitString());
            Panel lastVetVisitCard2 = CustomElements.CreateDashboardCard("Poslední cena krmení", SummaryHelper.GetLastFoodPriceString());
            Panel lastVetVisitCard3 = CustomElements.CreateDashboardCard("Poslední váha", SummaryHelper.GetLastWeightString());
            tlpDashboard.Controls.Add(lastVetVisitCard, 0, 0);
            tlpDashboard.Controls.Add(lastVetVisitCard2, 1, 0);
            tlpDashboard.Controls.Add(lastVetVisitCard3, 2, 0);

            DataGridView latestCareRecords = CreateLastXCareRecordsTable(5);

            tlpDashboard.Controls.Add(latestCareRecords, 0, 1);
            tlpDashboard.SetColumnSpan(latestCareRecords, 3);
        }

        public UserControl GetView() => this;



        private DataGridView CreateLastXCareRecordsTable(int numberOfRecords) {
            DataGridView dataGridView = new DataGridView();
            DataTable dataTable = CareRecordsHelperFunctions.GetDataTableCareRecords(numberOfRecords);

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
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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

            dgv.Columns["Id"].Visible = false;
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
