using Xunit;
using FitnessPlanner.Core.Models;
using FitnessPlanner.Core.Services;
using FitnessPlanner.Tests.TestDoubles;

namespace FitnessPlanner.Tests.Services;

public class UserProfileServiceTests
{
    private readonly FakeUserProfileRepository repository;
    private readonly UserProfileService service;

    public UserProfileServiceTests()
    {
        repository = new FakeUserProfileRepository();
        service = new UserProfileService(repository);
    }

    [Fact]
    public async Task SaveProfileAsync_ValidProfile_SavesSuccessfully()
    {
        // Arrange
        var profile = CreateValidProfile();

        // Act
        await service.SaveProfileAsync(profile);

        // Assert
        var savedProfile =
            await repository.GetProfileAsync(profile.UserId);

        Assert.NotNull(savedProfile);
        Assert.Equal("Test User", savedProfile.DisplayName);
        Assert.Equal(1, repository.SaveCallCount);
    }

    [Fact]
    public async Task SaveProfileAsync_InvalidDays_ThrowsException()
    {
        // Arrange
        var profile = CreateValidProfile();
        profile.DaysPerWeek = 9;

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.SaveProfileAsync(profile)
        );

        Assert.Equal(0, repository.SaveCallCount);
    }

    [Fact]
    public async Task GetProfileAsync_UnknownUser_ReturnsNull()
    {
        // Act
        var result = await service.GetProfileAsync("unknown-user");

        // Assert
        Assert.Null(result);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(8)]
    [InlineData(10)]
    public async Task SaveProfileAsync_InvalidTrainingDays_IsRejected(
        int days)
    {
        // Arrange
        var profile = CreateValidProfile();
        profile.DaysPerWeek = days;

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.SaveProfileAsync(profile)
        );

        Assert.Equal(0, repository.SaveCallCount);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    [InlineData(241)]
    [InlineData(-30)]
    public async Task SaveProfileAsync_InvalidDuration_IsRejected(
        int minutes)
    {
        // Arrange
        var profile = CreateValidProfile();
        profile.PreferredSessionMinutes = minutes;

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.SaveProfileAsync(profile)
        );

        Assert.Equal(0, repository.SaveCallCount);
    }


    [Fact]
    public async Task SaveProfileAsync_EmptyDisplayName_IsRejected()
    {
        // Arrange
        var profile = CreateValidProfile();
        profile.DisplayName = "";

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.SaveProfileAsync(profile)
        );

        Assert.Equal(0, repository.SaveCallCount);
    }

    [Fact]
    public async Task SaveProfileAsync_UnsupportedFitnessLevel_IsRejected()
    {
        // Arrange
        var profile = CreateValidProfile();
        profile.FitnessLevel = "Expert";

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.SaveProfileAsync(profile)
        );

        Assert.Equal(0, repository.SaveCallCount);
    }

    [Fact]
    public async Task GetProfileAsync_EmptyUserId_IsRejected()
    {
        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.GetProfileAsync("")
        );
    }



    private static UserProfile CreateValidProfile()
    {
        return new UserProfile
        {
            UserId = "test-user-001",
            DisplayName = "Test User",
            FitnessLevel = "Beginner",
            PrimaryGoal = "General Fitness",
            DaysPerWeek = 3,
            PreferredSessionMinutes = 45,
            TrainingLocation = "Gym"
        };
    }
}
