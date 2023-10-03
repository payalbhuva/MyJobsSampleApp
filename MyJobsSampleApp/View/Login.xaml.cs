using MyJobsSampleApp.ViewModel;

namespace MyJobsSampleApp.View;

public partial class Login : ContentPage
{
	public Login(LoginViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}
}


