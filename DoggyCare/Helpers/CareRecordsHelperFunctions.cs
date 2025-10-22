using DoggyCare.Enums;
using DoggyCare.Models;
using System.Data;

namespace DoggyCare.Helpers {
    public static class CareRecordsHelperFunctions {
        public static List<CareRecord> GetXNewestCareRecords(int numberOfRecords) {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            List<CareRecord> newestCareRecords = careRecords.OrderByDescending(careRecord => careRecord.Date).Take(numberOfRecords).ToList();
            return newestCareRecords;
        }

        // Get Record with ID
        public static CareRecord GetSpecificCareRecord(int id) {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            foreach (CareRecord careRecord in careRecords) {
                if (careRecord.Id == id) return careRecord;
            }

            return null;
        }

        public static DataTable GetDataTableCareRecords() {
            DataTable dataTable = new DataTable();

            DataColumn DateCol = dataTable.Columns.Add("Date", typeof(DateTime));
            DataColumn typeCol = dataTable.Columns.Add("Type", typeof(CareRecordType));
            DataColumn priceCol = dataTable.Columns.Add("Price", typeof(decimal));
            DataColumn weightCol = dataTable.Columns.Add("Weight");
            DataColumn descriptionCol = dataTable.Columns.Add("Description", typeof(string));
            DataColumn idCol = dataTable.Columns.Add("Id", typeof(int));

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
                row["id"] = careRecord.Id;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable GetDataTableCareRecords(int numberOfRecords) {
            DataTable dataTable = new DataTable();

            DataColumn DateCol = dataTable.Columns.Add("Date", typeof(DateTime));
            DataColumn typeCol = dataTable.Columns.Add("Type", typeof(CareRecordType));
            DataColumn priceCol = dataTable.Columns.Add("Price", typeof(decimal));
            DataColumn weightCol = dataTable.Columns.Add("Weight");
            DataColumn descriptionCol = dataTable.Columns.Add("Description", typeof(string));
            DataColumn idCol = dataTable.Columns.Add("Id", typeof(int));

            DateCol.Caption = "Datum";
            typeCol.Caption = "Typ";
            priceCol.Caption = "Cena (Kč)";
            weightCol.Caption = "Váha (Kg)";
            descriptionCol.Caption = "Popis";

            // Vyplnit data
            List<CareRecord> careRecords = GetXNewestCareRecords(numberOfRecords);

            foreach (CareRecord careRecord in careRecords) {
                var row = dataTable.NewRow();

                row["Date"] = careRecord.Date;
                row["Type"] = careRecord.Type;
                row["Price"] = careRecord.Price;
                row["Weight"] = careRecord.Weight;
                row["Description"] = careRecord.Description;
                row["Id"] = careRecord.Id;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static void StylizeDataGridView(DataGridView dataGridView) {
            // DGV Styles
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.GridColor = Color.FromArgb(233, 236, 239); // #E9ECEF
            dataGridView.BackgroundColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Dock = DockStyle.Fill;

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
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // střídání řádků
        }
    }
}
