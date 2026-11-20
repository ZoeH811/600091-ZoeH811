using FitnessPlanner.Core.Models;

namespace FitnessPlanner.Core.Interfaces;

public interface IUserProfileService
{
    Task<UserProfile?> GetProfileAsync(string userId);

    Task SaveProfileAsync(UserProfile profile);
}
