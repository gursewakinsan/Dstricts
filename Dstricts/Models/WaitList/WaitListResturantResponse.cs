using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dstricts.Models
{
	public class WaitListResturantResponse : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_name")]
		public string QueueName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "waiting_count")]
		public int WaitingCount { get; set; }

		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(QueueName, 0).ToUpper();

		private string queueFirstLetterBg;
		public string QueueFirstLetterBg
		{
			get => queueFirstLetterBg;
			set
			{
				queueFirstLetterBg = value;
				OnPropertyChanged("QueueFirstLetterBg");
			}
		}

		private string queueFirstLetterText;
		public string QueueFirstLetterText
		{
			get => queueFirstLetterText;
			set
			{
				queueFirstLetterText = value;
				OnPropertyChanged("QueueFirstLetterText");
			}
		}

		#region On Property Changed.
		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion

		/*[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "location_id")]
		public int LocationId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_operators")]
		public int TotalOperators { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "opening_time")]
		public string OpeningTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "closing_time")]
		public string ClosingTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "tokan_closing")]
		public string TokanClosing { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "published_queue")]
		public int PublishedQueue { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_active")]
		public bool IsActive { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dining_id")]
		public int DiningId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_type")]
		public int QueueType { get; set; }*/
	}
}
