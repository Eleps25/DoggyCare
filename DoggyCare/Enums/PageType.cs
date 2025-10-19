using System.ComponentModel;

namespace DoggyCare.Enums {
    public enum PageType {
        [Description("Dashboard")]
        Dashboard,

        [Description("Záznamy")]
        CareRecords,

        [Description("Přidat záznam")]
        AddCareRecord,

        [Description("Aktualizovat záznam")]
        UpdateCareRecord,

        [Description("Reporty")]
        Reports,
    }
}
