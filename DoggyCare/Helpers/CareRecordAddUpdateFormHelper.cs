using DoggyCare.Enums;
using DoggyCare.Models;
using System.ComponentModel;

namespace DoggyCare.Helpers {
    public static class CareRecordAddUpdateFormHelper {
        public static Label CreateFormLabel(string lblName, string lblText) {
            Label lbl = new Label();
            lbl.Dock = DockStyle.Right;
            lbl.Name = lblName;
            lbl.Text = lblText;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.ForeColor = ColorTranslator.FromHtml("#333333");
            lbl.Anchor = AnchorStyles.Right;

            return lbl;
        }

        public static DateTimePicker CreateFormDatePicker(string dtpName) {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = dtpName;
            dateTimePicker.Dock = DockStyle.Left;
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dateTimePicker.ForeColor = ColorTranslator.FromHtml("#333333");
            dateTimePicker.Anchor = AnchorStyles.Left;

            return dateTimePicker;
        }

        public static ComboBox CreateFormComboBox(string cbName) {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = cbName;
            comboBox.Dock = DockStyle.Left;
            comboBox.Anchor = AnchorStyles.Left;
            comboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboBox.ForeColor = ColorTranslator.FromHtml("#333333");


            foreach (CareRecordType value in Enum.GetValues(typeof(CareRecordType))) {
                var field = value.GetType().GetField(value.ToString());
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                var description = attribute?.Description ?? value.ToString();
                ComboBoxCareRecordsItem<CareRecordType> item = new ComboBoxCareRecordsItem<CareRecordType>() { Value = value, Text = description };

                comboBox.Items.Add(item);
            }

            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";

            return comboBox;
        }

        public static NumericUpDown CreateFormNumericUpDown(string nudName, int numberOfDecPlaces, int maxNumber) {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Name = nudName;
            numericUpDown.Dock = DockStyle.Left;
            numericUpDown.DecimalPlaces = numberOfDecPlaces;
            numericUpDown.Maximum = maxNumber;
            numericUpDown.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            numericUpDown.ForeColor = ColorTranslator.FromHtml("#333333");
            numericUpDown.Anchor = AnchorStyles.Left;

            return numericUpDown;
        }

        public static TextBox CreateFormTextBox(string nudName) {
            TextBox textBox = new TextBox();
            textBox.Name = nudName;
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            textBox.ForeColor = ColorTranslator.FromHtml("#333333");
            textBox.Anchor = AnchorStyles.Left;
            textBox.Size = new Size(240, 30);

            return textBox;
        }

        public static int GetIndexFromComboBoxCareRecordsItems(ComboBox cb, CareRecordType targetType) {
            for (int i = 0; i < cb.Items.Count; i++) {
                var item = cb.Items[i];
                var valueProp = item.GetType().GetProperty("Value")?.GetValue(item);
                if (valueProp is CareRecordType type && type == targetType) {
                    return i;
                }
            }
            return -1;
        }
    }
}
