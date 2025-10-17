using DoggyCare.Enums;
using DoggyCare.Interfaces;
using DoggyCare.Pages;

namespace DoggyCare.Navigation {
    internal class PageManager {
        public static IPage GetPage(PageType pageType) {
            switch (pageType) {
                case PageType.Dashboard:
                    return new DashboardPage();
                case PageType.CareRecords:
                    return new CareRecordsPage();
                default:
                    return new DashboardPage(); // fallback
            }
        }
    }
}
