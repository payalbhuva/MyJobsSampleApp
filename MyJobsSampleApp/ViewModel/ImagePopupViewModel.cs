using CommunityToolkit.Mvvm.ComponentModel;
using MyJobsSampleApp.Model;
namespace MyJobsSampleApp.ViewModel
{
    public partial class ImagePopupViewModel : ObservableObject
	{
		[ObservableProperty]
		string message;

		[ObservableProperty]
		ImageSource photo;

		public ImagePopupViewModel(Job job)
		{
			var image = GetImageFromBase64String(job.Photo);
			if(image!=null)
			{
				Photo = image;
			}
        }

		/// <summary>
		/// To convert base64string to Image source to display on popup
		/// </summary>
		/// <param name="base64String"></param>
		/// <returns></returns>
		ImageSource GetImageFromBase64String(string base64String)
		{
			try
			{
				var imageBytes = Convert.FromBase64String(base64String);
				MemoryStream imageDecodeStream = new(imageBytes);
				return ImageSource.FromStream(() => imageDecodeStream);
			}
			catch (Exception ex)
			{

			}
			return null;
        }

	}
}

