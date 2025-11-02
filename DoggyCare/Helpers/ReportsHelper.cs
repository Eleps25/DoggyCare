using DoggyCare.Enums;
using DoggyCare.Models;
using ScottPlot.WinForms;
using System.ComponentModel;

namespace DoggyCare.Helpers {
    public static class ReportsHelper {
        public static List<CareRecord> CareRecordsInTimePeriod { get; set; } = GetCareRecordsInTimePeriodByType(CareRecordType.Veterinary);
        private static DateTime dateTo = new DateTime(2025, 11, 2, 0, 0, 0);

        public static void UpdateCareRecordsPeriod(DateTime from, DateTime to) {
            CareRecordsInTimePeriod = GetCareRecordsInTimePeriod(from, to);
        }

        public static void UpdateCareRecordsPeriodByType(DateTime from, DateTime to, CareRecordType careRecordType) {
            CareRecordsInTimePeriod = GetCareRecordsInTimePeriodByType(careRecordType, from, to);
        }

        public static List<CareRecord> GetCareRecordsInTimePeriod(DateTime? dateFrom = null, DateTime? dateTo = null) {
            DateTime from = dateFrom ?? DateTime.MinValue;
            DateTime to = dateTo ?? DateTime.Now;
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            List<CareRecord> newestCareRecords = careRecords.Where(r => r.Date >= from && r.Date <= to).ToList();
            return newestCareRecords;
        }

        public static List<CareRecord> GetCareRecordsInTimePeriodByType(CareRecordType careRecordType, DateTime? dateFrom = null, DateTime? dateTo = null) {
            DateTime from = dateFrom ?? DateTime.MinValue;
            DateTime to = dateTo ?? DateTime.Now;
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            List<CareRecord> newestCareRecords = careRecords.Where(r => r.Date >= from && r.Date <= to && r.Type == careRecordType).ToList();
            return newestCareRecords;
        }

        public static string GetHighestPriceString(CareRecordType careRecordType) {
            return $"{GetHighestPrice(careRecordType).ToString()},- Kč";
        }
        public static decimal GetHighestPrice(CareRecordType careRecordType) {
            decimal? averagePrice = CareRecordsInTimePeriod.Where(careRecord => careRecord.Type == careRecordType)
                                                            .Select(careRecord => careRecord.Price)
                                                            .DefaultIfEmpty(0)
                                                            .Max();
            if (averagePrice != null) {
                return (decimal)averagePrice;
            } else {
                return 0;
            }
        }

        public static string GetLowestPriceString(CareRecordType careRecordType) {
            return $"{GetLowestPrice(careRecordType).ToString()},- Kč";
        }

        public static decimal GetLowestPrice(CareRecordType careRecordType) {
            decimal? averagePrice = CareRecordsInTimePeriod.Where(careRecord => careRecord.Type == careRecordType)
                                                            .Select(careRecord => careRecord.Price)
                                                            .DefaultIfEmpty(0)
                                                            .Min();
            if (averagePrice != null) {
                return (decimal)averagePrice;
            } else {
                return 0;
            }
        }

        public static string GetAveragePriceString(CareRecordType careRecordType) {
            return $"{GetAveragePrice(careRecordType).ToString()},- Kč";
        }

        public static decimal GetAveragePrice(CareRecordType careRecordType) {
            decimal? averagePrice = CareRecordsInTimePeriod.Where(careRecord => careRecord.Type == careRecordType)
                                                            .Select(careRecord => careRecord.Price)
                                                            .DefaultIfEmpty(0)
                                                            .Average();

            if (averagePrice != null) {
                return (decimal)averagePrice;
            } else {
                return 0;
            }
        }

        public static List<double> GetPrices() {
            List<double> prices = new List<double>();
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            foreach (CareRecord careRecord in careRecords) {
                prices.Add((double)careRecord.Price);
            }

            return prices;
        }

        public static void LoadChartData(FormsPlot formsPlot, DateTime dateFrom, DateTime dateTo) {
            List<DateTime> datesList = new List<DateTime>();
            List<decimal> priceList = new List<decimal>();
            DateTime? previousDate = null;

            foreach (var careRecord in CareRecordsInTimePeriod
                .OrderBy(record => record.Date)) {

                if (previousDate.HasValue && careRecord.Date == previousDate) {
                    priceList[^1] += careRecord.Price;
                } else {
                    datesList.Add(careRecord.Date);
                    priceList.Add(careRecord.Price);
                }

                previousDate = careRecord.Date;
            }

            DateTime[] datesArray = datesList.ToArray();
            decimal[] priceArray = priceList.ToArray();

            // Převede datumy na čísla pro osu X
            double[] datesAsValues = datesArray.Select(dateAsValue => dateAsValue.ToOADate()).ToArray();

            var plot = formsPlot.Plot;
            plot.Add.Scatter(datesAsValues, priceArray);
            //Font("Segoe UI", 10, FontStyle.Regular);
            plot.Axes.Title.Label.FontName = "Segoe UI";
            plot.Axes.Title.Label.FontSize = 24;

            plot.Axes.Left.Label.FontName = "Segoe UI";
            plot.Axes.Left.Label.FontSize = 16;

            plot.Axes.Bottom.Label.FontName = "Segoe UI";
            plot.Axes.Bottom.Label.FontSize = 16;

            plot.FigureBackground.Color = ScottPlot.Color.FromColor(Color.White);

            // Nastaví formátování osy X na datum
            plot.Axes.DateTimeTicksBottom();

            plot.Title($"Výdaje za {dateFrom.ToString("dd.MM.yyyy")} - {dateTo.ToString("dd.MM.yyyy")}");
            plot.YLabel("Cena (Kč)");
            plot.XLabel("Datum");

            //formsPlot.Plot.Axes.SetLimitsY(0, (double)maxY * 1.1); // 10 % rezerva

            formsPlot.Refresh();
        }

        public static ComboBox CreateReportsComboBox(string cbName) {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = cbName;
            //comboBox.Dock = DockStyle.Left;
            //comboBox.Anchor = AnchorStyles.Left;
            comboBox.Location = new Point(0, 12);
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
    }
}
