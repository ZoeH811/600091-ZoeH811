using FitnessPlanner.App.Models;
using FitnessPlanner.App.Services.Interfaces;

namespace FitnessPlanner.App.Services;

public class ActivityService : IActivityService
{
    private readonly List<Activity> activities = new();

    private int nextId = 1;

    public void AddActivity(Activity activity)
    {
        activity.Id = nextId++;

        activities.Add(activity);
    }

    public IReadOnlyList<Activity> GetActivities()
    {
        return activities.AsReadOnly();
    }
}
