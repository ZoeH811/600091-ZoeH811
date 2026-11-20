using FitnessPlanner.App.Data.Interfaces;
using FitnessPlanner.App.Models;
using FitnessPlanner.App.Services.Interfaces;

namespace FitnessPlanner.App.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository profileRepository;

    public UserProfileService(
        IUserProfileRepository profileRepository)
    {
        this.profileRepository = profileRepository;
    }

    public async Task<UserProfile?> GetProfileAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new ArgumentException(
                "A valid user ID is required.",
                nameof(userId)
            );
        }

        return await profileRepository.GetProfileAsync(userId);
    }

    public async Task SaveProfileAsync(UserProfile profile)
    {
        ValidateProfile(profile);

        await profileRepository.SaveProfileAsync(profile);
    }

    private static void ValidateProfile(UserProfile profile)
    {
        if (profile is null)
        {
            throw new ArgumentNullException(nameof(profile));
        }

        if (string.IsNullOrWhiteSpace(profile.UserId))
        {
            throw new ArgumentException(
                "A profile must be associated with a user account."
            );
        }

        if (string.IsNullOrWhiteSpace(profile.DisplayName))
        {
            throw new ArgumentException(
                "Please enter a display name."
            );
        }

        if (profile.DaysPerWeek < 1 || profile.DaysPerWeek > 7)
        {
            throw new ArgumentException(
                "Training days must be between 1 and 7."
            );
        }

        if (profile.PreferredSessionMinutes < 10 ||
            profile.PreferredSessionMinutes > 240)
        {
            throw new ArgumentException(
                "Workout duration must be between 10 and 240 minutes."
            );
        }

        string[] supportedFitnessLevels =
        {
            "Beginner",
            "Intermediate",
            "Advanced"
        };

        if (!supportedFitnessLevels.Contains(profile.FitnessLevel))
        {
            throw new ArgumentException(
                "Please select a valid fitness level."
            );
        }

        string[] supportedGoals =
        {
            "General Fitness",
            "Strength",
            "Muscle Gain",
            "Endurance",
            "Weight Management"
        };

        if (!supportedGoals.Contains(profile.PrimaryGoal))
        {
            throw new ArgumentException(
                "Please select a valid fitness goal."
            );
        }

        string[] supportedLocations =
        {
            "Gym",
            "Home",
            "Both"
        };

        if (!supportedLocations.Contains(profile.TrainingLocation))
        {
            throw new ArgumentException(
                "Please select a valid training location."
            );
        }
    }
}
