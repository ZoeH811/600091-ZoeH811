using FitnessPlanner.App.ViewModels;

namespace FitnessPlanner.App.Views;

public partial class DiaryPage : ContentPage
{
	public DiaryPage(DiaryViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}