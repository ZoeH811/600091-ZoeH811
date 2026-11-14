using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FitnessPlanner.App.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private int petLevel = 1;

    [ObservableProperty]
    private int petExperience = 0;

    [ObservableProperty]
    private string workoutStatus = "No workout scheduled";


    [RelayCommand]
    private void GainExperience()
    {
        PetExperience += 10;

        if (PetExperience >= 100)
        {
            PetExperience -= 100;
            PetLevel++;
        }
    }

}
