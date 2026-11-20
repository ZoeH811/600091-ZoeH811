using SQLite;
using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Data;

public class AppDatabase
{
    private SQLiteAsyncConnection? database;

    private readonly SemaphoreSlim initializationLock = new(1, 1);


    public async Task InitializeAsync()
    {
        if (database is not null)
            return;

        await initializationLock.WaitAsync();

        try
        {
            if (database is not null)
                return;

            string databasePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "fitnessplanner.db3"
            );

            var connection = new SQLiteAsyncConnection(
                databasePath,
                SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache
            );

            await connection.CreateTableAsync<Activity>();
            await connection.CreateTableAsync<UserProfile>();

            database = connection;
        }
        finally
        {
            initializationLock.Release();
        }

        //string databasePath = Path.Combine(FileSystem.AppDataDirectory, "fitnessplanner.db3");
        //var connection = new SQLiteAsyncConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        //await connection.CreateTableAsync<Activity>();
        //await connection.CreateTableAsync<UserProfile>();
        //database = connection;
    }

    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        await InitializeAsync();

        return database!;
    }
}
