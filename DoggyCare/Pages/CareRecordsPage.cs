using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Models;
using DoggyCare.Navigation;
using DoggyCare.UI;
using System.Data;

namespace DoggyCare.Pages {
    public partial class CareRecordsPage : UserControl, IPage {
        public CareRecordsPage() {
            InitializeComponent();
            PageManager.LastPageType = PageType.CareRecords;
            CareRecordsHelperFunctions.StylizeDataGridView(dgvCareRecords);
            TableLayoutPanel buttonsTableLayoutPanel = CreateCareRecordsFunctionButtonsPanel();
            this.tlpCareRecordsPage.Controls.Add(buttonsTableLayoutPanel, 1, 0);
            UpdateCareRecords();
        }

        private void UpdateCareRecords() {
            DataTable dataTable = CareRecordsHelperFunctions.GetDataTableCareRecords();
            this.dgvCareRecords.DataSource = dataTable;

            // Změnit zobrazení českým popisem
            foreach (DataGridViewColumn column in dgvCareRecords.Columns) {
                column.HeaderText = dataTable.Columns[column.DataPropertyName].Caption;
            }

            dgvCareRecords.CellFormatting -= dgvCareRecords_CellFormatting;
            dgvCareRecords.CellFormatting += dgvCareRecords_CellFormatting;

            dgvCareRecords.Columns["Id"].Visible = false;
        }

        public UserControl GetView() => this;

        private void dgvCareRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dgvCareRecords.Columns[e.ColumnIndex].DataPropertyName == "Type") {
                e.Value = EnumExtensions.GetEnumDescription((CareRecordType)e.Value);
                e.FormattingApplied = true;
            }
        }

        private TableLayoutPanel CreateCareRecordsFunctionButtonsPanel() {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Anchor = AnchorStyles.Right;
            tableLayoutPanel.AutoSize = true;

            Button addCareRecordBtn = CustomElements.CreateAddCareRecordButton();
            Button updateCareRecordBtn = CustomElements.CreateUpdateCareRecordButton();
            Button deleteCareRecordBtn = CustomElements.CreateDeleteCareRecordButton();

            tableLayoutPanel.Controls.Add(addCareRecordBtn, 0, 0);
            tableLayoutPanel.Controls.Add(updateCareRecordBtn, 1, 0);
            tableLayoutPanel.Controls.Add(deleteCareRecordBtn, 2, 0);

            addCareRecordBtn.Click += (sender, e) => HandleAddBtnClick();
            updateCareRecordBtn.Click += (sender, e) => HandleUpdateBtnClick(sender, e);
            deleteCareRecordBtn.Click += (sender, e) => HandleDeleteBtnClick();

            return tableLayoutPanel;
        }

        private void HandleAddBtnClick() {
            PageManager.ShowPage(PageType.AddCareRecord);
        }

        private void HandleUpdateBtnClick(object sender, EventArgs e) {
            if (dgvCareRecords.CurrentRow == null) return;

            int id = (int)dgvCareRecords.CurrentRow.Cells["Id"].Value;
            DateTime date = Convert.ToDateTime(dgvCareRecords.CurrentRow.Cells["Date"].Value);
            CareRecordType type = (CareRecordType)dgvCareRecords.CurrentRow.Cells["Type"].Value;
            decimal price = (decimal)dgvCareRecords.CurrentRow.Cells["Price"].Value;
            decimal weight = Decimal.Parse(dgvCareRecords.CurrentRow.Cells["Weight"].Value.ToString());
            string description = dgvCareRecords.CurrentRow.Cells["Description"].Value?.ToString() ?? "";

            CareRecord recordToUpdate = new CareRecord() {
                Id = id,
                Date = date,
                Type = type,
                Price = price,
                Weight = weight,
                Description = description
            };

            PageManager.SetCareRecordToUpdate(recordToUpdate);
            PageManager.ShowPage(PageType.UpdateCareRecord);
        }

        private void HandleDeleteBtnClick() {
            if (dgvCareRecords.CurrentRow == null) return;

            int id = (int)dgvCareRecords.CurrentRow.Cells["Id"].Value;

            // Zobrazí potvrzovací dialog
            DialogResult result = MessageBox.Show(
                "Opravdu chceš smazat vybraný záznam?",
                "Potvrzení smazání",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Vyhodnocení odpovědi uživatele
            if (result == DialogResult.Yes) {
                DatabaseHelper.DeleteRecord(id);
                MessageBox.Show("Záznam byl úspěšně smazán.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateCareRecords();
            } else {
                MessageBox.Show("Smazání bylo zrušeno.", "Zrušeno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
