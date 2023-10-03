using CommunityToolkit.Maui.Views;
using MyJobsSampleApp.Model;
using MyJobsSampleApp.ViewModel;

namespace MyJobsSampleApp.View;
public partial class ImagePopup : Popup
{
    public ImagePopup(Job job)
    {
        InitializeComponent();
        BindingContext = new ImagePopupViewModel(job);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }
}