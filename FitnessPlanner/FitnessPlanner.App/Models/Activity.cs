namespace FitnessPlanner.App.Models;

public class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ActivityType { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;

    public int DurationMinutes { get; set; }
}
