using System.Configuration;
using System.Data.SQLite;

namespace DoggyCare.Helpers {
    public static class DatabaseHelper {
        private static string connectionString = ConfigurationManager.AppSettings.Get("connectString");
        private static string tableName = ConfigurationManager.AppSettings.Get("tableName");
        // Check or Init DB
        public static void CheckOrInitDb() {
            using (var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText =
                    $@"CREATE TABLE IF NOT EXISTS {tableName}(
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date TEXT NOT NULL,
                                Year INTEGER NOT NULL,
                                Month INTEGER NOT NULL,
                                Day INTEGER NOT NULL,
                                Type INTEGER NOT NULL,
                                Price REAL NOT NULL,
                                Weight REAL,
                                Description TEXT
                                );";
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        // Get Records

        // Get Record with ID

        // Add Record

        // Update Record

        // Delete Record
    }
}
