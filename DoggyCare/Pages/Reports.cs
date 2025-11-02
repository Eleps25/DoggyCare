using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Models;
using DoggyCare.UI;
using ScottPlot.WinForms;
using System.Data;

namespace DoggyCare.Pages {
    public partial class Reports : UserControl, IPage {
        private Panel lastVetVisitCard = CustomElements.CreateCard("Nejvyšší cena", ReportsHelper.GetHighestPriceString(CareRecordType.Veterinary));
        private Panel lastVetVisitCard2 = CustomElements.CreateCard("Nejnižší cena", ReportsHelper.GetLowestPriceString(CareRecordType.Veterinary));
        private Panel lastVetVisitCard3 = CustomElements.CreateCard("Průměrná cena", ReportsHelper.GetAveragePriceString(CareRecordType.Veterinary));
        private FormsPlot reportPlot = new FormsPlot();
        private DataGridView latestCareRecords = new DataGridView();
        private ComboBox _typeCb;
        public Reports() {
            InitializeComponent();
            UIStyleManager.StyleButton(btnFilter, ColorTranslator.FromHtml("#00BFA5"), Color.White, "Filtrovat");
            btnFilter.Location = new Point(0, 11);
            RefreshPage(true);
        }

        public UserControl GetView() => this;

        private void btnFilter_Click(object sender, EventArgs e) {
            RefreshPage(false);
        }

        private void RefreshPage(bool firstLoad) {
            if (!firstLoad) {
                tlpReports.Controls.Remove(lastVetVisitCard);
                tlpReports.Controls.Remove(lastVetVisitCard2);
                tlpReports.Controls.Remove(lastVetVisitCard3);
                tlpReports.Controls.Remove(latestCareRecords);
                tlpReports.Controls.Remove(reportPlot);

                ReportsHelper.UpdateCareRecordsPeriodByType(dtpDateFrom.Value, dtpDateTo.Value, (CareRecordType)_typeCb.SelectedIndex);
            } else {
                _typeCb = ReportsHelper.CreateReportsComboBox("Type");
                splitContainer1.Panel1.Controls.Add(_typeCb);
                _typeCb.SelectedIndex = 0;
                ReportsHelper.CareRecordsInTimePeriod = DatabaseHelper.GetCareRecords();

                CareRecord? maxDateCareRecord = ReportsHelper.CareRecordsInTimePeriod.MaxBy(careRecord => careRecord.Date);
                if (maxDateCareRecord != null) {
                    dtpDateTo.Value = maxDateCareRecord.Date;
                }
                CareRecord? minDateCareRecord = ReportsHelper.CareRecordsInTimePeriod.MinBy(careRecord => careRecord.Date);
                if (minDateCareRecord != null) {
                    dtpDateFrom.Value = minDateCareRecord.Date;
                }
            }

            lastVetVisitCard = CustomElements.CreateCard("Nejvyšší cena", ReportsHelper.GetHighestPriceString((CareRecordType)_typeCb.SelectedIndex));
            lastVetVisitCard2 = CustomElements.CreateCard("Nejnižší cena", ReportsHelper.GetLowestPriceString((CareRecordType)_typeCb.SelectedIndex));
            lastVetVisitCard3 = CustomElements.CreateCard("Průměrná cena", ReportsHelper.GetAveragePriceString((CareRecordType)_typeCb.SelectedIndex));

            tlpReports.Controls.Add(lastVetVisitCard, 0, 1);
            tlpReports.Controls.Add(lastVetVisitCard2, 1, 1);
            tlpReports.Controls.Add(lastVetVisitCard3, 2, 1);

            latestCareRecords = new DataGridView();
            latestCareRecords.Dock = DockStyle.Fill;
            latestCareRecords = CreateCareRecordsInPeriodByTypeTable(dtpDateFrom.Value, dtpDateTo.Value, (CareRecordType)_typeCb.SelectedIndex);

            tlpReports.Controls.Add(latestCareRecords, 0, 2);
            tlpReports.SetColumnSpan(latestCareRecords, 3);

            reportPlot = new FormsPlot();
            reportPlot.Dock = DockStyle.Fill;

            tlpReports.Controls.Add(reportPlot, 0, 3);
            tlpReports.SetColumnSpan(reportPlot, 3);

            ReportsHelper.LoadChartData(reportPlot, dtpDateFrom.Value, dtpDateTo.Value);
        }

        private DataGridView CreateCareRecordsInPeriodByTypeTable(DateTime dateFrom, DateTime dateTo, CareRecordType careRecordType) {
            DataGridView dataGridView = new DataGridView();
            DataTable dataTable = CareRecordsHelperFunctions.GetDataTableCareRecordsInPeriodByType(dateFrom, dateTo, careRecordType);

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
