using FitnessPlanner.App.Views;

namespace FitnessPlanner.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                "planner",
                typeof(PlannerPage));
        }
    }
}
