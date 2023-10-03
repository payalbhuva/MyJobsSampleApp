using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyJobsSampleApp.Data;
using MyJobsSampleApp.Enum;
using MyJobsSampleApp.Model;
using MyJobsSampleApp.View;

namespace MyJobsSampleApp.ViewModel
{
    public partial class JobsDetailViewModel:ObservableObject, IQueryAttributable
    {
        private readonly DatabaseContext _context;

        [ObservableProperty]
        Job selectedJob;

        [ObservableProperty]
        bool isUploadVisible;

        [ObservableProperty]
        bool isEvidenceVisible;

        [ObservableProperty]
        bool startJobVisible;

        [ObservableProperty]
        bool changeJobStatusBtnVisible;

        public JobsDetailViewModel(DatabaseContext context)
		{
            _context = context;

            IsUploadVisible = false;
        }

        /// <summary>
        /// To fetch the data passed in query parameter and
        /// show the buttons(Upload Image, ShowImage, Complete Job) as per status
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            try
            {
                SelectedJob = query["SelectedJob"] as Job;
                if (SelectedJob != null)
                {

                    if (SelectedJob.Photo != null)
                    {
                        IsUploadVisible = false;
                        IsEvidenceVisible = true;
                        StartJobVisible = false;
                    }
                    else if (!SelectedJob.Status.Equals(JobStatus.Open) && !SelectedJob.Status.Equals(JobStatus.Closed))
                    {
                        IsEvidenceVisible = true;
                        IsUploadVisible = true;
                        StartJobVisible = false;
                    }
                    else
                    {
                        StartJobVisible = true;
                        IsEvidenceVisible = false;
                    }
                }

                if (SelectedJob.Status.Equals(JobStatus.Closed))
                {
                    ChangeJobStatusBtnVisible = false;
                }
                else
                {
                    ChangeJobStatusBtnVisible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To change the status of Job to InProgress and update in database
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task StartJob()
        {
            try
            {
                SelectedJob.Status = Enum.JobStatus.InProgress;
                IsUploadVisible = true;
                await _context.UpdateItemAsync(SelectedJob);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To Open the phone gallery to upload a single image on upload image button
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task UploadImage()
        {
            string image = string.Empty;
            try
            {
                    FileResult photo = await MediaPicker.PickPhotoAsync();
                    if (photo != null)
                    {
                        // save the file into local storage
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                        using Stream sourceStream = await photo.OpenReadAsync();

                    if (sourceStream != null)
                    {
                        using (MemoryStream memory = new MemoryStream())
                        {
                            sourceStream.CopyTo(memory);
                            byte[] bytes = memory.ToArray();
                           image = Convert.ToBase64String(bytes);
                        }
                    }
                }
                SelectedJob.Photo = image;
                await _context.UpdateItemAsync(SelectedJob);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To convert selected image to base64 string 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToBase64String(string fileName)
        {
            try
            {
                using (FileStream reader = new FileStream(fileName, FileMode.Open))
                {
                    byte[] buffer = new byte[reader.Length];
                    reader.Read(buffer, 0, (int)reader.Length);
                    return Convert.ToBase64String(buffer);
                }
            }
            catch (Exception ex)
            {
                
            }
            return string.Empty;
        }

        /// <summary>
        /// To display image on popup on click of show image button
        /// </summary>
        [RelayCommand]
        void ShowImage()
        {
            try
            {
                var imagePopup = new ImagePopup(SelectedJob);
                Application.Current.MainPage.ShowPopup(imagePopup);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To mark the status of job to complete and add job completion date
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task CompletedJob()
        {
            try
            {
                SelectedJob.Status = Enum.JobStatus.Closed;
                SelectedJob.CompletionDate = DateTime.Now;
                await _context.UpdateItemAsync(SelectedJob);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

