using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Interfaces;
using DoggyCare.Pages;

namespace DoggyCare.Navigation {
    public static class PageManager {
        public static PageType LastPageType { get; set; }
        private static Panel? _targetPanel;
        private static Label? _titleLabel;
        private static PageType lastPageType;
        public static void Initialize(Panel targetPanel, Label titleLabel) {
            _targetPanel = targetPanel;
            _titleLabel = titleLabel;
        }

        public static IPage GetPage(PageType pageType) {
            switch (pageType) {
                case PageType.Dashboard:
                    return new DashboardPage();
                case PageType.CareRecords:
                    return new CareRecordsPage();
                case PageType.AddCareRecord:
                    return new AddUpdateCareRecordPage();
                default:
                    return new DashboardPage(); // fallback
            }
        }

        public static void ShowPage(PageType pageType) {
            IPage page = GetPage(pageType);

            if (_targetPanel != null) {
                _targetPanel.Controls.Clear();

                var view = page.GetView();
                view.Dock = DockStyle.Fill;
                _targetPanel.Controls.Add(view);
            }

            if (_titleLabel != null) {
                _titleLabel.Text = EnumExtensions.GetEnumDescription(pageType);
            }
        }
    }
}
