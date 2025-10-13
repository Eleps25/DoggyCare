using DoggyCare.Enums;

namespace DoggyCare.Models {
    public class CareRecord {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public CareRecordType Type { get; set; }
        public decimal Price { get; set; }
        public decimal? Weight { get; set; }
        public string Description { get; set; }
    }
}
