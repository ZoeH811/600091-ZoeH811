
using FitnessPlanner.Core.Models;

namespace FitnessPlanner.Core.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetProfileAsync(string userId);

    Task<int> SaveProfileAsync(UserProfile profile);
}
