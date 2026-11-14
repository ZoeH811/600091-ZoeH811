namespace FitnessPlanner.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartWorkoutClicked(object sender, EventArgs e)
        {
            await DisplayAlertAsync("Workout Adventure", "Your workout adventure will begin here!", "OK");
        }

        private async void OnPlannerTapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync("planner");
        }
    }
}
