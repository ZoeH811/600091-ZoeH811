using FitnessPlanner.App.ViewModels;

namespace FitnessPlanner.App.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();

        BindingContext = new DashboardViewModel();
    }

    private async void OnStartWorkoutClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Workout Adventure", "Your workout adventure will begin here!", "OK");
    }

    private async void OnPlannerTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//planner");
    }

    private async void OnDiaryTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//diary");
    }
}