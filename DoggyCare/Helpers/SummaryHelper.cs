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
    }
}
