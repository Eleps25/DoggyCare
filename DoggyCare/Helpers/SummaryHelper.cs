using DoggyCare.Models;
using ScottPlot.WinForms;

namespace DoggyCare.Helpers {
    public static class SummaryHelper {

        public static string GetLastVetVisitString() {
            var lastVetVisitEntryDateTime = GetLastVetVisit();

            if (lastVetVisitEntryDateTime != DateTime.MinValue) {

                return lastVetVisitEntryDateTime.ToString("dd.MM.yyyy");
            } else {
                return "Žádná poslední návštěva.";
            }
        }
        public static DateTime GetLastVetVisit() {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            CareRecord? lastVetVisit = careRecords.Where(careRecord => careRecord.Type == Enums.CareRecordType.Veterinary).MaxBy(careRecord => careRecord.Date);
            if (lastVetVisit != null) {
                return lastVetVisit.Date;
            } else {
                return DateTime.MinValue;
            }
        }

        public static string GetLastWeightString() {
            return $"{GetLastWeight().ToString()} kg";
        }

        public static Decimal GetLastWeight() {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            CareRecord? lastWeight = careRecords.Where(careRecord => careRecord.Type == Enums.CareRecordType.Weight).MaxBy(careRecord => careRecord.Date);
            if (lastWeight != null) {
                return (decimal)lastWeight.Weight;
            } else {
                return 0;
            }
        }

        public static string GetLastFoodPriceString() {
            return $"{GetLastFoodPrice().ToString()},- Kč";
        }

        public static Decimal GetLastFoodPrice() {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();

            CareRecord? lastFoodPrice = careRecords.Where(careRecord => careRecord.Type == Enums.CareRecordType.Food).MaxBy(careRecord => careRecord.Date);

            if (lastFoodPrice != null) {
                return lastFoodPrice.Price;
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

        public static void LoadChartData(FormsPlot formsPlot) {
            List<CareRecord> careRecords = DatabaseHelper.GetCareRecords();
            List<DateTime> datesList = new List<DateTime>();
            List<decimal> priceList = new List<decimal>();
            DateTime? previousDate = null;

            foreach (var careRecord in careRecords
                .Where(record => record.Date.Month == DateTime.Now.Month && record.Date.Year == DateTime.Now.Year)
                .OrderBy(record => record.Date)) {

                if (previousDate.HasValue && careRecord.Date == previousDate) {
                    priceList[^1] += careRecord.Price;
                } else {
                    datesList.Add(careRecord.Date);
                    priceList.Add(careRecord.Price);
                }

                previousDate = careRecord.Date;
            }

            // Přidat 0 záznam na 28 v měsíci pro zobrazení zbytku měsíce v diagramu nebo pokud není záznam pro dnešní den a je 29. a později
            if (DateTime.Now.Day <= 28) {
                datesList.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28));
                priceList.Add(0);
            } else if (previousDate != DateTime.Today) {
                datesList.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28));
                priceList.Add(0);
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

            plot.Title("Výdaje za tento měsíc");
            plot.YLabel("Cena (Kč)");
            plot.XLabel("Datum");

            var maxY = priceArray.Max();
            //formsPlot.Plot.Axes.SetLimitsY(0, (double)maxY * 1.1); // 10 % rezerva

            formsPlot.Refresh();
        }
    }
}
