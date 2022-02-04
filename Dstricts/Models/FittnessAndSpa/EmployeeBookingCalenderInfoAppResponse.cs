namespace Dstricts.Models
{
	public class EmployeeBookingCalenderInfoAppResponse  : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "time_required")]
		public int TimeRequired { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "date")]
		public int Date { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "work_time")]
		public string WorkTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "emp_id")]
		public int EmpId { get; set; }

		public bool IsSelected { get; set; }

		private Xamarin.Forms.Color selectedTimeBg = Xamarin.Forms.Color.FromHex("#2A2A31");
		public Xamarin.Forms.Color SelectedTimeBg
		{
			get => selectedTimeBg;
			set
			{
				selectedTimeBg = value;
				OnPropertyChanged("SelectedTimeBg");
			}
		}
	}
}
