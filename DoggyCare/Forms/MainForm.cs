using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Interfaces;
using DoggyCare.Navigation;

namespace DoggyCare {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

        }

        private void headerBtnAddRecord_Click(object sender, EventArgs e) {

        }

        private void btnDashboard_Click(object sender, EventArgs e) {
            ShowPage(PageType.Dashboard);
        }

        private void btnRecords_Click(object sender, EventArgs e) {
            ShowPage(PageType.CareRecords);
        }

        private void ShowPage(PageType pageType) {
            IPage page = PageManager.GetPage(pageType);

            mainPanel.Controls.Clear();

            var view = page.GetView();
            view.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(view);

            lblTitle.Text = EnumExtensions.GetEnumDescription(pageType);
        }
    }
}
