using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Services.Interfaces;

public interface IUserProfileService
{
    Task<UserProfile?> GetProfileAsync(string userId);

    Task SaveProfileAsync(UserProfile profile);
}
