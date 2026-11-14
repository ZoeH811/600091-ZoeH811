using SQLite;
using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Data;

public class AppDatabase
{
    private SQLiteAsyncConnection? database;

    public async Task InitializeAsync()
    {
        if (database is not null)
            return;

        string databasePath = Path.Combine(FileSystem.AppDataDirectory,
            "fitnessplanner.db3"
        );

        var connection = new SQLiteAsyncConnection(
            databasePath,
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache
        );

        await connection.CreateTableAsync<Activity>();

        database = connection;
    }
}
