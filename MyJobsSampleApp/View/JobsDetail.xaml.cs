using CommunityToolkit.Maui.Views;
using MyJobsSampleApp.ViewModel;

namespace MyJobsSampleApp.View;

public partial class JobsDetail : ContentPage
{
	public JobsDetail(JobsDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}
