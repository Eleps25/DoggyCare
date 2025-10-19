using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Navigation;
using System.Data;

namespace DoggyCare.Pages {
    public partial class CareRecordsPage : UserControl, IPage {
        public CareRecordsPage() {
            InitializeComponent();
            PageManager.LastPageType = PageType.CareRecords;
            CareRecordsHelperFunctions.StylizeDataGridView(dgvCareRecords);
            UpdateCareRecords();
            //this.BackColor = Color.Orange;
            //Label lbl = new Label() { Text = "Dashboard", Font = new Font("Segoe UI", 14), AutoSize = true };
            //this.Controls.Add(lbl);
        }

        private void UpdateCareRecords() {
            DataTable dataTable = CareRecordsHelperFunctions.GetDataTableCareRecords();
            this.dgvCareRecords.DataSource = dataTable;

            // Změnit zobrazení českým popisem
            foreach (DataGridViewColumn column in dgvCareRecords.Columns) {
                column.HeaderText = dataTable.Columns[column.DataPropertyName].Caption;
            }
        }

        public UserControl GetView() => this;

        private void dgvCareRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvCareRecords.Columns[e.ColumnIndex].DataPropertyName == "Type") {
                e.Value = EnumExtensions.GetEnumDescription((CareRecordType)e.Value);
                e.FormattingApplied = true;
            }
        }
    }
}
