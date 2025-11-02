using DoggyCare.Enums;
using DoggyCare.Extensions;
using DoggyCare.Interfaces;
using DoggyCare.Models;
using DoggyCare.Pages;

namespace DoggyCare.Navigation {
    public static class PageManager {
        public static PageType LastPageType { get; set; }
        private static Panel? _targetPanel;
        private static Label? _titleLabel;
        private static Button? _addCareRecordButton;
        private static PageType lastPageType;
        private static CareRecord _careRecordToUpdate;
        public static void Initialize(Panel targetPanel, Label titleLabel, Button addCareREcordButton) {
            _targetPanel = targetPanel;
            _titleLabel = titleLabel;
            _addCareRecordButton = addCareREcordButton;
        }

        public static IPage GetPage(PageType pageType) {
            switch (pageType) {
                case PageType.Dashboard:
                    return new DashboardPage();
                case PageType.CareRecords:
                    return new CareRecordsPage();
                case PageType.AddCareRecord:
                    return new AddUpdateCareRecordPage();
                case PageType.UpdateCareRecord:
                    return new AddUpdateCareRecordPage(_careRecordToUpdate);
                case PageType.Reports:
                    return new Reports();
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

            if (_addCareRecordButton != null) {
                if (pageType == PageType.Dashboard) {
                    _addCareRecordButton.Visible = true;
                } else {
                    _addCareRecordButton.Visible = false;
                }
            }
        }

        public static void SetCareRecordToUpdate(CareRecord recordToUpdate) {
            _careRecordToUpdate = recordToUpdate;
        }
    }
}
