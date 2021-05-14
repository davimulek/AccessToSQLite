using System.Data.SQLite;
using System.IO;

namespace AccessToSQLite.Core
{
    public class SqLiteProvider
    {
        private readonly string fileName;

        public SqLiteProvider(string fileName)
        {
            this.fileName = fileName;
        }

        private string ConnectionString => $"Data Source={fileName};Version=3;";

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            return conn.OpenAndReturn();
        }

        public void CreateDatabase()
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            SQLiteConnection.CreateFile(fileName);
        }
    }
}
