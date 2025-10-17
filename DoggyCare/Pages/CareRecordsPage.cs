using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Models;
using System.Data;

namespace DoggyCare.Pages {
    public partial class CareRecordsPage : UserControl, IPage {
        public CareRecordsPage() {
            InitializeComponent();
            StylizeDataGridView(dgvCareRecords);
            UpdateCareRecords();
            //this.BackColor = Color.Orange;
            //Label lbl = new Label() { Text = "Dashboard", Font = new Font("Segoe UI", 14), AutoSize = true };
            //this.Controls.Add(lbl);
        }

        private void UpdateCareRecords() {
            DataTable dataTable = new DataTable();

            DataColumn DateCol = dataTable.Columns.Add("Date", typeof(DateTime));
            DataColumn typeCol = dataTable.Columns.Add("Type", typeof(CareRecordType));
            DataColumn priceCol = dataTable.Columns.Add("Price", typeof(decimal));
            DataColumn weightCol = dataTable.Columns.Add("Weight");
            DataColumn descriptionCol = dataTable.Columns.Add("Description", typeof(string));

            DateCol.Caption = "Datum";
            typeCol.Caption = "Typ";
            priceCol.Caption = "Cena (Kč)";
            weightCol.Caption = "Váha (Kg)";
            descriptionCol.Caption = "Popis";

            // Vyplnit data
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            foreach (CareRecord careRecord in careRecords) {
                var row = dataTable.NewRow();

                row["Date"] = careRecord.Date;
                row["Type"] = careRecord.Type;
                row["Price"] = careRecord.Price;
                row["Weight"] = careRecord.Weight;
                row["Description"] = careRecord.Description;

                dataTable.Rows.Add(row);
            }

            this.dgvCareRecords.DataSource = dataTable;

            // Změnit zobrazení českým popisem
            foreach (DataGridViewColumn column in dgvCareRecords.Columns) {
                column.HeaderText = dataTable.Columns[column.DataPropertyName].Caption;
            }
        }

        public UserControl GetView() => this;

        private void StylizeDataGridView(DataGridView dataGridView) {
            // DGV Styles
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.GridColor = Color.FromArgb(233, 236, 239); // #E9ECEF
            dataGridView.BackgroundColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;

            // Header styles
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 243, 245); // #F1F3F5
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(47, 62, 70);   // #2F3E46
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 223, 219); // #B2DFDB

            // Cell styles
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 247, 244); // #E0F7F4
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // střídání řádků
        }

        private void dgvCareRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvCareRecords.Columns[e.ColumnIndex].DataPropertyName == "Type") {
                e.Value = EnumExtensions.GetEnumDescription((CareRecordType)e.Value);
                e.FormattingApplied = true;
            }
        }
    }
}
