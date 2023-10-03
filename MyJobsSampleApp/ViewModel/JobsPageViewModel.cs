using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyJobsSampleApp.Data;
using MyJobsSampleApp.Enum;
using MyJobsSampleApp.Model;
using MyJobsSampleApp.View;

namespace MyJobsSampleApp.ViewModel
{
	public partial class JobsPageViewModel: ObservableObject
	{
        private readonly DatabaseContext _context;

        private ObservableCollection<Job> AllJobsList;

        [ObservableProperty]
        private ObservableCollection<Job> jobList;

        [ObservableProperty]
        private Color openButtonBorderColor;

        [ObservableProperty]
        private Color inProgressBorderColor;

        [ObservableProperty]
        private Color onHoldButtonBorderColor;

        [ObservableProperty]
        private Color closedButtonBorderColor;

        private JobStatus selectedJobStatus;

        public JobsPageViewModel(DatabaseContext context)
        {
            try
            {
                _context = context;

                var jobsList = new ObservableCollection<Job>() {
                        new Job() {
                                    Id="1",
                                    Name = "Job1",
                                    Description = "Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.",
                                    Status= Enum.JobStatus.Open,
                                    StartDate = new DateTime(2023,09,23),
                                    DueDate=new DateTime(2023,09,28)
                        },
                        new Job() {
                                    Id="2",
                                    Name = "Job2",
                                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                                    Status=Enum.JobStatus.Open,
                                    StartDate = new DateTime(2022,02,04),
                                    DueDate=new DateTime(2022,02,05)
                        },
                        new Job() {
                                    Id="3",
                                    Name = "Job3",
                                    Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                                    Status= Enum.JobStatus.Open,
                                    StartDate = new DateTime(2023,08,01),
                                    DueDate=new DateTime(2023,08,07)
                        },
                        new Job() {
                                    Id="4",
                                    Name = "Job4",
                                    Description = "taque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                                    Status=Enum.JobStatus.Open,
                                    StartDate = new DateTime(2024,05,12),
                                    DueDate=new DateTime(2024,05,19)
                        },
                         new Job() {
                                    Id="5",
                                    Name = "Job5",
                                    Description = "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? ",
                                    Status=Enum.JobStatus.OnHold,
                                    StartDate = new DateTime(2023,01,16),
                                    DueDate=new DateTime(2023,04,01)
                        }
                };

                //Ideally the data coming from webservice would be saved in local database.
                foreach(var item in jobsList)
                {
                    Task.Run(async () => await _context.AddItemAsync(item));
                }
                
                var list = Task.Run(async () => await _context.GetAllAsync<Job>()).Result;
                AllJobsList = new ObservableCollection<Job>(list);

                //By default show Open Jobs
                OpenJobs();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To show jobs with JobStatus:Open and highlight the OpenJobs tab
        /// </summary>
        [RelayCommand]
        private void OpenJobs()
        {
            try
            {
                var openJobs = AllJobsList.Where(x => x.Status.Equals(JobStatus.Open));
                JobList = new ObservableCollection<Job>(openJobs);
                OpenButtonBorderColor = Color.FromRgb(0, 0, 0);
                InProgressBorderColor = Color.FromRgb(255, 255, 224);
                OnHoldButtonBorderColor = Color.FromRgb(173, 216, 230);
                ClosedButtonBorderColor = Color.FromRgb(240, 128, 128);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To show jobs with JobStatus:InProgress and highlight the InProgressJobs tab
        /// </summary>
        [RelayCommand]
        private void InProgressJobs()
        {
            try
            {
                var inProgressJobs = AllJobsList.Where(x => x.Status.Equals(JobStatus.InProgress));
                JobList = new ObservableCollection<Job>(inProgressJobs);
                OpenButtonBorderColor = Color.FromRgb(144, 238, 144);
                InProgressBorderColor = Color.FromRgb(0, 0, 0);
                OnHoldButtonBorderColor = Color.FromRgb(173, 216, 230);
                ClosedButtonBorderColor = Color.FromRgb(240, 128, 128);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To show jobs with JobStatus:OnHold and highlight the OnHoldJobs tab
        /// </summary>
        [RelayCommand]
        private void OnHoldJobs()
        {
            try
            {
                var onHoldJobs = AllJobsList.Where(x => x.Status.Equals(JobStatus.OnHold));
                JobList = new ObservableCollection<Job>(onHoldJobs);
                OpenButtonBorderColor = Color.FromRgb(144, 238, 144);
                InProgressBorderColor = Color.FromRgb(255, 255, 224);
                OnHoldButtonBorderColor = Color.FromRgb(0, 0, 0);
                ClosedButtonBorderColor = Color.FromRgb(240, 128, 128);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To show jobs with JobStatus:Closed and highlight the Closed Jobs tab
        /// </summary>
        [RelayCommand]
        private void ClosedJobs()
        {
            try
            {
                var closedJobs = AllJobsList.Where(x => x.Status.Equals(JobStatus.Closed));
                JobList = new ObservableCollection<Job>(closedJobs);
                OpenButtonBorderColor = Color.FromRgb(144, 238, 144);
                InProgressBorderColor = Color.FromRgb(255, 255, 224);
                OnHoldButtonBorderColor = Color.FromRgb(173, 216, 230);
                ClosedButtonBorderColor = Color.FromRgb(0, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Navigate to Jobs Details Page on Job selection
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [RelayCommand]
        private async Task JobSelected(Job job)
        {
            try
            {
                selectedJobStatus = job.Status;
                await Shell.Current.GoToAsync(nameof(JobsDetail),
                    new Dictionary<string, object>
                    {
                    { "SelectedJob" , job }
                    });
            }
            catch (Exception ex)
            {

            }
        }

        [RelayCommand]
        void Appearing()
        {
            try
            {
                if (selectedJobStatus.Equals(JobStatus.Open))
                {
                    OpenJobs();
                }
                else if(selectedJobStatus.Equals(JobStatus.InProgress))
                {
                    InProgressJobs();
                }
                else if(selectedJobStatus.Equals(JobStatus.OnHold))
                {
                    OnHoldJobs();
                }
                else
                {
                    ClosedJobs();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

    }
}

