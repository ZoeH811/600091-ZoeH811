
using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Data.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetProfileAsync(string userId);

    Task<int> SaveProfileAsync(UserProfile profile);
}
