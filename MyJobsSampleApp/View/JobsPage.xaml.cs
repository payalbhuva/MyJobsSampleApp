using MyJobsSampleApp.ViewModel;

namespace MyJobsSampleApp.View;

public partial class JobsPage : ContentPage
{
	public JobsPage(JobsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
