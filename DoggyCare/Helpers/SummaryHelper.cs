using DoggyCare.Models;

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
    }
}
