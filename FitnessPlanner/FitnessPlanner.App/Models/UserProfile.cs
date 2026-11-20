using SQLite;

namespace FitnessPlanner.App.Models;

public class UserProfile
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed(Unique = true)]
    public string UserId { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string FitnessLevel { get; set; } = "Beginner";

    public string PrimaryGoal { get; set; } = "General Fitness";

    public int DaysPerWeek { get; set; } = 3;

    public int PreferredSessionMinutes { get; set; } = 45;

    public string TrainingLocation { get; set; } = "Gym";
}
