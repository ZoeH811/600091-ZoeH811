using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessPlanner.App.Models;
using FitnessPlanner.App.Services.Interfaces;
using System.Collections.ObjectModel;

namespace FitnessPlanner.App.ViewModels;

public partial class DiaryViewModel : ObservableObject
{
    private readonly IActivityService activityService;

    public ObservableCollection<Activity> Activities { get; } = new();

    public DiaryViewModel(IActivityService activityService)
    {
        this.activityService = activityService;

        LoadActivities();
    }

    private void LoadActivities()
    {
        Activities.Clear();

        foreach (var activity in activityService.GetActivities())
        {
            Activities.Add(activity);
        }
    }

    [RelayCommand]
    private void AddTestActivity()
    {
        var activity = new Activity
        {
            Name = "Upper Body Training",
            ActivityType = "Strength",
            Date = DateTime.Now,
            DurationMinutes = 45
        };

        activityService.AddActivity(activity);

        LoadActivities();
    }
}
