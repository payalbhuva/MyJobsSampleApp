using CommunityToolkit.Mvvm.ComponentModel;
using MyJobsSampleApp.Enum;
using SQLite;

namespace MyJobsSampleApp.Model
{
    public partial class Job :ObservableObject
	{
		[PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		[ObservableProperty]
		public JobStatus status;
		public DateTime StartDate { get; set; }
		public DateTime DueDate { get; set; }
		[ObservableProperty]
		public DateTime completionDate;

        [ObservableProperty]
		public string photo;
    }
}

