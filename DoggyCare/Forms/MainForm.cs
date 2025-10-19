using DoggyCare.Enums;
using DoggyCare.Navigation;

namespace DoggyCare {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            PageManager.Initialize(mainPanel, lblTitle);
            PageManager.ShowPage(PageType.Dashboard);
        }

        private void headerBtnAddRecord_Click(object sender, EventArgs e) {
            PageManager.ShowPage(PageType.AddCareRecord);
        }

        private void btnDashboard_Click(object sender, EventArgs e) {
            PageManager.ShowPage(PageType.Dashboard);
        }

        private void btnRecords_Click(object sender, EventArgs e) {
            PageManager.ShowPage(PageType.CareRecords);
        }
    }
}
