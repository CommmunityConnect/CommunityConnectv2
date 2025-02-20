using SQLite;
using System.IO;
using System.Threading.Tasks;
using CommunityConnect.model;
using Microsoft.Maui.Storage;

namespace CommunityConnect.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CommunityConnect.db");

        public async Task DeleteDatabaseAsync()
        {
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
        }

        public async Task InitializeDatabase()
        {
            await _database.CreateTableAsync<IncidentReport>();
            await _database.CreateTableAsync<Alert>();
        }
        public AppDatabase()
        {
            _database = new SQLiteAsyncConnection(dbPath);

        }

        public async Task<List<Alert>> GetAlertsAsync()
        {
            return await _database.Table<Alert>().ToListAsync();
        }

        public async Task<List<IncidentReport>> GetIncidentReportsAsync()
        {
            return await _database.Table<IncidentReport>().ToListAsync();
        }
    }
}