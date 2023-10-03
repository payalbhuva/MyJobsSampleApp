using MyJobsSampleApp.View;

namespace MyJobsSampleApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(JobsPage), typeof(JobsPage));
        Routing.RegisterRoute(nameof(JobsDetail), typeof(JobsDetail));
    }
}

