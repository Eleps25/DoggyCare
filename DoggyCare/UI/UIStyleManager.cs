namespace DoggyCare.UI {
    public static class UIStyleManager {
        public static void StyleButton(Button btn, Color buttonColor, Color textColor, string text) {
            btn.BackColor = buttonColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = textColor;
            btn.Text = text;
            btn.Cursor = Cursors.Hand;
        }
    }
}
