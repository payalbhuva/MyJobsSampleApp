using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyJobsSampleApp.View;


namespace MyJobsSampleApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
	{

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        public LoginViewModel()
		{
		}

        /// <summary>
        /// Execute Login method to check the credentials and navigate to Job List Page
        /// </summary>
        [RelayCommand]
        void ExecuteLogin()
        {
            try
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                {
                    if (Username.ToUpper().Equals("TEST") && Password.Equals("12345"))
                    {
                        Shell.Current.GoToAsync(nameof(JobsPage));
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exceptions
            }
        }
    }
}

