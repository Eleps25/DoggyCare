namespace DoggyCare.UI {
    public static class CustomElements {
        public static Button CreateSaveButton() {
            Button saveButton = new Button();

            UIStyleManager.StyleButton(saveButton, ColorTranslator.FromHtml("#00BFA5"), Color.White, "Uložit");
            return saveButton;
        }

        public static Button CreateCancelButton() {
            Button cancelButton = new Button();

            UIStyleManager.StyleButton(cancelButton, ColorTranslator.FromHtml("#E0E0E0"), Color.White, "Zrušit");
            return cancelButton;
        }

        public static Panel CreateDashboardCard(string header, string value) {
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
    }
}
