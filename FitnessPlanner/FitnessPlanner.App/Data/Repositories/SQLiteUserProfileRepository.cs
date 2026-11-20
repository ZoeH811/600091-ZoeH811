using FitnessPlanner.App.Data.Interfaces;
using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Data.Repositories;

public class SQLiteUserProfileRepository : IUserProfileRepository
{
    private readonly AppDatabase appDatabase;

    public SQLiteUserProfileRepository(AppDatabase appDatabase)
    {
        this.appDatabase = appDatabase;
    }

    public async Task<UserProfile?> GetProfileAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException(
                "A user ID is required.",
                nameof(userId)
            );

        var database = await appDatabase.GetConnectionAsync();

        return await database.Table<UserProfile>()
            .Where(profile => profile.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveProfileAsync(UserProfile profile)
    {
        if (profile is null)
            throw new ArgumentNullException(nameof(profile));

        if (string.IsNullOrWhiteSpace(profile.UserId))
            throw new ArgumentException(
                "A profile must have a user ID."
            );

        var database = await appDatabase.GetConnectionAsync();

        var existingProfile = await GetProfileAsync(profile.UserId);

        if (existingProfile is null)
        {
            profile.Id = 0;

            return await database.InsertAsync(profile);
        }

        profile.Id = existingProfile.Id;

        return await database.UpdateAsync(profile);
    }
}
