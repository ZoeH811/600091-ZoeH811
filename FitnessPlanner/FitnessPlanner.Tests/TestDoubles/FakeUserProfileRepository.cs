using FitnessPlanner.Core.Interfaces;
using FitnessPlanner.Core.Models;

namespace FitnessPlanner.Tests.TestDoubles;

public class FakeUserProfileRepository : IUserProfileRepository
{
    private readonly Dictionary<string, UserProfile> profiles = new();

    public int SaveCallCount { get; private set; }

    public Task<UserProfile?> GetProfileAsync(string userId)
    {
        profiles.TryGetValue(userId, out var profile);

        return Task.FromResult(profile);
    }

    public Task<int> SaveProfileAsync(UserProfile profile)
    {
        SaveCallCount++;

        profiles[profile.UserId] = profile;

        return Task.FromResult(1);
    }
}
