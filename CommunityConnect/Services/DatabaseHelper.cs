using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace CommunityConnect.Services
{
    public static class DatabaseHelper
    {
        private static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection GetDatabaseConnection()
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CommunityConnect.db");
                _database = new SQLiteAsyncConnection(dbPath);
            }
            return _database;
        }
    }
}
