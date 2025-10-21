using DoggyCare.Enums;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Models;
using DoggyCare.Navigation;
using DoggyCare.UI;

namespace DoggyCare.Pages {
    public partial class AddUpdateCareRecordPage : UserControl, IPage {
        private DateTimePicker _dateDtp;
        private ComboBox _typeCb;
        private NumericUpDown _priceNud;
        private NumericUpDown _weightNud;
        private TextBox _descriptionTb;
        private int _careRecordToUpdateId;
        public AddUpdateCareRecordPage() {
            InitializeComponent();
            CreateAddForm();
        }

        public AddUpdateCareRecordPage(CareRecord careRecordToUpdate) {
            InitializeComponent();
            CreateUpdateForm(careRecordToUpdate);
        }

        public UserControl GetView() => this;

        private void CreateAddForm() {
            Label dateLabel = CareRecordAddUpdateFormHelper.CreateFormLabel("Date", "Datum:");
            Label typeLabel = CareRecordAddUpdateFormHelper.CreateFormLabel("Type", "Typ:");
            Label priceLabel = CareRecordAddUpdateFormHelper.CreateFormLabel("Price", "Cena (Kč):");
            Label weightLabel = CareRecordAddUpdateFormHelper.CreateFormLabel("Weight", "Váha (Kg):");
            Label dscLabel = CareRecordAddUpdateFormHelper.CreateFormLabel("Description", "Popis:");
            tlpAddRecord.Controls.Add(dateLabel, 0, 0);
            tlpAddRecord.Controls.Add(typeLabel, 0, 1);
            tlpAddRecord.Controls.Add(priceLabel, 0, 2);
            tlpAddRecord.Controls.Add(weightLabel, 0, 3);
            tlpAddRecord.Controls.Add(dscLabel, 0, 4);

            DateTimePicker dateDtp = CareRecordAddUpdateFormHelper.CreateFormDatePicker("DatePicker");
            ComboBox typeCb = CareRecordAddUpdateFormHelper.CreateFormComboBox("Type");
            NumericUpDown priceNud = CareRecordAddUpdateFormHelper.CreateFormNumericUpDown("Price", 0, 100000);
            NumericUpDown weightNud = CareRecordAddUpdateFormHelper.CreateFormNumericUpDown("Weight", 1, 30);
            TextBox descriptionTb = CareRecordAddUpdateFormHelper.CreateFormTextBox("Description");
            tlpAddRecord.Controls.Add(dateDtp, 1, 0);
            tlpAddRecord.Controls.Add(typeCb, 1, 1);
            tlpAddRecord.Controls.Add(priceNud, 1, 2);
            tlpAddRecord.Controls.Add(weightNud, 1, 3);
            tlpAddRecord.Controls.Add(descriptionTb, 1, 4);
            _dateDtp = dateDtp;
            _typeCb = typeCb;
            _priceNud = priceNud;
            _weightNud = weightNud;
            _descriptionTb = descriptionTb;

            Button saveButton = CustomElements.CreateSaveButton();
            Button cancelButton = CustomElements.CreateCancelButton();
            saveButton.Click += (s, e) => HandleSaveBtnClick();
            cancelButton.Click += (s, e) => HandleCancelBtnClick();

            FlowLayoutPanel flpButtons = new FlowLayoutPanel();
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.FlowDirection = FlowDirection.LeftToRight;
            flpButtons.WrapContents = false;
            flpButtons.AutoSize = true;
            flpButtons.Padding = new Padding(5);

            flpButtons.Controls.Add(cancelButton);
            flpButtons.Controls.Add(saveButton);

            tlpAddRecord.Controls.Add(flpButtons, 1, 5);
        }


        private void CreateUpdateForm(CareRecord careRecordToUpdate) {
            CreateAddForm();
            _careRecordToUpdateId = careRecordToUpdate.Id;
            _dateDtp.Value = careRecordToUpdate.Date;

            _typeCb.SelectedIndex = CareRecordAddUpdateFormHelper.GetIndexFromComboBoxCareRecordsItems(_typeCb, careRecordToUpdate.Type);
            var selectedItem = _typeCb.SelectedItem as ComboBoxCareRecordsItem<CareRecordType>;

            _priceNud.Value = careRecordToUpdate.Price;
            if (careRecordToUpdate.Weight != null) {
                _weightNud.Value = (decimal)careRecordToUpdate.Weight;
            } else {
                _weightNud.Value = 0;
            }
            _descriptionTb.Text = careRecordToUpdate.Description;
        }

        private void HandleSaveBtnClick() {
            DateTime date = _dateDtp.Value;
            var selectedItem = _typeCb.SelectedItem as ComboBoxCareRecordsItem<CareRecordType>;
            CareRecordType type = (CareRecordType)selectedItem.Value;
            Decimal price = _priceNud.Value;
            Decimal weight = _weightNud.Value;
            string description = _descriptionTb.Text;

            CareRecord newRecord = new CareRecord() {
                Date = date,
                Type = type,
                Price = price,
                Weight = weight,
                Description = description
            };

            if (_careRecordToUpdateId > 0) {
                newRecord.Id = _careRecordToUpdateId;
                DatabaseHelper.UpdateRecord(newRecord);
            } else {
                DatabaseHelper.AddCareRecord(newRecord);
            }

            PageManager.ShowPage(PageManager.LastPageType);
        }

        private void HandleCancelBtnClick() {
            PageManager.ShowPage(PageManager.LastPageType);
        }
    }
}
