using System.ComponentModel;

namespace DoggyCare.Enums {
    public enum CareRecordType {
        [Description("Veterinář")]
        Veterinary,

        [Description("Váha")]
        Weight,

        [Description("Jídlo")]
        Food,

        [Description("Hračky")]
        Toys,

        [Description("Ostatní")]
        Other = 100
    }
}
