using FitnessPlanner.App.Models;

namespace FitnessPlanner.App.Services.Interfaces;

public interface IActivityService
{
    void AddActivity(Activity activity);

    IReadOnlyList<Activity> GetActivities();
}
