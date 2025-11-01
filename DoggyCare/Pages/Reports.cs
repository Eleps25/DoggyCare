using DoggyCare.Enums;
using DoggyCare.Helpers;
using DoggyCare.Interfaces;
using DoggyCare.Navigation;
using DoggyCare.UI;

namespace DoggyCare.Pages {
    public partial class Reports : UserControl, IPage {
        public Reports() {
            InitializeComponent();
            PageManager.LastPageType = PageType.Reports;
            Panel lastVetVisitCard = CustomElements.CreateDashboardCard("Poslední návštěva veterináře", SummaryHelper.GetLastVetVisitString());
            Panel lastVetVisitCard2 = CustomElements.CreateDashboardCard("Poslední cena krmení", SummaryHelper.GetLastFoodPriceString());
            Panel lastVetVisitCard3 = CustomElements.CreateDashboardCard("Poslední váha", SummaryHelper.GetLastWeightString());
            tlpReports.Controls.Add(lastVetVisitCard, 0, 1);
            tlpReports.Controls.Add(lastVetVisitCard2, 1, 1);
            tlpReports.Controls.Add(lastVetVisitCard3, 2, 1);

            //DataGridView latestCareRecords = CreateLastXCareRecordsTable(5);

            //tlpDashboard.Controls.Add(latestCareRecords, 0, 1);
            //tlpDashboard.SetColumnSpan(latestCareRecords, 3);

            //SummaryHelper.LoadChartData(formsPlot1);
        }

        public UserControl GetView() => this;
    }
}
