using DoggyCare.Enums;
using DoggyCare.Models;
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
        public static List<CareRecord> GetCareRecords() {
            List<CareRecord> careRecords = new List<CareRecord>();
            careRecords.Clear();

            using (var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {tableName} ORDER BY Date DESC";
                using var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    careRecords.Add(new CareRecord {
                        Id = reader.GetInt32(0),
                        Date = DateTime.Parse(reader.GetString(1)),
                        Year = reader.GetInt32(2),
                        Month = reader.GetInt32(3),
                        Day = reader.GetInt32(4),
                        Type = (CareRecordType)reader.GetInt32(5),
                        Price = (decimal)reader.GetDouble(6),
                        Weight = reader.IsDBNull(7) ? (decimal?)null : (decimal)reader.GetDouble(7),
                        Description = reader.IsDBNull(8) ? string.Empty : reader.GetString(8)
                    });
                }
                connection.Close();
                return careRecords;
            }
        }

        // Get Record with ID
        public static CareRecord GetCareRecord(int id) {
            List<CareRecord> careRecords = GetCareRecords();

            foreach (CareRecord careRecord in careRecords) {
                if (careRecord.Id == id) return careRecord;
            }

            return null;
        }

        // Add Record
        public static void AddCareRecord(CareRecord inputCareRecord) {
            using (var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"INSERT INTO {tableName} (Date, Year, Month, Day, Type, Price, Weight, Description) VALUES(@Date, @Year, @Month, @Day, @Type, @Price, @Weight, @Description)";
                cmd.Parameters.AddWithValue("@Date", inputCareRecord.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Year", inputCareRecord.Year);
                cmd.Parameters.AddWithValue("@Month", inputCareRecord.Month);
                cmd.Parameters.AddWithValue("@Day", inputCareRecord.Day);
                cmd.Parameters.AddWithValue("@Type", (int)inputCareRecord.Type);
                cmd.Parameters.AddWithValue("@Price", (double)inputCareRecord.Price);
                if (inputCareRecord.Weight.HasValue) {
                    cmd.Parameters.AddWithValue("@Weight", (double)inputCareRecord.Weight.Value);
                } else {
                    cmd.Parameters.AddWithValue("@Weight", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Description", inputCareRecord.Description ?? "");
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Update Record
        public static void UpdateRecord(CareRecord updateCareRecord) {
            using (var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"UPDATE {tableName} SET Date = @Date, Year = @Year, Month = @Month, Day = @Day, Type = @Type, Price = @Price, Weight = @Weight, Description = @Description";
                cmd.Parameters.AddWithValue("@Date", updateCareRecord.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Year", updateCareRecord.Year);
                cmd.Parameters.AddWithValue("@Month", updateCareRecord.Month);
                cmd.Parameters.AddWithValue("@Day", updateCareRecord.Day);
                cmd.Parameters.AddWithValue("@Type", (int)updateCareRecord.Type);
                cmd.Parameters.AddWithValue("@Price", (double)updateCareRecord.Price);
                if (updateCareRecord.Weight.HasValue) {
                    cmd.Parameters.AddWithValue("@Weight", (double)updateCareRecord.Weight.Value);
                } else {
                    cmd.Parameters.AddWithValue("@Weight", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Description", updateCareRecord.Description ?? "");
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Delete Record
        public static void DeleteRecord(int id) {
            using (var connection = new SQLiteConnection(connectionString)) {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM {tableName} WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
