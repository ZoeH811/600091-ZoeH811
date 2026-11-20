using FitnessPlanner.App.Data;
using System.Diagnostics;


namespace FitnessPlanner.App
{
    public partial class App : Application
    {
        private readonly AppDatabase appDatabase;

        public App(AppDatabase appDatabase)
        {
            InitializeComponent();
            this.appDatabase = appDatabase;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            _ = InitializeDatabaseAsync();

            return new Window(new AppShell());
        }

        private async Task InitializeDatabaseAsync()
        {
            try
            {
                await appDatabase.InitializeAsync();

                Debug.WriteLine("SQLite database initialised successfully.");

                await MainThread.InvokeOnMainThreadAsync(
                    () => Shell.Current.DisplayAlertAsync(
                        "SQLite Test",
                        "Database initialised successfully!",
                        "OK"
            )
        );
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SQLite initialisation failed: {ex}");

                await MainThread.InvokeOnMainThreadAsync(
                    () => Shell.Current.DisplayAlertAsync(
                        "SQLite Error",
                        ex.Message,
                        "OK"
            )
        );
            }
        }

    }
}